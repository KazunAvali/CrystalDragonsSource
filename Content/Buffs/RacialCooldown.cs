using CrystalDragons.Content.Items.Labels;
using CrystalDragons.Content.Items.Weapons.Ranged;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystalDragons.Content.Buffs
{
    public class RacialCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Racial Cooldown");
            Description.SetDefault("Your active racial ability is on cooldown and cannot be used.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            canBeCleared = false;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.buffTime[buffIndex] == 2)
            {
                //Main.NewText("Test");

                Item label = ModContent.GetModItem(ModContent.ItemType<RacialCooldownReady>()).item;

                Main.NewText(label.Name);

                ItemText.NewText(ModContent.GetModItem(ModContent.ItemType<RustyPistol>()).item, 1, true, false);

                ItemText.NewText(label, 1, true, false);

                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
