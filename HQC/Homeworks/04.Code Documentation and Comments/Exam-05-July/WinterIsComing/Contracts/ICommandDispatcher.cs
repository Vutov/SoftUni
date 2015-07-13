namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Handles commands.
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Gets or sets the Engine
        /// </summary>
        IEngine Engine { get; set; }

        /// <summary>
        /// Dispatches the appropriate command depending on the input.
        /// </summary>
        /// <param name="commandArgs">Given input</param>
        void DispatchCommand(string[] commandArgs);

        /// <summary>
        /// Predefine all acceptable commands.
        /// </summary>
        void SeedCommands();
    }
}
