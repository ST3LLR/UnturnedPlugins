using Rocket.Core.Plugins;
using System;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using UnityEngine;

/* Future Plans:
 * Add Translations
 */

namespace ST3LLR.ThePurge
{
    class ThePurge : RocketPlugin<ThePurgeConfiguration>
    {
        public static ThePurge Instance;

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("ThePurge has been loaded!");
        }

        protected override void Unload()
        {
            Instance = null;
            Rocket.Core.Logging.Logger.Log("ThePurge has been unloaded!");
        }

        void FixedUpdate()
        {
            try
            {
                if (State == Rocket.API.PluginState.Loaded)
                {
                    if (LightingManager.time > 2200 && (Provider.isPvP == false))
                    {
                        Provider.isPvP = true;
                        UnturnedChat.Say("The Purge Has Begun!"?.ToString() ?? "null", Color.cyan);
                    }
                    else if (LightingManager.time < 2200 && (Provider.isPvP == true))
                    {
                        Provider.isPvP = false;
                        UnturnedChat.Say("The Purge Has Ended!"?.ToString() ?? "null", Color.cyan);
                    }
                }
            }
            catch (Exception ex)
            {
                Rocket.Core.Logging.Logger.LogException(ex);
            }
        }
    }
}