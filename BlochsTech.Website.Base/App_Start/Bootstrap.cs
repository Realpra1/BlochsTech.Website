using NLog;

namespace BlochsTech.Website.Base
{
    /// <summary>
    ///   Bootstrap Nlog get method helper class.
    /// </summary>
    public static class Bootstrap
    {
        /// <summary>
        /// Initializes the <see cref="Bootstrap"/> class.
        /// </summary>
        static Bootstrap()
        {
            Log = LogManager.GetCurrentClassLogger();
        }

        public static Logger Log { get; private set; }
    }

}