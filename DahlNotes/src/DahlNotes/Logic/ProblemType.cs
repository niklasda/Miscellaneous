namespace DahlNotes.Logic
{
    /// <summary>
    /// Reasons for shutting down prematurely
    /// </summary>
    public enum ProblemType
    {
        /// <summary>
        /// No problem, don't shutdown
        /// </summary>
        None,

        /// <summary>
        /// Settings file is read-only
        /// </summary>
        SettingsReadOnly, 

        /// <summary>
        /// System is shutting down, because of logging off, restart, shutdown
        /// </summary>
        SystemShuttingDown, 

        /// <summary>
        /// DahlNotes is already running
        /// </summary>
        AlreadyRunning
    }
}