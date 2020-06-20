using Rocket.Core.Plugins;
using System.Reflection;

namespace ST3LLR.Template
{
    class Template : RocketPlugin<TemplateConfiguration>
    {
        public static Template Instance;

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log(" Version " + Assembly.GetExecutingAssembly().GetName().Version + " loaded.");
        }

        protected override void Unload()
        {
            Instance = null;
            Rocket.Core.Logging.Logger.Log(" Version " + Assembly.GetExecutingAssembly().GetName().Version + " unloaded.");
        }
    }
}