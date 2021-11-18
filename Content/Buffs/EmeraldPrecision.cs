using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;

namespace CrystalDragons.Content.Buffs
{
    public class EmeraldPrecision1 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 1");
            Description.SetDefault("Gaining +2% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.02f;
            player.thrownDamage += 0.02f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.02f);
            }          
        }
    }

    public class EmeraldPrecision2 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 2");
            Description.SetDefault("Gaining +4% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.04f;
            player.thrownDamage += 0.04f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.04f);
            }
        }
    }

    public class EmeraldPrecision3 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 3");
            Description.SetDefault("Gaining +6% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.06f;
            player.thrownDamage += 0.06f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.06f);
            }
        }
    }

    public class EmeraldPrecision4 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 4");
            Description.SetDefault("Gaining +8% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.08f;
            player.thrownDamage += 0.08f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.08f);
            }
        }
    }

    public class EmeraldPrecision5 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 5");
            Description.SetDefault("Gaining +10% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.10f;
            player.thrownDamage += 0.10f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.10f);
            }
        }
    }

    public class EmeraldPrecision6 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 6");
            Description.SetDefault("Gaining +12% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.12f;
            player.thrownDamage += 0.12f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.12f);
            }
        }
    }

    public class EmeraldPrecision7 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 7");
            Description.SetDefault("Gaining +14% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.14f;
            player.thrownDamage += 0.14f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.14f);
            }
        }
    }

    public class EmeraldPrecision8 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 8");
            Description.SetDefault("Gaining +16% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.16f;
            player.thrownDamage += 0.16f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.16f);
            }
        }
    }

    public class EmeraldPrecision9 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 9");
            Description.SetDefault("Gaining +18% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.18f;
            player.thrownDamage += 0.18f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.18f);
            }
        }
    }

    public class EmeraldPrecision10 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 10");
            Description.SetDefault("Gaining +20% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.20f;
            player.thrownDamage += 0.20f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.20f);
            }
        }
    }

    public class EmeraldPrecision11 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 11");
            Description.SetDefault("Gaining +22% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.22f;
            player.thrownDamage += 0.22f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.22f);
            }
        }
    }

    public class EmeraldPrecision12 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 12");
            Description.SetDefault("Gaining +24% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.24f;
            player.thrownDamage += 0.24f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.24f);
            }
        }
    }

    public class EmeraldPrecision13 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 13");
            Description.SetDefault("Gaining +26% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.26f;
            player.thrownDamage += 0.26f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.26f);
            }
        }
    }

    public class EmeraldPrecision14 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 14");
            Description.SetDefault("Gaining +28% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--; 

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.28f;
            player.thrownDamage += 0.28f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.28f);
            }
        }
    }

    public class EmeraldPrecision15 : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Precision 15");
            Description.SetDefault("Gaining +30% to Melee/Throwing/Rogue damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (player.buffTime[buffIndex] == 2)
            {
                crystalPlayer.emeraldPrecisionCount--;

                if (crystalPlayer.emeraldPrecisionCount != 0)
                {
                    crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
                }

                player.DelBuff(buffIndex);
                buffIndex--;
            }

            player.meleeDamage += 0.30f;
            player.thrownDamage += 0.30f;

            if (calamity != null && player.active)
            {
                //calamity.Call("AddRogueDamage", player.whoAmI, 0.30f);
            }
        }
    }

    //public static class EmeraldPrecisionHelpers
    //{
    //    public static void RemoveStackIfTimeUp(Player player, int Type, ref int buffIndex)
    //    {
    //        var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

    //        if (player.buffTime[buffIndex] == 2)
    //        {
    //            crystalPlayer.emeraldPrecisionCount--;

    //            if (crystalPlayer.emeraldPrecisionCount != 0)
    //            {
    //                crystalPlayer.ApplyEmeraldPrecision(crystalPlayer.emeraldPrecisionCount, player);
    //            }

    //            player.DelBuff(buffIndex);
    //            buffIndex--;
    //        }
    //    }
    //}
}
