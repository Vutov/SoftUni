namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Handles all output.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Gets input line and writes it.
        /// </summary>
        /// <param name="line">Given line</param>
        void Write(string line);

        /// <summary>
        /// Flushes all lines.
        /// </summary>
        void Flush();
    }
}
