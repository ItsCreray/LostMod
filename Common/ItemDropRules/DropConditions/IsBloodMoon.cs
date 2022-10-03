using LostMod.Localization;
using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace LostMod.Common.ItemDropRules.DropConditions
{
	public class IsBloodMoon : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info) {
			return Main.bloodMoon && !info.IsInSimulation;
		}

		public bool CanShowItemDropInUI() {
			return true;
		}

		public string GetConditionDescription() {
			return ModLang.GetItemDropConditionDescription(nameof(IsBloodMoon));
		}
	}
}
