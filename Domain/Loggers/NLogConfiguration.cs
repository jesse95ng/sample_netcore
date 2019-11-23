using NLog;

namespace sample_netcore.Domain.Loggers
{
    /// <summary>
    /// Nlog configuration
    /// </summary>
    public class NLogConfiguration : INLogConfiguration
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogConfiguration"/> class.
        /// </summary>
        public NLogConfiguration()
        {

        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Information(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
