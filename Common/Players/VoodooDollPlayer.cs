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
            return CanHitNPCSomehow(target);
        }

        public override bool? CanHitNPCWithProj(Projectile proj, NPC target)
        {
            return CanHitNPCSomehow(target);
        }

        public override void ResetEffects()
        {
            _canKillAngler = false;
        }

        private bool? CanHitNPCSomehow(NPC target) {
            if (target.type == NPCID.Angler && target.immune[Player.whoAmI] == 0) {
                return _canKillAngler;
            }
            return null;
        }
    }
}
