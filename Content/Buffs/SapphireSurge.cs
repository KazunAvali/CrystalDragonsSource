using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;
using Terraria.ID;

namespace CrystalDragons.Content.Buffs
{
    public class SapphireSurge : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Surge");
            Description.SetDefault("Mana Cost is 0, considered submerged in water");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.manaCost = 0f;
            player.adjWater = true;
            player.wet = true;

            Dust dust = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<SapphireSurgeDust>(), Scale: 3);
            dust.rotation = Main.rand.NextFloat(6.28f);
            dust.customData = player;
            dust.position = player.Center + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * dust.scale * 50;

            Dust dust2 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<SapphireSurgeDust>(), Scale: 1.5f);
            dust2.rotation = Main.rand.NextFloat(6.28f);
            dust2.customData = player;
            dust2.position = player.Center + Vector2.UnitX.RotatedBy(dust2.rotation, Vector2.Zero) * dust2.scale * 50;

            Dust auraDust = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<SapphireSurgeAuraDust>(), Scale: 2);
            auraDust.rotation = Main.rand.NextFloat(6.28f);
            auraDust.customData = player;
            auraDust.position = new Vector2(player.position.X + 10, (player.position.Y + 18 + player.gfxOffY)) + Vector2.UnitX.RotatedBy(auraDust.rotation, Vector2.Zero) * (int)(30 * 1.5);

        }
    }
}
