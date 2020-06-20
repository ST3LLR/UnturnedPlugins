using System.Reflection;

using SDG.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;

using UnityEngine;

namespace ST3LLR.ClockEvents
{
    class ClockEvents : RocketPlugin<ClockEventsConfiguration>
    {
        public static ClockEvents Instance;

        uint prevTime;

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

        void FixedUpdate()
        {
            if (prevTime != LightingManager.time)
            {
                foreach (Event check in Configuration.Instance.Events)
                {
                    if (check.time == LightingManager.time)
                    {
                        if (check.message != "")
                        {
                            UnturnedChat.Say(check.message, UnturnedChat.GetColorFromName(check.color, Color.green));
                        }

                        if (check.command != "")
                        {
                            CommandWindow.input.onInputText?.Invoke(check.command);
                        }
                        break;
                    }
                }
                prevTime = LightingManager.time;
            }
        }
    }
}