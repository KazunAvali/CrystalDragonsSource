using CrystalDragons.Items;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CrystalDragons.Prefixes
{
    public class TopazPrefix : ModPrefix
    {
        private byte damage;
        private byte crit;
        private byte moveSpeed;
        private byte meleeSpeed;
        private byte defense;

        //private byte manaReduction;
        //private byte ammoReduction;
        //private byte throwVel;
        //private byte rangedVel;
        //private byte dashPower;
        //private byte recovery;
        private byte dodgeChance;

        //public override float RollChance(Item item)
        //{
        //    return ModContent.GetInstance<GameplaySettings>().DisableModdedPrefixes ? 0f : 1f;
        //}

        public override bool CanRoll(Item item)
        {
            return false;
        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public TopazPrefix()
        {
        }

        public TopazPrefix(byte damage, byte crit, byte moveSpeed, byte meleeSpeed, byte defense, byte dodgeChance)
        {
            this.damage = damage;
            this.crit = crit;
            this.moveSpeed = moveSpeed;
            this.meleeSpeed = meleeSpeed;
            this.defense = defense;
            //this.manaReduction = manaReduction;
            //this.ammoReduction = ammoReduction;
            //this.throwVel = throwVel;
            //this.rangedVel = rangedVel;
            //this.dashPower = dashPower;
            //this.recovery = recovery;
            this.dodgeChance = dodgeChance;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                //mod.AddPrefix("name", new AccessoryPrefix(damage, crit, moveSpeed, meleeSpeed, defense, dodgechance));
                mod.AddPrefix("TopazWarding", new TopazPrefix(0, 0, 0, 0, 4, 4));
                mod.AddPrefix("TopazBulwark", new TopazPrefix(0, 0, 0, 0, 6, 6));

                mod.AddPrefix("TopazShinobi", new TopazPrefix(0, 2, 2, 0, 0, 4));
                mod.AddPrefix("TopazIai", new TopazPrefix(0, 3, 3, 0, 0, 6));

                mod.AddPrefix("TopazBalanced", new TopazPrefix(2, 2, 2, 0, 2, 0));
                mod.AddPrefix("TopazEqualized", new TopazPrefix(3, 3, 3, 0, 3, 0));

                mod.AddPrefix("TopazStriking", new TopazPrefix(4, 0, 0, 4, 0, 0));
                mod.AddPrefix("TopazEviscerating", new TopazPrefix(6, 0, 0, 6, 0, 0));

                mod.AddPrefix("TopazDestructive", new TopazPrefix(4, 4, 0, 0, 0, 0));
                mod.AddPrefix("TopazAnnihilating", new TopazPrefix(6, 6, 0, 0, 0, 0));

                mod.AddPrefix("TopazStrong", new TopazPrefix(4, 0, 0, 0, 4, 0));
                mod.AddPrefix("TopazMighty", new TopazPrefix(6, 0, 0, 0, 6, 0));

                mod.AddPrefix("TopazFleet", new TopazPrefix(0, 0, 4, 0, 0, 4));
                mod.AddPrefix("TopazQuantum", new TopazPrefix(0, 0, 6, 0, 0, 6));

                mod.AddPrefix("L A K E", new TopazPrefix(6, 6, 6, 6, 6, 6));
            }
            return false;
        }

        public override void Apply(Item item)
        {
            item.GetGlobalItem<TopazTinkerGI>().damage = damage;
            item.GetGlobalItem<TopazTinkerGI>().crit = crit;
            item.GetGlobalItem<TopazTinkerGI>().moveSpeed = moveSpeed;
            item.GetGlobalItem<TopazTinkerGI>().meleeSpeed = meleeSpeed;
            item.GetGlobalItem<TopazTinkerGI>().defense = defense;
            //item.GetGlobalItem<TopazTinkerGI>().manaReduction = manaReduction;
            //item.GetGlobalItem<TopazTinkerGI>().ammoReduction = ammoReduction;
            //item.GetGlobalItem<TopazTinkerGI>().throwVel = throwVel;
            //item.GetGlobalItem<TopazTinkerGI>().rangedVel = rangedVel;
            //item.GetGlobalItem<TopazTinkerGI>().dashPower = dashPower;
            //item.GetGlobalItem<TopazTinkerGI>().recovery = recovery;
            item.GetGlobalItem<TopazTinkerGI>().dodgeChance = dodgeChance;
        }

        public override void ModifyValue(ref float valueMult)
        {
            float multiplier = 1f * (1 + damage * 0.04f) * (1 + crit * 0.08f) * (1 + moveSpeed * 0.04f) * (1 + meleeSpeed * 0.04f) * (1 + defense * 0.02f) * (1 + dodgeChance * 0.08f);
            valueMult *= multiplier;
        }
    }
}

