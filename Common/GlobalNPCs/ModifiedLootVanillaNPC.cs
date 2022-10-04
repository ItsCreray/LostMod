using LostMod.Common.ItemDropRules.DropConditions;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using LostMod.Content.Items.Accessories;

namespace LostMod.Common.GlobalNPCs
{
	public class ModifiedLootVanillaNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (npc.type == NPCID.Merchant) {
				npcLoot.Add(ItemDropRule.ByCondition(new IsBloodMoon(), ModContent.ItemType<AnglerVoodooDoll>(), 8, 1));
			}
		}
	}
}
