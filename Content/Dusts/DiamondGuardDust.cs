﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CrystalDragons.Content.Buffs;

namespace CrystalDragons.Content.Dusts
{
    // This Dust will show off Dust.customData, using vanilla dust texture, and some neat movement.
    internal class DiamondGuardDust : ModDust
    {
        /*
			Spawning this dust is a little more involved because we need to assign a rotation, customData, and fix the position. 
			Position must be fixed here because otherwise the first time the dust is drawn it'll draw in the incorrect place.
			This dust is not used in ExampleMod yet, so you'll have to add some code somewhere. Try ExamplePlayer.DrawEffects.

			Dust dust = Dust.NewDustDirect(player.Center, 0, 0, DustType<Dusts.AdvancedDust>(), Scale: 2);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.customData = player;
			dust.position = player.Center + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * dust.scale * 50;
		*/
        public override bool Autoload(ref string name, ref string texture)
        {
            // By setting this to null, this dust will use the vanilla dust monolithic texture
            texture = null;
            return base.Autoload(ref name, ref texture);
        }

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;

            //dust.GetAlpha(Color.LightGreen);

            dust.scale = 1f;
            //dust.alpha = 150;

            // Since the vanilla dust texture has all the dust in 1 file, we'll need to do some math.
            //178
            int desiredDustTexture = 230;
            int frameX = desiredDustTexture * 10 % 1000;
            int frameY = desiredDustTexture * 10 / 1000 * 30 + Main.rand.Next(3) * 10;
            dust.frame = new Rectangle(frameX, frameY, 8, 8);

            dust.velocity = Vector2.Zero;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }

        // This Update method shows off some interesting movement. Using customData assigned to a Player, we spiral around the Player while slowly getting closer. In practice, it looks like a vortex.
        public override bool Update(Dust dust)
        {
            // Here we rotate and scale down the dust. The dustIndex % 2 == 0 part lets half the dust rotate clockwise and the other half counter clockwise
            dust.rotation += 0.1f * (dust.dustIndex % 2 == 0 ? -1 : 1);
            dust.scale -= 0.01f;

            int timeLeft = 0;

            // Here we use the customData field. If customrData is the type we expect, Player, we do some special movement.
            if (dust.customData != null && dust.customData is Player player)
            {
                float strength = 0.7f;

                if (player.HasBuff(ModContent.BuffType<DiamondGuard>()))
                {
                    timeLeft = player.buffTime[player.FindBuffIndex(ModContent.BuffType<DiamondGuard>())];
                }

                //dust.scale *= (timeLeft / 600);
                dust.position = player.Center + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * (timeLeft/20);

                Lighting.AddLight(dust.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength*0.3f), Main.rand.NextFloat(strength));
                Lighting.AddLight(player.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength*0.3f), Main.rand.NextFloat(strength));
            }
            // Here we make sure to kill any dust that get really small.
            if (dust.scale < 0.1f || timeLeft == 0)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
