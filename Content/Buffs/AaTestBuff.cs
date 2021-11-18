using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystalDragons.Content.Buffs
{
    public class AaTestBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Test Buff");
            Description.SetDefault("For testing.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            canBeCleared = true;
            Main.persistentBuff[Type] = true;
        }
    }
}
