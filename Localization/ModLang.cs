using System;
using Terraria.Localization;

namespace LostMod.Localization
{
    public static class ModLang {

        public static Func<string> GetRecipeGroupCraftTooltip(string recipeGroupName) {
            return () => $"{Language.GetTextValue("LegacyMisc.37")} {ModLang.GetRecipeGroup(recipeGroupName)}";
        }

        public static LocalizedText GetRecipeGroup(string recipeGroupName) {
            return Language.GetText($"Mods.{nameof(LostMod)}.RecipeGroup.{recipeGroupName}");
        }

        public static string AddModNamespace(string key) {
            return $"{nameof(LostMod)}:{key}";
        }
    }
}
