using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Dusts
{
    internal class AmethystHealingDust : ModDust
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

        public override bool Update(Dust dust)
        {
            dust.scale -= 0.05f;

            float strength = 0.1f;

            //Adding light to aura if in hard mode
            if (Main.hardMode)
            {
                Lighting.AddLight(dust.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength), Main.rand.NextFloat(strength));
            }

            // Here we make sure to kill any dust that get really small so it doesn't stay around forever
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}