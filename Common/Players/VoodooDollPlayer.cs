using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LostMod.Utils;
using LostMod.Common.GlobalNPCs;

namespace LostMod.Common.Players
{
    public class VoodooDollPlayer : ModPlayer
    {
        private bool _canKillAnglerTickFlag = false; // I use this because there is no OnAccessoryEquipped/OnAccessoryRemoved hook :c
        private bool _isAnglerVoodooDollEquipped = false;
        private static NPC _angler = null;

        private static void AffectNewNPCIfOldInvalid(ref NPC npc, int npcType) {
            bool isNpcInvalid = npc is null || !npc.active;
            if (isNpcInvalid) {
                npc = NPCUtils.SearchFirstWithType(npcType);
                TrySetNPCVoodooDollAffectedStatus(ref npc, true);
            }
        }

        private static void TrySetNPCVoodooDollAffectedStatus(ref NPC npc, bool isAffected) {
            if (npc is not null) {
                VoodooDollAffectedNPC voodooDollAffectedNPC = npc.GetGlobalNPC<VoodooDollAffectedNPC>();
                voodooDollAffectedNPC.IsVoodooooDollAffected = isAffected;
            }
        }

	public void AllowKillAngler() {
            AffectNewNPCIfOldInvalid(ref _angler, NPCID.Angler);

	    if (!_isAnglerVoodooDollEquipped) {
                _isAnglerVoodooDollEquipped = true;
                TrySetNPCVoodooDollAffectedStatus(ref _angler, true);
            }

            _canKillAnglerTickFlag = true;
        }

        public override bool? CanHitNPC(Item item, NPC target) {
            return IsAffectedByVoodooDoll(target) ?
                true : null;
        }

        public override bool? CanHitNPCWithProj(Projectile proj, NPC target) {
            return IsAffectedByVoodooDoll(target) ?
                target.immune[Player.whoAmI] == 0 : null;
        }

        private bool IsAffectedByVoodooDoll(NPC target) {
            return _isAnglerVoodooDollEquipped && target.type == NPCID.Angler;
        }

        public override void ResetEffects() {
            bool isAnglerVoodooDollAccessoryRemoved = !_canKillAnglerTickFlag && _isAnglerVoodooDollEquipped;
			if (isAnglerVoodooDollAccessoryRemoved) {
                _isAnglerVoodooDollEquipped = false;
                TrySetNPCVoodooDollAffectedStatus(ref _angler, false);
            }
            _canKillAnglerTickFlag = false;
        }
    }
}
