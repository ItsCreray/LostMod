using LostMod.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace LostMod.Common.GlobalNPCs
{
    public partial class VoodooDollAffectedNPC : GlobalNPC
    {
        private static readonly Vector2[] EffectOffsetDirection;

        private const int MaxEffectTime = 15;
        private const int MaxShadowEffectDistance = 7;

        private const float MinShadowOpacity = 0.2f;
        private const float MaxOpacityOffset = 0.4f;

        private int _effectTime = 0;
        private bool _reverseEffectTime = false;
        private int _shadowRotationDirection = 1;

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            if (VoodooDollPlayer.IsAnyoneHoldingAnglerVoodooDoll) {
                DrawIllusions(npc, spriteBatch, screenPos, drawColor);
                UpdateEffectTime();
            }
            return true;
        }

        private void DrawIllusions(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Vector2 drawOrigin = npc.frame.Size() / 2;
            Vector2 drawPositionOrigin = npc.Center - screenPos;

            drawOrigin.Y += 2;

            float effectTimeFactor = (float)_effectTime / MaxEffectTime;
            float shadowEffectDistance = effectTimeFactor * MaxShadowEffectDistance;

            Color modifiedDrawColor = npc.GetAlpha(drawColor) * (MinShadowOpacity + (MaxOpacityOffset * (1 - effectTimeFactor)));

            for (int i = 0; i < 4; i++) {
                Vector2 rotatedOffsetDirection = EffectOffsetDirection[i].RotatedBy(Math.PI * _shadowRotationDirection * effectTimeFactor);
                Vector2 drawPosition = drawPositionOrigin + (shadowEffectDistance * rotatedOffsetDirection);

                spriteBatch.Draw(TextureAssets.Npc[npc.type].Value, drawPosition, npc.frame, modifiedDrawColor, npc.rotation, drawOrigin, 1f, effects, 0f);
            }
        }

        private void UpdateEffectTime() {
            if (_reverseEffectTime) {
                _effectTime--;
                if (_effectTime < 0) {
                    _reverseEffectTime = false;
                    _effectTime = 0;
                    _shadowRotationDirection *= -1;
                }
            }
            else {
                _effectTime++;
                if (_effectTime > MaxEffectTime) {
                    _reverseEffectTime = true;
                    _effectTime = MaxEffectTime;
                }
            }
        }

        static VoodooDollAffectedNPC() {
            EffectOffsetDirection = new Vector2[4] {
                new Vector2(0, 1),
                new Vector2(1, 0),
                new Vector2(0, -1),
                new Vector2(-1, 0),
            };
        }
    }
}
