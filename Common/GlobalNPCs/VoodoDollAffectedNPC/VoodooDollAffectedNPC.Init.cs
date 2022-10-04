using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LostMod.Common.GlobalNPCs
{
    public partial class VoodooDollAffectedNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) {
            return entity.type == NPCID.Angler;
        }
    }
}
