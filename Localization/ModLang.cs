using Terraria;
using Terraria.Localization;

namespace LostMod.Localization
{
    public class ModLang
    {
        public static LocalizedText GetRecipeGroup(string recipeGroupName)
        {
            return Language.GetText($"Mods.{nameof(LostMod)}.RecipeGroup.{recipeGroupName}");
        }

        public static string AddModNamespace(string key) {
            return $"{nameof(LostMod)}:{key}";
        }
    }
}
