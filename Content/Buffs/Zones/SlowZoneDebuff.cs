using Terraria;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Buffs.Zones
{
    public class SlowZoneDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Slow Zone");
            Main.buffNoTimeDisplay[Type] = false;
            Main.pvpBuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.knockBackResist > 0f)
            {
                //Originally was just X 0.9 but a 10% slow felt too meh, so I buffed it to 50% for normal, 20% bosses.
                npc.velocity.X *= .75f;
                npc.velocity.Y *= .75f;
                Player player = Main.LocalPlayer;

                if (Main.rand.NextBool(5))
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 172);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale *= 1.1f;
                }
            }
        }
    }

    public class SlowZoneDebuffBoss : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Slow Zone (But for bosses)");
            Main.buffNoTimeDisplay[Type] = false;
            Main.pvpBuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.knockBackResist > 0f)
            {
                npc.velocity.X *= .80f;
                npc.velocity.Y *= .80f;
                Player player = Main.LocalPlayer;

                if (Main.rand.NextBool(5))
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 172);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale *= 1.1f;
                }
            }
        }
    }
}