namespace Strategy.Validators
{
    using System;
    using System.Text.RegularExpressions;
    using Interfaces;
    using SharpCompiler.Exceptions;

    class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string code)
        {
            var regex = @"\busing System\.Net\b";
            if (Regex.IsMatch(code, regex))
            {
                var message = string.Format("{0} is found", "using System.Net");
                throw new CompilationException(message);
            }
        }
    }
}
