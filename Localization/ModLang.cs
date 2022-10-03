using System;
using Terraria.Localization;

namespace LostMod.Localization
{
    public static class ModLang
    {
        #region Common

        public static string AddModNamespace(string key) {
            return $"{nameof(LostMod)}:{key}";
        }

        #endregion

        #region RecipeGroups

        public static Func<string> GetRecipeGroupNameDelegate(string recipeGroupName) {
            return () => $"{Language.GetTextValue("LegacyMisc.37")} {GetRecipeGroupName(recipeGroupName)}";
        }

        public static LocalizedText GetRecipeGroupName(string recipeGroupName) {
            return Language.GetText($"Mods.{nameof(LostMod)}.RecipeGroup.{recipeGroupName}");
        }

        #endregion
    }
}
