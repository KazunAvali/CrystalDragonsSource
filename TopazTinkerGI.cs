using CrystalDragons.Content;
using CrystalDragons.Prefixes;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace CrystalDragons.Items
{
    public class TopazTinkerGI : GlobalItem
    {
        public int damage;
        public int crit;
        public int moveSpeed;
        public int meleeSpeed;
        public int defense;
        //public int manaReduction;
        //public int ammoReduction;
        //public int throwVel;
        //public int rangedVel;
        //public int dashPower;
        //public int recovery;
        public int dodgeChance;

        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            TopazTinkerGI myClone = (TopazTinkerGI)base.Clone(item, itemClone);

            myClone.damage = damage;
            myClone.crit = crit;
            myClone.moveSpeed = moveSpeed;
            myClone.meleeSpeed = meleeSpeed;
            myClone.defense = defense;
            //myClone.manaReduction = manaReduction;
            //myClone.ammoReduction = ammoReduction;
            //myClone.throwVel = throwVel;
            //myClone.rangedVel = rangedVel;
            //myClone.dashPower = dashPower;
            //myClone.recovery = recovery;
            myClone.dodgeChance = dodgeChance;
            return myClone;
        }

        public override bool NewPreReforge(Item item)
        {
            damage = 0;
            crit = 0;
            moveSpeed = 0;
            meleeSpeed = 0;
            defense = 0;
            //manaReduction = 0;
            //ammoReduction = 0;
            //throwVel = 0;
            //rangedVel = 0;
            //dashPower = 0;
            //recovery = 0;
            dodgeChance = 0;
            return base.NewPreReforge(item);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (damage > 0)
            {
                TooltipLine line = new TooltipLine(mod, "damage", "+" + damage + "% damage");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + damage + "% damage";
            }
            if (crit > 0)
            {
                TooltipLine line = new TooltipLine(mod, "crit", "+" + crit + "% critical strike chance");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + crit + "% critical strike chance";
            }
            if (moveSpeed > 0)
            {
                TooltipLine line = new TooltipLine(mod, "moveSpeed", "+" + moveSpeed + "% movement speed");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + moveSpeed + "% movement speed";
            }
            if (meleeSpeed > 0)
            {
                TooltipLine line = new TooltipLine(mod, "meleeSpeed", "+" + meleeSpeed + "% melee speed");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + meleeSpeed + "% melee speed";
            }
            if (defense > 0)
            {
                TooltipLine line = new TooltipLine(mod, "defense", "+" + defense + " defense");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + defense + " defense";
            }

            if (dodgeChance > 0)
            {
                TooltipLine line = new TooltipLine(mod, "recovery", "+" + dodgeChance + "% dodge chance");
                line.isModifier = true;
                tooltips.Add(line);
                line.text = "+" + dodgeChance + "% dodge chance";
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.prefix > 0)
            {
                player.allDamage += damage * .01f;
                player.meleeCrit += crit;
                player.rangedCrit += crit;
                player.magicCrit += crit;
                player.thrownCrit += crit;
                player.moveSpeed += moveSpeed * .01f;
                player.meleeSpeed += meleeSpeed * .01f;
                player.statDefense += defense;
                //player.manaCost -= manaReduction * .01f;
                //player.GetModPlayer<QwertyPlayer>().ammoReduction *= (1f - (ammoReduction * .01f));
                //player.thrownVelocity += throwVel * .01f;
                //player.GetModPlayer<QwertyPlayer>().rangedVelocity += rangedVel * .01f;
                //player.GetModPlayer<QwertyPlayer>().customDashBonusSpeed += dashPower;
                //player.GetModPlayer<QwertyPlayer>().recovery += recovery;
                player.GetModPlayer<CrystalDragonPlayer>().dodgeChance += dodgeChance;
            }
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(damage);
            writer.Write(crit);
            writer.Write(moveSpeed);
            writer.Write(meleeSpeed);
            writer.Write(defense);
            //writer.Write(manaReduction);
            //writer.Write(ammoReduction);
            //writer.Write(throwVel);
            //writer.Write(rangedVel);
            //writer.Write(dashPower);
            //writer.Write(recovery);
            writer.Write(dodgeChance);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            damage = reader.ReadInt32();
            crit = reader.ReadInt32();
            moveSpeed = reader.ReadInt32();
            meleeSpeed = reader.ReadInt32();
            defense = reader.ReadInt32();
            //manaReduction = reader.ReadInt32();
            //ammoReduction = reader.ReadInt32();
            //throwVel = reader.ReadInt32();
            //rangedVel = reader.ReadInt32();
            //dashPower = reader.ReadInt32();
            //recovery = reader.ReadInt32();
            dodgeChance = reader.ReadInt32();
        }

    }
}
