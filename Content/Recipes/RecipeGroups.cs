using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using LostMod.Localization;

namespace LostMod.Content.Recipes
{
    public class RecipeGroups : ModSystem
    {

        public static RecipeGroup FishingInfoAccessoryRecipeGroup { get; private set; }

        public override void AddRecipeGroups()
        {
            FishingInfoAccessoryRecipeGroup = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} {ModLang.GetRecipeGroup("FishingInfoAccessory")}",
                ItemID.Sextant,
                ItemID.WeatherRadio,
                ItemID.FishermansGuide);
            RecipeGroup.RegisterGroup(ModLang.AddModNamespace("FishingInfoAccessory"), FishingInfoAccessoryRecipeGroup);
        }
    }
}
