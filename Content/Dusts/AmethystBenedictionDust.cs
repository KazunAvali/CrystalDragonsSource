using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Dusts
{
    internal class AmethystBenedictionDust : ModDust
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

            // Since the vanilla dust texture has all the dust in 1 file, we'll need to do some math.
            int desiredDustTexture = 181;
            int frameX = desiredDustTexture * 10 % 1000;
            int frameY = desiredDustTexture * 10 / 1000 * 30 + Main.rand.Next(3) * 10;
            dust.frame = new Rectangle(frameX, frameY, 8, 8);

            dust.velocity = Main.rand.NextVector2Square(-30, 30);
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }

        public override bool Update(Dust dust)
        {

            float strength = 0.5f;
            dust.position += dust.velocity;

            int oldAlpha = dust.alpha;
            dust.alpha = (int)(dust.alpha * 1.2);
            if (dust.alpha == oldAlpha)
            {
                dust.alpha++;
            }
            if (dust.alpha >= 255)
            {
                dust.alpha = 255;
                dust.velocity *= 0.5f;
                if (dust.velocity.X < 0.02f && dust.velocity.Y < 0.02f)
                {
                    dust.active = false;
                }
            }

            Lighting.AddLight(dust.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength), Main.rand.NextFloat(strength));

            return false;
        }
    }
}
