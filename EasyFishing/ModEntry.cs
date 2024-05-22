using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace EasyFishing
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
            Monitor.Log("Easy Fishing Mod loaded", LogLevel.Info);
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (Game1.player.CurrentTool is StardewValley.Tools.FishingRod fishingRod)
            {
                if (fishingRod.isFishing && fishingRod.hit)
                {
                    if (fishingRod.timeUntilFishingBite > 0)
                    {
                        fishingRod.timeUntilFishingBite = 0;
                    }
                    fishingRod.castingPower = 1f;
                    fishingRod.isReeling = true;
                    fishingRod.fishCaught = true;
                }
            }
        }
    }
}