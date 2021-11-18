using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Dusts;

namespace CrystalDragons.Content.Buffs.GemBoosts
{
    //Amethyst
    public class AmethystGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Boost 1");
            Description.SetDefault("Gaining +1 to Amethyst Aura healing.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmethystGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Boost 2");
            Description.SetDefault("Gaining +2 to Amethyst Aura healing.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmethystGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Boost 3");
            Description.SetDefault("Gaining +3 to Amethyst Aura healing.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmethystGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Boost 4");
            Description.SetDefault("Gaining +4 to Amethyst Aura healing.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmethystGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amethyst Boost 5");
            Description.SetDefault("Gaining +5 to Amethyst Aura healing.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    //Diamond
    public class DiamondGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Boost 1");
            Description.SetDefault("Gaining -2% additional Damage Reduction.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.endurance += 0.02f;
        }
    }

    public class DiamondGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Boost 2");
            Description.SetDefault("Gaining -4% additional Damage Reduction.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.endurance += 0.04f;
        }
    }

    public class DiamondGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Boost 3");
            Description.SetDefault("Gaining -6% additional Damage Reduction.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.endurance += 0.06f;
        }
    }

    public class DiamondGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Boost 4");
            Description.SetDefault("Gaining -8% additional Damage Reduction.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.endurance += 0.08f;
        }
    }

    public class DiamondGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Diamond Boost 5");
            Description.SetDefault("Gaining -10% additional Damage Reduction.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.endurance += 0.1f;
        }
    }

    //Topaz
    public class TopazGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Boost 1");
            Description.SetDefault("Gaining +2.5% chance to roll a rare prefix (~18.5% total).");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class TopazGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Boost 2");
            Description.SetDefault("Gaining +5% chance to roll a rare prefix (~21% total).");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class TopazGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Boost 3");
            Description.SetDefault("Gaining +7.5% chance to roll a rare prefix (~23.5% total).");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class TopazGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Boost 4");
            Description.SetDefault("Gaining +10% chance to roll a rare prefix (~26% total).");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class TopazGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Boost 5");
            Description.SetDefault("Gaining +12.5% chance to roll a rare prefix (~28.5% total). Boosts Legendary prefix chance from 0.5% → 0.8%!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    //Amber
    public class AmberGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Boost 1");
            Description.SetDefault("Gaining +4% additional Bow Speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmberGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Boost 2");
            Description.SetDefault("Gaining +8% additional Bow Speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmberGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Boost 3");
            Description.SetDefault("Gaining +12% additional Bow Speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmberGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Boost 4");
            Description.SetDefault("Gaining +16% additional Bow Speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    public class AmberGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amber Boost 5");
            Description.SetDefault("Gaining +20% additional Bow Speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }
    }

    //Ruby
    public class RubyGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ruby Boost 1");
            Description.SetDefault("Gaining +2% additional Gun & Explosive damage.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.bulletDamage += 0.02f;
            player.rocketDamage += 0.02f;
        }
    }

    public class RubyGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ruby Boost 2");
            Description.SetDefault("Gaining +4% additional Gun & Explosive damage.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.bulletDamage += 0.04f;
            player.rocketDamage += 0.04f;
        }
    }

    public class RubyGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ruby Boost 3");
            Description.SetDefault("Gaining +6% additional Gun & Explosive damage.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.bulletDamage += 0.06f;
            player.rocketDamage += 0.06f;
        }
    }

    public class RubyGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ruby Boost 4");
            Description.SetDefault("Gaining +8% additional Gun & Explosive damage.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.bulletDamage += 0.08f;
            player.rocketDamage += 0.08f;
        }
    }

    public class RubyGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ruby Boost 5");
            Description.SetDefault("Gaining +10% additional Gun & Explosive damage.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.bulletDamage += 0.1f;
            player.rocketDamage += 0.1f;
        }
    }

    //Sapphire
    public class SapphireGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Boost 1");
            Description.SetDefault("Gaining -2% reduced Mana Cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.manaCost -= 0.02f;
        }
    }

    public class SapphireGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Boost 2");
            Description.SetDefault("Gaining -4% reduced Mana Cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.manaCost -= 0.04f;
        }
    }

    public class SapphireGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Boost 3");
            Description.SetDefault("Gaining -6% reduced Mana Cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.manaCost -= 0.06f;
        }
    }

    public class SapphireGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Boost 4");
            Description.SetDefault("Gaining -8% reduced Mana Cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.manaCost -= 0.08f;
        }
    }

    public class SapphireGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sapphire Boost 5");
            Description.SetDefault("Gaining -10% reduced Mana Cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.manaCost -= 0.1f;
        }
    }

    //Emerald
    public class EmeraldGemBoost1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Boost 1");
            Description.SetDefault("Gaining +2% Melee, Thrown (Calamity-specific: and Rogue) crit chance.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.meleeCrit += 2;
            player.thrownCrit += 2;
        }
    }

    public class EmeraldGemBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Boost 2");
            Description.SetDefault("Gaining +4% Melee, Thrown (Calamity-specific: and Rogue) crit chance.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.meleeCrit += 4;
            player.thrownCrit += 4;
        }
    }

    public class EmeraldGemBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Boost 3");
            Description.SetDefault("Gaining +6% Melee, Thrown (Calamity-specific: and Rogue) crit chance.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.meleeCrit += 6;
            player.thrownCrit += 6;
        }
    }

    public class EmeraldGemBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Boost 4");
            Description.SetDefault("Gaining +8% Melee, Thrown (Calamity-specific: and Rogue) crit chance.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.meleeCrit += 8;
            player.thrownCrit += 8;
        }
    }

    public class EmeraldGemBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Boost 5");
            Description.SetDefault("Gaining +10% Melee, Thrown (Calamity-specific: and Rogue) crit chance.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            player.meleeCrit += 10;
            player.thrownCrit += 10;
        }
    }

}