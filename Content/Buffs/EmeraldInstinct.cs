using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;
using Terraria.ID;

namespace CrystalDragons.Content.Buffs
{
    public class EmeraldInstinct : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Instinct");
            Description.SetDefault("Increased move speed, Melee/Throwing/Rogue Crit rate, apply Emerald Exploit debuff to enemies");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.2f;
            player.meleeCrit += 50;
            player.thrownCrit += 50;

            //Mod calamity = ModLoader.GetMod("CalamityMod");

            int offset = 0;

            if (player.miscCounter > 150)
            {
                offset = (150 - (player.miscCounter - 150)) / 5;
            }
            else
            {
                offset = player.miscCounter / 5;
            }


            float num8 = (float)player.miscCounter / 40f;
            float num7 = 1.0471975512f * 2;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Vector2 rotationVector = (player.Center + (num8 * 6.28318548f + num7 * (float)i).ToRotationVector2() * player.width);

                    Dust dust = Dust.NewDustPerfect(new Vector2(rotationVector.X, player.position.Y + 50), 61, new Vector2(0, -7f), Scale: 2); 
                    dust.noGravity = true;
                }
            }

            //Vector2 position = new Vector2(player.position.X + offset, player.position.Y + 20);

            //Dust dust = Dust.NewDustPerfect(position, DustID.CursedTorch, new Vector2(0, -5f), Scale: 2);
            //dust.noGravity = true;
        }
    }
}
