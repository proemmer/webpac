using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using webpac.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Dnx.Compilation.CSharp;
using Microsoft.Dnx.Compilation;
using Microsoft.Extensions.PlatformAbstractions;
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
using System.Reflection.Emit;
using System.Runtime.Loader;
using System.Reflection;

namespace webpac.Services
{
    public class RuntimeCompilerService : IRuntimeCompilerService
    {
        //private Dictionary<string,Assembly> 
        private readonly List<MetadataReference> _references = new List<MetadataReference>();
        private readonly List<Type> _resolvedTypes = new List<Type>();
        private readonly ILibraryExporter _libraryExporter;
        private readonly ILibraryManager _libraryManager;
        private readonly IApplicationEnvironment _environment;
        private readonly ICompilerOptionsProvider _compilerOptionsProvider;
        private readonly IAssemblyLoadContext _context;
        private readonly CSharpCompilationOptions _compilationOptions;
        private string _location;
        private readonly ConcurrentDictionary<string, AssemblyMetadata> _metadataFileCache =new ConcurrentDictionary<string, AssemblyMetadata>(StringComparer.OrdinalIgnoreCase);




        #region IService Interface
        public void Configure(IConfigurationSection config)
        {
            _location = config.Get<string>("Location");
        }

        public void Init()
        {
            //Add references
            DetermineReferences(_environment.ApplicationName);
            CompileFiles();
        }

        public void Release()
        {
            //Release all
        }
        #endregion


        public RuntimeCompilerService(ILibraryExporter libraryExporter,
                                      ILibraryManager libraryManager, 
                                      IApplicationEnvironment environment,
                                      ICompilerOptionsProvider compilerOptionsProvider)
        {
            _compilerOptionsProvider = compilerOptionsProvider;
            _environment = environment;
            _libraryManager = libraryManager;
            _libraryExporter = libraryExporter;
            _context = PlatformServices.Default.AssemblyLoadContextAccessor.Default;

            var compilerOptions = _compilerOptionsProvider.GetCompilerOptions(_environment.ApplicationName, _environment.RuntimeFramework, _environment.Configuration);
            _compilationOptions = compilerOptions.ToCompilationSettings(_environment.RuntimeFramework, _environment.ApplicationBasePath)
                                                    .CompilationOptions
                                                    .WithOutputKind(OutputKind.DynamicallyLinkedLibrary);
        }

        private void CompileFiles()
        {
            foreach (var item in Directory.GetFiles(_location, "*.cs"))
            {
                try
                {
                    var code = File.ReadAllText(item, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(code))
                    {
                        var asm = Compile(Path.GetFileNameWithoutExtension(item), code);
                        if (asm != null)
                            _resolvedTypes.AddRange(asm.GetExportedTypes());
                    }
                }
                catch (Exception ex)
                {
                    //Todo Handle Ex
                }
            }
        }

        private Assembly Compile(string name, string code)
        {
            if (code == null)
                throw new ArgumentNullException("code");

            // Parse the script to a SyntaxTree
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Compile the SyntaxTree to an in memory assembly
            var compilation = CSharpCompilation.Create(
                name,
                new[] { syntaxTree },
                _references,
                _compilationOptions
                );

            using (var outputStream = new MemoryStream())
            {
                using (var pdbStream = new MemoryStream())
                {
                    // Emit assembly to streams. Throw an exception if there are any compilation errors
                    var result = compilation.Emit(outputStream, pdbStream);

                    // Populate the _diagnostics property in order to read Errors and Warnings
                    //_Diagnostics = result.Diagnostics;

                    if (result.Success)
                    {
                        outputStream.Position = 0;
                        pdbStream.Position = 0;
                        return _context.LoadStream(outputStream, pdbStream);
                    }
                    else
                    {
                        //TODO
                        return null;
                    }
                }
            }
        }



        private MetadataReference CreateMetadataFileReference(string path)
        {
            var metadata = _metadataFileCache.GetOrAdd(path, _ =>
            {
                using (var stream = File.OpenRead(path))
                {
                    var moduleMetadata = ModuleMetadata.CreateFromStream(stream, PEStreamOptions.PrefetchMetadata);
                    return AssemblyMetadata.Create(moduleMetadata);
                }
            });

            return metadata.GetReference(filePath: path);
        }


        private void DetermineReferences(string name)
        {
            foreach (var reference in _libraryExporter.GetAllExports(name)?.MetadataReferences)
            {
                var rosRef = reference as IMetadataProjectReference;
                if (rosRef != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        rosRef.EmitReferenceAssembly(ms);
                        if (ms.Length > 0)
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            _references.Add(MetadataReference.CreateFromStream(ms));
                        }
                    }
                }
                else
                {
                    var rosRef2 = reference as IMetadataFileReference;
                    if (rosRef2 != null)
                    {
                        _references.Add(CreateMetadataFileReference(rosRef2.Path));
                    }
                }

            }
        }

    }


}

