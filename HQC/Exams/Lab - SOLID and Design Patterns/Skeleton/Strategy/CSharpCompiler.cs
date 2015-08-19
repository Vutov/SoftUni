namespace SharpCompiler
{
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text;

    using Microsoft.CSharp;

    using Exceptions;
    using Strategy.Interfaces;

    public class CSharpCompiler
    {
        private CompilerResults compiledProgram;
        private CompilerParameters compilerParameters;
        private CSharpCodeProvider csharpCodeProvider;

        public CSharpCompiler(ICodeValidationStrategy strategy = null)
        {
            this.Strategy = strategy;
        }

        public ICodeValidationStrategy Strategy { get; private set; }

        public void Compile(string codeString)
        {
            this.Preprocess(codeString);

            if (this.compilerParameters == null)
            {
                this.compilerParameters = InitializeCompilerParameters();
            }

            if (this.csharpCodeProvider == null)
            {
                this.csharpCodeProvider = new CSharpCodeProvider();
            }

            this.compiledProgram = this.csharpCodeProvider.CompileAssemblyFromSource(
                this.compilerParameters, codeString);

            // Check for compilation errors
            if (this.compiledProgram.Errors.HasErrors)
            {
                var errorMsg = new StringBuilder();
                foreach (CompilerError ce in this.compiledProgram.Errors)
                {
                    errorMsg.AppendLine(ce.ToString());
                }

                throw new CompilationException(errorMsg.ToString());
            }
        }

        private static CompilerParameters InitializeCompilerParameters()
        {
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            return compilerParams;
        }

        public void Execute(string entryClassName)
        {
            Assembly assembly = this.compiledProgram.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType(entryClassName);
            MethodInfo methInfo = type.GetMethod("Main");

            methInfo.Invoke(null, null);
        }

        protected void Preprocess(string codeString)
        {
            if (this.Strategy != null)
            {
                this.Strategy.Validate(codeString);
            }
        }
    }
}
