using LostMod.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LostMod.Content.Recipes
{
    public class RecipeGroups : ModSystem
    {

        public static RecipeGroup FishingInfoAccessoryRecipeGroup { get; private set; }

        public override void AddRecipeGroups() {
            string recipeGroupName = "FishingInfoAccessory";
            FishingInfoAccessoryRecipeGroup = new RecipeGroup(
                ModLang.GetRecipeGroupNameDelegate(recipeGroupName),
                ItemID.Sextant,
                ItemID.WeatherRadio,
                ItemID.FishermansGuide);
            RecipeGroup.RegisterGroup(ModLang.AddModNamespace(recipeGroupName), FishingInfoAccessoryRecipeGroup);
        }
    }
}
