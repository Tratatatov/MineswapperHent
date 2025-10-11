using System;
using System.IO;
using SingularityGroup.HotReload.Editor.Cli;

namespace SingularityGroup.HotReload.Editor
{
    public class ServerHealthCheck : IServerHealthCheckInternal
    {
        internal static readonly IServerHealthCheckInternal instance = new ServerHealthCheck();

        private ServerHealthCheck()
        {
        }

        public static IServerHealthCheck I => instance;
        public static TimeSpan HeartBeatTimeout { get; } = TimeSpan.FromMilliseconds(5000);

        /// <summary>
        ///     Whether or not the server is running and responsive
        /// </summary>
        public bool IsServerHealthy { get; private set; }

        void IServerHealthCheckInternal.CheckHealth()
        {
            var fi = new FileInfo(Path.Combine(CliUtils.GetCliTempDir(), "health"));
            IsServerHealthy = fi.Exists && DateTime.UtcNow - fi.LastWriteTimeUtc < HeartBeatTimeout;
        }
    }
}