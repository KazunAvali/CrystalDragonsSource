using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Dusts
{
    // This Dust will show off Dust.customData, using vanilla dust texture, and some neat movement.
    internal class AmethystHealAuraDust : ModDust
    {
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

            dust.scale = 1f;

            // Since the vanilla dust texture has all the dust in 1 file, we'll need to do some math.
            //178
            int desiredDustTexture = 178;
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

            // Here we use the customData field. If customrData is the type we expect, Player, we do some special movement.
            if (dust.customData != null && dust.customData is Player player)
            {
                float strength = 0.1f;

                // Here we assign position to some offset from the player that was assigned. This offset scales with dust.scale. The scale and rotation cause the spiral movement we desired.
                dust.position = new Vector2(player.position.X + 10, (player.position.Y + 18 + player.gfxOffY)) + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * (int)(player.statManaMax2 * 1.5);

                //Adding light if in hard mode
                if(Main.hardMode)
                {
                    Lighting.AddLight(dust.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength), Main.rand.NextFloat(strength));
                    Lighting.AddLight(player.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength), Main.rand.NextFloat(strength));
                }
            }

            // Here we make sure to kill any dust that get really small.
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
