using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;

namespace CrystalDragons.Content.Buffs
{
    public class AmethystHealing : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Healing");
            Description.SetDefault("An Amethyst Dragon is healing you with their passive aura!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            if (!Main.hardMode)
            {
                //base +3 for pre-HM
                player.lifeRegenCount += 3;

                //bonus of +1 to +5 for Amethyst Gem Boost buff
                for (int i = 1; i < 6; i++)
                {
                    if (player.HasBuff(mod.BuffType("AmethystGemBoost" + i)))
                    {
                        player.lifeRegenCount += i;
                    }
                }
            }
            else
            {
                //base +6 for hard mode
                player.lifeRegenCount += 6;

                //bonus of +1 to +5 for Amethyst Gem Boost buff
                for (int i = 1; i < 6; i++)
                {
                    if (player.HasBuff(mod.BuffType("AmethystGemBoost" + i)))
                    {
                        player.lifeRegenCount += i;
                    }
                }
            }

            float strength = 0.1f;

            //fix distance so it matches aura and the actual particles so they dont fly out

            Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<AmethystHealingDust>(), 0f, 0f);
            dust.noGravity = true;


            if (Main.hardMode)
            {
                Lighting.AddLight(dust.position, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength), Main.rand.NextFloat(strength));
            }
        }
    }
}
