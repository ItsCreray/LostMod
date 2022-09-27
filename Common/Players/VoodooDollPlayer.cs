using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LostMod.Common.Players
{
    public class VoodooDollPlayer : ModPlayer
    {
        private bool _canKillAngler = false;
        
        public void AllowKillAngler() {
            _canKillAngler = true;
        }

        public override bool? CanHitNPC(Item item, NPC target)
        {
            return IsAffectedByVoodooDoll(target);
        }

        public override bool? CanHitNPCWithProj(Projectile proj, NPC target)
        {
            bool? canHit = IsAffectedByVoodooDoll(target);
            if (canHit == true) {
                return target.immune[Player.whoAmI] == 0;
            }
            return canHit;
        }

        private bool IsAffectedByVoodooDoll(NPC target)
        {
            return _canKillAngler && target.type == NPCID.Angler;
        }

        public override void ResetEffects()
        {
            _canKillAngler = false;
        }
    }
}
