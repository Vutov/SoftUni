namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Command Interface containing Engine and Execute
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the Engine
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// Depending on the command makes certain logic using the Engine.
        /// </summary>
        /// <param name="commandArgs">Input field for the execution</param>
        void Execute(string[] commandArgs);
    }
}
