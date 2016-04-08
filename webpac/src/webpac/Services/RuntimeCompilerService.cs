using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webpac.Services
{
    public class RuntimeCompilerService
    {
        private Dictionary<string,Assembly> 
        private readonly IEnumerable<MetadataReference> _references;


        public RuntimeCompilerService(IEnumerable<MetadataReference> references)
        {
            _references = references;
        }

        public Type Compile(string code)
        {
            if (code == null)
                throw new ArgumentNullException("script");

            string outputAssemblyName = "";

            // Parse the script to a SyntaxTree
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Compile the SyntaxTree to an in memory assembly
            var compilation = CSharpCompilation.Create(
                outputAssemblyName,
                new[] { syntaxTree },
                _references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));


            //using (var outputStream = new MemoryStream())
            //{
            //    using (var pdbStream = new MemoryStream())
            //    {
            //        // Emit assembly to streams. Throw an exception if there are any compilation errors
            //        var result = compilation.Emit(outputStream, pdbStream: pdbStream);

            //        // Populate the _diagnostics property in order to read Errors and Warnings
            //        _Diagnostics = result.Diagnostics;

            //        if (result.Success)
            //        {
            //            return Assembly.Load(outputStream.ToArray(), pdbStream.ToArray());
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //}
        }

    }
}
