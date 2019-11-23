namespace sample_netcore.Domain.Loggers
{
    /// <summary>
    /// Intefac nlog configuration
    /// </summary>
    public interface INLogConfiguration
    {
        void Information(string message);

        void Warning(string message);

        void Debug(string message);

        void Error(string message);
    }
}
