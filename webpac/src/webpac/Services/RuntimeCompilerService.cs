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
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Compilation;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System.Runtime.InteropServices;
using Dacs7.Helper;
using System.Runtime.Loader;

namespace webpac.Services
{
    public class RuntimeCompilerService : IRuntimeCompilerService
    {
        //private Dictionary<string,Assembly> 
        private readonly List<MetadataReference> _references = new List<MetadataReference>();
        private readonly List<Type> _resolvedTypes = new List<Type>();
        //private readonly ILibraryManager _libraryManager;
        //private readonly ILibraryExporter _libraryExporter;
        //private readonly IApplicationEnvironment _environment;
        //private readonly ICompilerOptionsProvider _compilerOptionsProvider;
        private readonly AssemblyLoadContext _context;
        private readonly DependencyContext _depContext;
        //private readonly CSharpCompilationOptions _compilationOptions;
        private string[] _usings;
        private string _location;
        private readonly ConcurrentDictionary<string, AssemblyMetadata> _metadataFileCache =new ConcurrentDictionary<string, AssemblyMetadata>(StringComparer.OrdinalIgnoreCase);




        #region IService Interface
        public void Configure(IConfigurationSection config)
        {
            _location = config.Get<string>("Location");
            _usings = config.Get<string[]>("Usings");
        }

        public void Init()
        {
            //Add references
            DetermineReferences();
            CompileFiles();
        }

        public void Release()
        {
            //Release all
        }
        #endregion


        public RuntimeCompilerService()
        {
            _context = AssemblyLoadContext.GetLoadContext(Assembly.GetEntryAssembly());
            _depContext = DependencyContext.Default;
        }

        public IEnumerable<Type> GetTypes()
        {
            return _resolvedTypes.ToList();
        }



        private void CompileFiles()
        {
            var codes = new List<string>();
            foreach (var item in Directory.GetFiles(_location, "*.cs"))
            {
                try
                {
                    var code = File.ReadAllText(item, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(code))
                    {
                        codes.Add(code);
                    }
                }
                catch (Exception ex)
                {
                    //Todo Handle Ex
                }
            }

            if (codes.Any())
            {
                var asm = Compile("Mappings", codes);
                if (asm != null)
                    _resolvedTypes.AddRange(asm.GetExportedTypes());
            }
        }

        private Assembly Compile(string name, List<string> codes)
        {
            if (codes == null)
                throw new ArgumentNullException("code");

            var trees = new List<SyntaxTree>();

            foreach (var code in codes)
            {
                // Parse the script to a SyntaxTree
                var syntaxTree = CSharpSyntaxTree.ParseText(code);
                var root = (CompilationUnitSyntax)syntaxTree.GetRoot();

                if (_usings.Any())
                {
                    root = root.AddUsings(_usings.Select(s => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(s))).ToArray());
                }
                trees.Add(SyntaxFactory.SyntaxTree(root));
            }


            // Compile the SyntaxTree to an in memory assembly
            var compilation = CSharpCompilation.Create(
                name,
                trees,
                _references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                );

            using (var outputStream = new MemoryStream())
            {
                using (var pdbStream = new MemoryStream())
                {
                    // Emit assembly to streams. Throw an exception if there are any compilation errors
                    var result = compilation.Emit(outputStream /*, pdbStream*/);

                    // Populate the _diagnostics property in order to read Errors and Warnings
                    //_Diagnostics = result.Diagnostics;

                    if (result.Success)
                    {
                        outputStream.Position = 0;
                        return _context.LoadFromStream(outputStream/*, pdbStream*/);
                    }
                    else
                    {
                        result.Diagnostics.ForEach(x => Console.WriteLine(x.ToString()));
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


        private void DetermineReferences()
        {
            foreach (var compilationLibrary in _depContext.CompileLibraries)
            {
                foreach (var item in compilationLibrary.ResolveReferencePaths())
                {
                    _references.Add(MetadataReference.CreateFromFile(item));
                }
            }

            //foreach (var reference in Assembly.GetEntryAssembly().GetExportedTypes().Select(x => x.)
            //{
            //    var rosRef = reference as IMetadataProjectReference;
            //    if (rosRef != null)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            rosRef.EmitReferenceAssembly(ms);
            //            if (ms.Length > 0)
            //            {
            //                ms.Seek(0, SeekOrigin.Begin);
            //                _references.Add(MetadataReference.CreateFromStream(ms));
            //            }
            //        }
            //    }
            //    else
            //    {
            //        var rosRef2 = reference as IMetadataFileReference;
            //        if (rosRef2 != null)
            //        {
            //            _references.Add(CreateMetadataFileReference(rosRef2.Path));
            //        }
            //    }
            //}
        }
    }
}

