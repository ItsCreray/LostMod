using Terraria;
using Terraria.ModLoader;

namespace LostMod.Common.GlobalNPCs
{
    public partial class VoodooDollAffectedNPC : GlobalNPC
    {
        public bool IsVoodooooDollAffected { get; set; } = false;

        public override void OnKill(NPC npc) {
            IsVoodooooDollAffected = false;
        }
    }
}
