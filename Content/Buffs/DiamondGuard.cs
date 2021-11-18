using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;
using Terraria.ID;

namespace CrystalDragons.Content.Buffs
{
    public class DiamondGuard : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Guard");
            Description.SetDefault("You are invulnerable to damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.noFallDmg = true;
            player.aggro += 800;

            //debug for drunk testing
            //player.buffImmune[BuffID.Tipsy] = true;

            float strength = 0.5f;

            Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<DiamondGuardDust>(), 0f, 0f);
            dust.noGravity = true;
            dust.rotation = Main.rand.NextFloat(6.28f);
            dust.customData = player;


            Dust dust2 = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<DiamondGuardDust2>(), 0f, 0f);
            dust2.noGravity = true;
            dust2.rotation = Main.rand.NextFloat(6.28f);
            dust2.customData = player;

            Lighting.AddLight(player.Center, Main.rand.NextFloat(strength), Main.rand.NextFloat(strength*0.3f), Main.rand.NextFloat(strength));

            //Main.PlaySound(SoundID.Pixie, player.Center);
            //Item 30 for  start sound? or 130 for a "bubble shield"?
            //Pixie for continuous?
            //Item 25 for end?
        }
    }
}
