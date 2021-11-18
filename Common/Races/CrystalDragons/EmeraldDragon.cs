using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MrPlagueRaces.Common.Races;
using CrystalDragons.Content.Buffs;
using CrystalDragons.Content.Projectiles;
using CrystalDragons.Content.Dusts;
using CrystalDragons.Content;
using CrystalDragons.Config;

namespace CrystalDragons.Common.Races
{
    public class EmeraldDragon : Race
    {
        public override string RaceEnvironmentIcon => ($"CrystalDragons/Common/UI/RaceDisplay/Backgrounds/EmeraldCave");
        public override string RaceEnvironmentOverlay1Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
        public override string RaceEnvironmentOverlay2Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");

        public override string RaceSelectIcon => ($"CrystalDragons/Common/UI/RaceDisplay/EmeSelect");
        public override string RaceDisplayMaleIcon => ($"CrystalDragons/Common/UI/RaceDisplay/EmeDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"CrystalDragons/Common/UI/RaceDisplay/EmeDisplayFemale");

        public override string RaceDisplayName => "Emerald Dragon";
        public override string RaceLore1 => "A race of dragonfolk" + "\nwho have affinity" + "\nwith gemstones.";
        public override string RaceLore2 => "Emerald dragons are lithe" + "\nand nimble, able to strike" + "\nweak points precicely. Adept" + "\nat melee and throwing.";
        public override string RaceAbilityName => "Emerald Instinct";
        public override string RaceAbilityDescription1 => "[c/34EB93:(Active) Emerald Instinct]: Increase Melee, Throwing (Calamity-specific: and Rogue) Critical Hit rate by 50% and all attacks";
        public override string RaceAbilityDescription2 => "inflict [c/34EB93:Emerald Exploit] for 10 seconds. This ability has a 10 minute cooldown.";
        public override string RaceAbilityDescription3 => "[c/34EB93:Emerald Exploit]: Enemies afflicted have -30 defense for 10 seconds.";
        public override string RaceAbilityDescription4 => "[c/CACF2B:(Passive) Emerald Precision:] Every time you score a Critical Hit, gain a stack of Emerald Precision. Each stack increases Melee and";
        public override string RaceAbilityDescription5 => "Thrown (Calamity-specific: and Rogue) Damage by [c/34EB93:+2%]. Stacks up to 15, stacks decay 1 at a time after 3s of no Crits.";
        public override string RaceAbilityDescription6 => "";
        public override string RaceAdditionalNotesDescription1 => "[c/105723:Emerald Gem Boost:] When nearby a filled Emerald Gem Lock, Increases Melee, Thrown (Calamity-specific: and Rogue) crit chance by 2% per gem (Max +10%)";
        public override string RaceAdditionalNotesDescription2 => "";
        public override string RaceAdditionalNotesDescription3 => "-Emerald Dragons undergo intense training from an early age to refine their agility. Always considered under the effect of [c/252525:Black Belt] accessory.";
        public override string RaceAdditionalNotesDescription4=> "-Their sharp horns can damage attackers. Reflect 15% of damage taken as Thorns.";
        public override string RaceAdditionalNotesDescription5 => "-Critical Hits deal [c/34EB93:10% more] damage, non-crits deal [c/FF4F64:10% less] damage.";
        public override string RaceAdditionalNotesDescription6 => "-[c/34EB93:+15%] Throwing Crit Chance (Calamity-specific: [c/34EB93:+15%] Rogue Crit Chance)";

        //public override bool UsesCustomHurtSound => true;
        //public override bool UsesCustomDeathSound => true;

        public override string RaceHealthDisplayText => "[c/FF4F64:-15%]";
        public override string RaceRegenerationDisplayText => "";
        public override string RaceManaDisplayText => "";
        public override string RaceManaRegenerationDisplayText => "";
        public override string RaceDefenseDisplayText => "";
        public override string RaceDamageReductionDisplayText => "[c/FF4F64:-10%]";
        public override string RaceThornsDisplayText => "[c/34EB93:15%]";
        public override string RaceLavaResistanceDisplayText => "";
        public override string RaceMeleeDamageDisplayText => "";
        public override string RaceRangedDamageDisplayText => "";
        public override string RaceMagicDamageDisplayText => "";
        public override string RaceSummonDamageDisplayText => "";
        public override string RaceMeleeSpeedDisplayText => "";
        public override string RaceArmorPenetrationDisplayText => "[c/34EB93:+5]";
        public override string RaceBulletDamageDisplayText => "";
        public override string RaceRocketDamageDisplayText => "";
        public override string RaceManaCostDisplayText => "";
        public override string RaceMinionKnockbackDisplayText => "";
        public override string RaceMinionsDisplayText => "";
        public override string RaceSentriesDisplayText => "";
        public override string RaceMeleeCritChanceDisplayText => "[c/34EB93:+15%]";
        public override string RaceRangedCritChanceDisplayText => "";
        public override string RaceMagicCritChanceDisplayText => "";
        public override string RaceMiningSpeedDisplayText => "";
        public override string RaceBuildingSpeedDisplayText => "";
        public override string RaceBuildingWallSpeedDisplayText => "";
        public override string RaceBuildingRangeDisplayText => "";
        public override string RaceArrowDamageDisplayText => "";
        public override string RaceMovementSpeedDisplayText => "[c/34EB93:+15%]";
        public override string RaceJumpSpeedDisplayText => "";
        public override string RaceFallDamageResistanceDisplayText => "";
        public override string RaceAllDamageDisplayText => "[c/FF4F64:-10%]";
        public override string RaceFishingSkillDisplayText => "";
        public override string RaceAggroDisplayText => "";
        public override string RaceRunSpeedDisplayText => "";
        public override string RaceRunAccelerationDisplayText => "[c/34EB93:+15%]";

        public override bool UsesCustomDeathSound => true;

        public override void ResetEffects(Player player)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (modPlayer.RaceStats)
            {
                player.statLifeMax2 -= (int)(player.statLifeMax2 * 0.15f);
                player.thorns += 0.15f;
                player.armorPenetration += 5;
                player.meleeCrit += 15;
                player.thrownCrit += 15;
                player.allDamage -= 0.1f;
                player.moveSpeed += 0.15f;
                player.runAcceleration += 0.15f;
                player.endurance -= 0.1f;
                player.blackBelt = true;

                crystalPlayer.emerald = true;
            }
        }

