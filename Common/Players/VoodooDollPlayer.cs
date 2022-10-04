using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LostMod.Common.Players
{
	public class VoodooDollPlayer : ModPlayer
	{
		public static bool IsAnyoneHoldingAnglerVoodooDoll { get; private set; } = false; // I use it like this, because there is no OnAccessoryEquipped/OnAccessoryRemovedHook
		private bool _canKillAngler = false;

		public void AllowKillAngler() {
			_canKillAngler = true;
			IsAnyoneHoldingAnglerVoodooDoll = true;
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
			return _canKillAngler && target.type == NPCID.Angler;
		}

		public override void ResetEffects() {
			_canKillAngler = false;
			IsAnyoneHoldingAnglerVoodooDoll = false;
		}
	}
}
