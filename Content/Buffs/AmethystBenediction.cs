using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;

namespace CrystalDragons.Content.Buffs
{
    public class AmethystBenediction : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            float strength = 0.1f;

            Dust dust = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
            Dust dust2 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
            Dust dust3 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
            Dust dust4 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
            Dust dust5 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
            Dust dust6 = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystBenedictionDust>(), 5f, 5f);
        }
    }
}