        public override bool PreKill(Player player, Mod mod, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            var crystalDragonMod = ModLoader.GetMod("CrystalDragons");
            if (Main.rand.Next(0, 99) == 69)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, crystalDragonMod.GetSoundSlot(SoundType.Custom, "Sounds/Fart_With_Reverb"), 1);
                return true;
            }
            else
            {
                Main.PlaySound(SoundID.PlayerKilled, player.Center);
                return true;
            }
        }

        public override void ProcessTriggers(Player player, Mod mod)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            if (modPlayer.RaceStats)
            {
                if (MrPlagueRaces.MrPlagueRaces.RacialAbilityHotKey.Current)
                {
                    if (!player.HasBuff(ModContent.BuffType<RacialCooldown>()))
                    {
                        if (!player.dead)
                        {
                            //10 min ability
                            player.AddBuff(ModContent.BuffType<EmeraldInstinct>(), 600, false);
                            Main.PlaySound(SoundID.DD2_LightningBugDeath.WithVolume(2), player.Center);
                        }

                        //10 minute cooldown
                        player.AddBuff(ModContent.BuffType<RacialCooldown>(), (ModContent.GetInstance<CrystalDragonsConfigServer>().RacialCooldown * 60), false);

                        //debug 2s cooldown
                        //player.AddBuff(ModContent.BuffType<RacialCooldown>(), 120, false);                        
                    }
                }
            }
        }

        public override void ModifyDrawInfo(Player player, Mod mod, ref PlayerDrawInfo drawInfo)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Item familiarshirt = new Item();
            familiarshirt.SetDefaults(ItemID.FamiliarShirt);
            Item familiarpants = new Item();
            familiarpants.SetDefaults(ItemID.FamiliarPants);

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            crystalPlayer.emerald = true;

            if (modPlayer.resetDefaultColors && Main.gameMenu)
            {
                modPlayer.resetDefaultColors = false;
                player.skinColor = new Color(129, 168, 121);
                player.eyeColor = new Color(220, 220, 0);
                player.hairColor = new Color(15, 83, 70);
                player.hair = 38;
            }

        }

        public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();

            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            crystalPlayer.emerald = true;

            bool hideChestplate = modPlayer.hideChestplate;
            bool hideLeggings = modPlayer.hideLeggings;

            Main.playerTextures[0, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head");
            Main.playerTextures[0, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[0, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[0, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_1");
            }
            else
            {
                Main.playerTextures[0, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[0, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_1");
            }
            else
            {
                Main.playerTextures[0, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[0, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1");
            }
            else
            {
                Main.playerTextures[0, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[0, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand");
            Main.playerTextures[0, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1");
                Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_1");
            }
            else
            {
                Main.playerTextures[0, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[0, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_1_2");
            }
            else
            {
                Main.playerTextures[0, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_1_2");
            }
            else
            {
                Main.playerTextures[0, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[1, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head");
            Main.playerTextures[1, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[1, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[1, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_2");
            }
            else
            {
                Main.playerTextures[1, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[1, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_2");
            }
            else
            {
                Main.playerTextures[1, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[1, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2");
            }
            else
            {
                Main.playerTextures[1, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[1, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand");
            Main.playerTextures[1, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2");
                Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_2");
            }
            else
            {
                Main.playerTextures[1, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[1, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_2_2");
            }
            else
            {
                Main.playerTextures[1, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_2_2");
            }
            else
            {
                Main.playerTextures[1, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[2, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head");
            Main.playerTextures[2, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[2, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[2, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_3");
            }
            else
            {
                Main.playerTextures[2, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[2, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_3");
            }
            else
            {
                Main.playerTextures[2, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[2, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3");
            }
            else
            {
                Main.playerTextures[2, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[2, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand");
            Main.playerTextures[2, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3");
                Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_3");
            }
            else
            {
                Main.playerTextures[2, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[2, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_3_2");
            }
            else
            {
                Main.playerTextures[2, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_3_2");
            }
            else
            {
                Main.playerTextures[2, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[3, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head");
            Main.playerTextures[3, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[3, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[3, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_4");
            }
            else
            {
                Main.playerTextures[3, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[3, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_4");
            }
            else
            {
                Main.playerTextures[3, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[3, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4");
            }
            else
            {
                Main.playerTextures[3, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[3, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand");
            Main.playerTextures[3, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4");
                Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_4");
            }
            else
            {
                Main.playerTextures[3, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[3, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_4_2");
            }
            else
            {
                Main.playerTextures[3, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_4_2");
            }
            else
            {
                Main.playerTextures[3, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[8, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head");
            Main.playerTextures[8, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[8, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[8, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_9");
            }
            else
            {
                Main.playerTextures[8, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[8, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_9");
            }
            else
            {
                Main.playerTextures[8, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[8, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9");
            }
            else
            {
                Main.playerTextures[8, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[8, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand");
            Main.playerTextures[8, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9");
                Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_9");
            }
            else
            {
                Main.playerTextures[8, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[8, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_9_2");
            }
            else
            {
                Main.playerTextures[8, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_9_2");
            }
            else
            {
                Main.playerTextures[8, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[4, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head_Female");
            Main.playerTextures[4, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[4, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[4, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_5");
            }
            else
            {
                Main.playerTextures[4, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[4, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_5");
            }
            else
            {
                Main.playerTextures[4, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[4, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5");
            }
            else
            {
                Main.playerTextures[4, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[4, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand_Female");
            Main.playerTextures[4, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs_Female");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5");
                Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_5");
            }
            else
            {
                Main.playerTextures[4, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[4, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_5_2");
            }
            else
            {
                Main.playerTextures[4, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_5_2");
            }
            else
            {
                Main.playerTextures[4, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[5, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head_Female");
            Main.playerTextures[5, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[5, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[5, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_6");
            }
            else
            {
                Main.playerTextures[5, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[5, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_6");
            }
            else
            {
                Main.playerTextures[5, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[5, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6");
            }
            else
            {
                Main.playerTextures[5, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[5, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand_Female");
            Main.playerTextures[5, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs_Female");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6");
                Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_6");
            }
            else
            {
                Main.playerTextures[5, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[5, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_6_2");
            }
            else
            {
                Main.playerTextures[5, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_6_2");
            }
            else
            {
                Main.playerTextures[5, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[6, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head_Female");
            Main.playerTextures[6, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[6, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[6, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_7");
            }
            else
            {
                Main.playerTextures[6, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[6, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_7");
            }
            else
            {
                Main.playerTextures[6, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[6, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7");
            }
            else
            {
                Main.playerTextures[6, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[6, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand_Female");
            Main.playerTextures[6, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs_Female");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7");
                Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_7");
            }
            else
            {
                Main.playerTextures[6, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[6, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_7_2");
            }
            else
            {
                Main.playerTextures[6, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_7_2");
            }
            else
            {
                Main.playerTextures[6, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[7, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head_Female");
            Main.playerTextures[7, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[7, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[7, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_8");
            }
            else
            {
                Main.playerTextures[7, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[7, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_8");
            }
            else
            {
                Main.playerTextures[7, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[7, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8");
            }
            else
            {
                Main.playerTextures[7, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[7, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand_Female");
            Main.playerTextures[7, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs_Female");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8");
                Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_8");
            }
            else
            {
                Main.playerTextures[7, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[7, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_8_2");
            }
            else
            {
                Main.playerTextures[7, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_8_2");
            }
            else
            {
                Main.playerTextures[7, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[9, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Head_Female");
            Main.playerTextures[9, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[9, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[9, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Torso_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeves_10");
            }
            else
            {
                Main.playerTextures[9, 4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[9, 5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hands_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shirt_10");
            }
            else
            {
                Main.playerTextures[9, 6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[9, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/EmeraldDragon/Eme_Arm_Female");

            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10");
            }
            else
            {
                Main.playerTextures[9, 8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.playerTextures[9, 9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Hand_Female");
            Main.playerTextures[9, 10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Legs_Female");

            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10");
                Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Shoes_10");
            }
            else
            {
                Main.playerTextures[9, 11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
                Main.playerTextures[9, 12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[1].type == ItemID.FamiliarShirt || player.armor[11].type == ItemID.FamiliarShirt) && !hideChestplate)
            {
                Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Sleeve_10_2");
            }
            else
            {
                Main.playerTextures[9, 13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }
            if ((player.armor[2].type == ItemID.FamiliarPants || player.armor[12].type == ItemID.FamiliarPants) && !hideLeggings)
            {
                Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Pants_10_2");
            }
            else
            {
                Main.playerTextures[9, 14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }


            int numberOfHairStyles = 51;

            for (int i = 0; i < numberOfHairStyles; i++)
            {
                Main.playerHairTexture[i] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_" + (i + 1));
            }

            for (int i = numberOfHairStyles; i < 134; i++)
            {
                Main.playerHairTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            for (int i = 0; i < 134; i++)
            {
                Main.playerHairAltTexture[i] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            }

            Main.ghostTexture = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Ghost");

            //Main.playerHairTexture[0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_957");
            //Main.playerHairTexture[51] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_1");
            //Main.playerHairTexture[1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_2");
            //Main.playerHairTexture[2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_3");
            //Main.playerHairTexture[3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_4");
            //Main.playerHairTexture[4] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_5");
            //Main.playerHairTexture[5] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_6");
            //Main.playerHairTexture[6] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_7");
            //Main.playerHairTexture[7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_8");
            //Main.playerHairTexture[8] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_9");
            //Main.playerHairTexture[9] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_10");
            //Main.playerHairTexture[10] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_11");
            //Main.playerHairTexture[11] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_42");
            //Main.playerHairTexture[12] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_12");
            //Main.playerHairTexture[13] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_13");
            //Main.playerHairTexture[14] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_14");
            //Main.playerHairTexture[15] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_15");
            //Main.playerHairTexture[16] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_16");
            //Main.playerHairTexture[17] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_17");
            //Main.playerHairTexture[18] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_18");
            //Main.playerHairTexture[19] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_19");
            //Main.playerHairTexture[20] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_20");
            //Main.playerHairTexture[21] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_21");
            //Main.playerHairTexture[22] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_22");
            //Main.playerHairTexture[23] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_23");
            //Main.playerHairTexture[24] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_24");
            //Main.playerHairTexture[25] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_25");
            //Main.playerHairTexture[26] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_26");
            //Main.playerHairTexture[27] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_27");
            //Main.playerHairTexture[28] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_28");
            //Main.playerHairTexture[29] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_29");
            //Main.playerHairTexture[30] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_30");
            //Main.playerHairTexture[31] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_31");
            //Main.playerHairTexture[32] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_32");
            //Main.playerHairTexture[33] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_33");
            //Main.playerHairTexture[34] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_34");
            //Main.playerHairTexture[35] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_35");
            //Main.playerHairTexture[36] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_36");
            //Main.playerHairTexture[37] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_37");
            //Main.playerHairTexture[38] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_38");
            //Main.playerHairTexture[39] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_39");
            //Main.playerHairTexture[40] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_40");
            //Main.playerHairTexture[41] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_41");
            //Main.playerHairTexture[42] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_43");
            //Main.playerHairTexture[43] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_44");
            //Main.playerHairTexture[44] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_45");
            //Main.playerHairTexture[45] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_46");
            //Main.playerHairTexture[46] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_47");
            //Main.playerHairTexture[47] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_48");
            //Main.playerHairTexture[48] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_49");
            //Main.playerHairTexture[49] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_50");
            //Main.playerHairTexture[50] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Dia_Hair_51");
            //Main.playerHairTexture[52] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/DiamondDragon/Hair/Test");

            //Main.playerHairTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

            //Main.playerHairAltTexture[0] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[1] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[2] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[3] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[4] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[5] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[6] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[7] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[8] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[9] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[10] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[11] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[12] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[13] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[14] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[15] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[16] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[17] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[18] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[19] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[20] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[21] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[22] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[23] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[24] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[25] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[26] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[27] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[28] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[29] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[30] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[31] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[32] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[33] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[34] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[35] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[36] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[37] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[38] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[39] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[40] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[41] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[42] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[43] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[44] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[45] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[46] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[47] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[48] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[49] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[50] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[51] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[52] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[53] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[54] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[55] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[56] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[57] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[58] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[59] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[60] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[61] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[62] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[63] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[64] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[65] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[66] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[67] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[68] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[69] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[70] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[71] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[72] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[73] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[74] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[75] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[76] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[77] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[78] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[79] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[80] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[81] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[82] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[83] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[84] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[85] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[86] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[87] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[88] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[89] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[90] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[91] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[92] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[93] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[94] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[95] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[96] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[97] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[98] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[99] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[100] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[101] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[102] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[103] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[104] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[105] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[106] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[107] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[108] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[109] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[110] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[111] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[112] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[113] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[114] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[115] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[116] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[117] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[118] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[119] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[120] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[121] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[122] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[123] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[124] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[125] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[126] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[127] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[128] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[129] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[130] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[131] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[132] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");
            //Main.playerHairAltTexture[133] = ModContent.GetTexture("MrPlagueRaces/Content/RaceTextures/Blank");

            //Main.ghostTexture = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Ghost");
        }

        /*
        Player sheets are split into 15 different sections ([x, 0] to [x, 14]) and repeated 10 times for each default clothing style and each gender. There are a total of 10 repeats, 5 of which are used for male and 5 of which are used for female.
        Clothing sheets are put into an if/else statement to detect whether The familiar clothing is equipped onto The player. If The player is not wearing familiar clothing, The respective clothing sheets will be set to a blank sheet. Otherwise, they will appear as clothing.

        Main.playerTextures[0, 0]: The head sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 1]: The eye whites sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 2]: The eye iris sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 3]: The torso sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 4]: The clothing sleeves sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 5]: The hands sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 6]: The clothing shirt sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 7]: The arm sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 8]: The clothing singular sleeve sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 9]: The singular hand sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 10]: The legs sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 11]: The clothing pants sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 12]: The clothing shoes sheet for clothing style 1 (MALE)
        Main.playerTextures[0, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
        Main.playerTextures[0, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

        Main.playerTextures[1, 0]: The head sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 1]: The eye whites sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 2]: The eye iris sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 3]: The torso sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 4]: The clothing sleeves sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 5]: The hands sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 6]: The clothing shirt sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 7]: The arm sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 8]: The clothing singular sleeve sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 9]: The singular hand sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 10]: The legs sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 11]: The clothing pants sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 12]: The clothing shoes sheet for clothing style 2 (MALE)
        Main.playerTextures[1, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
        Main.playerTextures[1, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)


        Main.playerTextures[2, 0]: The head sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 1]: The eye whites sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 2]: The eye iris sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 3]: The torso sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 4]: The clothing sleeves sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 5]: The hands sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 6]: The clothing shirt sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 7]: The arm sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 8]: The clothing singular sleeve sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 9]: The singular hand sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 10]: The legs sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 11]: The clothing pants sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 12]: The clothing shoes sheet for clothing style 3 (MALE)
        Main.playerTextures[2, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
        Main.playerTextures[2, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

        Main.playerTextures[3, 0]: The head sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 1]: The eye whites sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 2]: The eye iris sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 3]: The torso sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 4]: The clothing sleeves sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 5]: The hands sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 6]: The clothing shirt sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 7]: The arm sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 8]: The clothing singular sleeve sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 9]: The singular hand sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 10]: The legs sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 11]: The clothing pants sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 12]: The clothing shoes sheet for clothing style 4 (MALE)
        Main.playerTextures[3, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
        Main.playerTextures[3, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

        Main.playerTextures[8, 0]: The head sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 1]: The eye whites sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 2]: The eye iris sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 3]: The torso sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 4]: The clothing sleeves sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 5]: The hands sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 6]: The clothing shirt sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 7]: The arm sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 8]: The clothing singular sleeve sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 9]: The singular hand sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 10]: The legs sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 11]: The clothing pants sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 12]: The clothing shoes sheet for clothing style 5 (MALE)
        Main.playerTextures[8, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)
        Main.playerTextures[8, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (MALE)

        Main.playerTextures[4, 0]: The head sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 1]: The eye whites sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 2]: The eye iris sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 3]: The torso sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 4]: The clothing sleeves sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 5]: The hands sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 6]: The clothing shirt sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 7]: The arm sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 8]: The clothing singular sleeve sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 9]: The singular hand sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 10]: The legs sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 11]: The clothing pants sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 12]: The clothing shoes sheet for clothing style 1 (FEMALE)
        Main.playerTextures[4, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        Main.playerTextures[4, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

        Main.playerTextures[5, 0]: The head sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 1]: The eye whites sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 2]: The eye iris sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 3]: The torso sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 4]: The clothing sleeves sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 5]: The hands sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 6]: The clothing shirt sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 7]: The arm sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 8]: The clothing singular sleeve sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 9]: The singular hand sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 10]: The legs sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 11]: The clothing pants sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 12]: The clothing shoes sheet for clothing style 2 (FEMALE)
        Main.playerTextures[5, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        Main.playerTextures[5, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)


        Main.playerTextures[6, 0]: The head sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 1]: The eye whites sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 2]: The eye iris sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 3]: The torso sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 4]: The clothing sleeves sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 5]: The hands sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 6]: The clothing shirt sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 7]: The arm sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 8]: The clothing singular sleeve sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 9]: The singular hand sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 10]: The legs sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 11]: The clothing pants sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 12]: The clothing shoes sheet for clothing style 3 (FEMALE)
        Main.playerTextures[6, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        Main.playerTextures[6, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

        Main.playerTextures[7, 0]: The head sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 1]: The eye whites sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 2]: The eye iris sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 3]: The torso sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 4]: The clothing sleeves sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 5]: The hands sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 6]: The clothing shirt sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 7]: The arm sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 8]: The clothing singular sleeve sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 9]: The singular hand sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 10]: The legs sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 11]: The clothing pants sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 12]: The clothing shoes sheet for clothing style 4 (FEMALE)
        Main.playerTextures[7, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        Main.playerTextures[7, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)

        Main.playerTextures[9, 0]: The head sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 1]: The eye whites sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 2]: The eye iris sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 3]: The torso sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 4]: The clothing sleeves sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 5]: The hands sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 6]: The clothing shirt sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 7]: The arm sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 8]: The clothing singular sleeve sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 9]: The singular hand sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 10]: The legs sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 11]: The clothing pants sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 12]: The clothing shoes sheet for clothing style 5 (FEMALE)
        Main.playerTextures[9, 13]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        Main.playerTextures[9, 14]: An extra clothing layer that is used for some clothing styles (usually as a secondary sleeve color or a dress), otherwise being blank (FEMALE)
        */
    }
}
