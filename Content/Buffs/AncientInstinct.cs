using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;

namespace CrystalDragons.Content.Buffs
{
    public class AncientInstinct : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Instinct");
            Description.SetDefault("Increased attack speed, movement speed, ranged crit chance, and immune to fall damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.2f;
            player.maxRunSpeed += 0.2f;
            player.rangedCrit += 20;
            player.noFallDmg = true;

            //Spawn long-lasting red dust on his eye to make a trail
        }
    }
}
