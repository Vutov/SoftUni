namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Reader for input.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Handles next line of input.
        /// </summary>
        /// <returns>String of the input</returns>
        string ReadNextLine();
    }
}
