using System.Threading.Tasks;

namespace SingularityGroup.HotReload.Editor.Cli
{
    internal class FallbackCliController : ICliController
    {
        public string BinaryFileName => "";
        public string PlatformName => "";
        public bool CanOpenInBackground => false;

        public Task Start(StartArgs args)
        {
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}