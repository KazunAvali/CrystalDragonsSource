using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;
using CrystalDragons.Config;
using Terraria.ModLoader.Config;

namespace CrystalDragons.Content.Buffs
{
    public class AmethystHealOrigin : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Healing");
            Description.SetDefault("You're providing passive healing to all players in your healing radius");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //This is for Amethyst-specific bonus healing, if I want it to have less effectivenss on Amethyst I can exclude in the actual heal but include here.
            //if (!Main.hardMode)
            //{
            //    player.lifeRegenCount += 3;
            //}
            //else
            //{
            //    player.lifeRegenCount += 6;
            //}

            if (ModContent.GetInstance<CrystalDragonsConfigClient>().AmeAuraVisible)
            {
                Dust dust = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<AmethystHealAuraDust>(), Scale: 1);
                dust.rotation = Main.rand.NextFloat(6.28f);
                dust.customData = player;

                dust.position = new Vector2(player.position.X + 10, (player.position.Y + 18 + player.gfxOffY)) + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * (int)(player.statManaMax2 * 1.5);
            }
        }
    }
}
