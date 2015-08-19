namespace Strategy.Validators
{
    using System.Text.RegularExpressions;
    using Interfaces;
    using SharpCompiler.Exceptions;

    public class CodeLengthValidator : ICodeValidationStrategy
    {
        public void Validate(string code)
        {
            var regex = @"[\s\S]{20,}";
            if (!Regex.IsMatch(code, regex))
            {
                throw new CompilationException("Code is less than 20 chars!");
            }
        }
    }
}
