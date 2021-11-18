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
using Terraria.Audio;
using CrystalDragons.Config;

namespace CrystalDragons.Common.Races
{
    public class AmberRaptor : Race
    {
        public override string RaceEnvironmentIcon => ($"CrystalDragons/Common/UI/RaceDisplay/Backgrounds/AmberCave");
        public override string RaceEnvironmentOverlay1Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");
        public override string RaceEnvironmentOverlay2Icon => ($"MrPlagueRaces/Common/UI/RaceDisplay/BlankDisplay");

        public override string RaceSelectIcon => ($"CrystalDragons/Common/UI/RaceDisplay/AmbSelect");
        public override string RaceDisplayMaleIcon => ($"CrystalDragons/Common/UI/RaceDisplay/AmbDisplayMale");
        public override string RaceDisplayFemaleIcon => ($"CrystalDragons/Common/UI/RaceDisplay/AmbDisplayFemale");

        public override string RaceDisplayName => "Amber Raptor";
        public override string RaceLore1 => "Ancient ancestors" + "\nof the Crystal" + "\ndragons. Fleet" + "\nraptors with a knack" + "\nfor bows.";
        public override string RaceLore2 => "Having recently been revived from" + "\nthe past, other than bows" + "\nthey doen't quite understand" + "\nmost of these new weapons.";
        public override string RaceAbilityName => "Amber Instinct";
        public override string RaceAbilityDescription1 => "[c/34EB93:(Active) Amber Instinct]: Attune yourself to your primal instincts. Gain +200% ranged weapon speed, +20% ranged crit chance, and";
        public override string RaceAbilityDescription2 => "+20% maximum movement speed for 10 seconds. This ability has a 10 minute cooldown.";
        public override string RaceAbilityDescription3 => "";
        public override string RaceAbilityDescription4 => "";
        public override string RaceAbilityDescription5 => "";
        public override string RaceAbilityDescription6 => "";
        public override string RaceAdditionalNotesDescription1 => "[c/cc9a3d:Amber Gem Boost:] When nearby a filled Amber Gem Lock, increase Bow speed by 4% per gem (max +20%)";
        public override string RaceAdditionalNotesDescription2 => "-Amber Raptors are agile by nature and have innate ability to dodge. [c/34EB93:+10%] innate dodge chance.";
        public override string RaceAdditionalNotesDescription3 => "-They don't like the water. Take various [c/FF4F64:movement penalties] and [c/FF4F64:-15% damage] while wet";
        public override string RaceAdditionalNotesDescription4 => "-Less maximum breath time than other races.";
        public override string RaceAdditionalNotesDescription5 => "";
        public override string RaceAdditionalNotesDescription6 => "";

        //public override bool UsesCustomHurtSound => true;
        //public override bool UsesCustomDeathSound => true;

        public override string RaceHealthDisplayText => "[c/FF4F64:-10%]";
        public override string RaceRegenerationDisplayText => "";
        public override string RaceManaDisplayText => "";
        public override string RaceManaRegenerationDisplayText => "";
        public override string RaceDefenseDisplayText => "";
        public override string RaceDamageReductionDisplayText => "";
        public override string RaceThornsDisplayText => "";
        public override string RaceLavaResistanceDisplayText => "";
        public override string RaceMeleeDamageDisplayText => "[c/FF4F64:-10%]";
        public override string RaceRangedDamageDisplayText => "";
        public override string RaceMagicDamageDisplayText => "[c/FF4F64:-10%]";
        public override string RaceSummonDamageDisplayText => "[c/FF4F64:-10%]";
        public override string RaceMeleeSpeedDisplayText => "";
        public override string RaceArmorPenetrationDisplayText => "";
        public override string RaceBulletDamageDisplayText => "[c/FF4F64:-25%]";
        public override string RaceRocketDamageDisplayText => "[c/FF4F64:-25%]";
        public override string RaceManaCostDisplayText => "";
        public override string RaceMinionKnockbackDisplayText => "";
        public override string RaceMinionsDisplayText => "";
        public override string RaceSentriesDisplayText => "";
        public override string RaceMeleeCritChanceDisplayText => "";
        public override string RaceRangedCritChanceDisplayText => "";
        public override string RaceMagicCritChanceDisplayText => "";
        public override string RaceMiningSpeedDisplayText => "";
        public override string RaceBuildingSpeedDisplayText => "";
        public override string RaceBuildingWallSpeedDisplayText => "";
        public override string RaceBuildingRangeDisplayText => "";
        public override string RaceArrowDamageDisplayText => "[c/34EB93:+25%]";
        public override string RaceMovementSpeedDisplayText => "[c/34EB93:+25%]";
        public override string RaceJumpSpeedDisplayText => "[c/34EB93:+20%]";
        public override string RaceFallDamageResistanceDisplayText => "";
        public override string RaceAllDamageDisplayText => "";
        public override string RaceFishingSkillDisplayText => "";
        public override string RaceAggroDisplayText => "";
        public override string RaceRunSpeedDisplayText => "[c/34EB93:+25%]";
        public override string RaceRunAccelerationDisplayText => "[c/34EB93:+25%]";

        public override bool UsesCustomDeathSound => true;

        public override void ResetEffects(Player player)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (modPlayer.RaceStats)
            {
                if (player.wet)
                {
                    player.moveSpeed -= 0.5f;
                    player.runAcceleration -= 0.25f;
                    player.jumpSpeedBoost -= 0.2f;
                    player.maxRunSpeed -= 0.5f;
                    player.allDamage -= 0.15f;
                }

                player.statLifeMax2 -= (int)(player.statLifeMax2 * 0.1f);
                player.meleeDamage -= 0.1f;
                player.minionDamage -= 0.1f;
                player.magicDamage -= 0.1f;
                player.bulletDamage -= 0.25f;
                player.rocketDamage -= 0.25f;
                player.arrowDamage += 0.25f;
                player.jumpSpeedBoost += 0.2f;
                player.moveSpeed += 0.25f;
                player.maxRunSpeed += 0.25f;
                player.runAcceleration += 0.25f;
                crystalPlayer.dodgeChance += 10;
                //player.dash = 1;

                player.breathMax = 100;

                crystalPlayer.amber = true;
            }
            else
            {
                player.breathMax = 200;
            }
        }

        public override bool PreKill(Player player, Mod mod, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            var crystalDragonMod = ModLoader.GetMod("CrystalDragons");
            if (Main.rand.Next(0, 99) == 69)
            {
                Main.PlaySound(SoundLoader.customSoundType, (int)player.Center.X, (int)player.Center.Y, crystalDragonMod.GetSoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Fart_With_Reverb"), 1);
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
                        //do the buff
                       // Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 94));

                        player.AddBuff(ModContent.BuffType<AncientInstinct>(), 600, false);
                        Main.PlaySound(SoundID.DD2_LightningBugDeath.WithVolume(2), player.Center);

                        //10 minute cooldown
                        player.AddBuff(ModContent.BuffType<RacialCooldown>(), (ModContent.GetInstance<CrystalDragonsConfigServer>().RacialCooldown * 60), false);

                        //debug 2s cooldown
                        //player.AddBuff(ModContent.BuffType<RacialCooldown>(), 120, false);
                    }
                }
            }
        }

        public override void PreUpdate(Player player, Mod mod)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            if (modPlayer.RaceStats)
            {
                if (!player.dead)
                {
                    //Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, ModContent.ProjectileType<DiamondHeal>(), 0, 0f, player.whoAmI);
                    //Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<DiamondHeal>(), 0, 0, player.whoAmI);
                }

                //player.buffImmune[BuffID.Frostburn] = true;
                //player.buffImmune[BuffID.Chilled] = true;
                //player.buffImmune[BuffID.Frozen] = true;

                //if (player.lavaWet && !player.lavaImmune && !(player.lavaTime > 0))
                //{
                //    player.Hurt(PlayerDeathReason.ByCustomReason(player.name + "'s weakness to fire got the better of them."), 80, 0, false, false, false);
                //}
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

            crystalPlayer.amber = true;

            if (modPlayer.resetDefaultColors && Main.gameMenu)
            {
                modPlayer.resetDefaultColors = false;
                player.skinColor = new Color(255, 154, 0);
                player.eyeColor = new Color(230, 40, 39);
                player.hairColor = new Color(255, 183, 47);
                player.hair = 25;
            }

        }


        public override void ModifyDrawLayers(Player player, List<PlayerLayer> layers)
        {
            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            var crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            crystalPlayer.amber = true;

            bool hideChestplate = modPlayer.hideChestplate;
            bool hideLeggings = modPlayer.hideLeggings;

            Main.playerTextures[0, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head");
            Main.playerTextures[0, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[0, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[0, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso");

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

            Main.playerTextures[0, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm");

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

            Main.playerTextures[1, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head");
            Main.playerTextures[1, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[1, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[1, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso");

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

            Main.playerTextures[1, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm");

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

            Main.playerTextures[2, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head");
            Main.playerTextures[2, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[2, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[2, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso");

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

            Main.playerTextures[2, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm");

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

            Main.playerTextures[3, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head");
            Main.playerTextures[3, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[3, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[3, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso");

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

            Main.playerTextures[3, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm");

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

            Main.playerTextures[8, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head");
            Main.playerTextures[8, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2");
            Main.playerTextures[8, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes");
            Main.playerTextures[8, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso");

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

            Main.playerTextures[8, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm");

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

            Main.playerTextures[4, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head_Female");
            Main.playerTextures[4, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[4, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[4, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso_Female");

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

            Main.playerTextures[4, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm_Female");

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

            Main.playerTextures[5, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head_Female");
            Main.playerTextures[5, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[5, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[5, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso_Female");

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

            Main.playerTextures[5, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm_Female");

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

            Main.playerTextures[6, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head_Female");
            Main.playerTextures[6, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[6, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[6, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso_Female");

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

            Main.playerTextures[6, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm_Female");

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

            Main.playerTextures[7, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head_Female");
            Main.playerTextures[7, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[7, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[7, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso_Female");

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

            Main.playerTextures[7, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm_Female");

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

            Main.playerTextures[9, 0] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Head_Female");
            Main.playerTextures[9, 1] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_2_Female");
            Main.playerTextures[9, 2] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Eyes_Female");
            Main.playerTextures[9, 3] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Torso_Female");

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

            Main.playerTextures[9, 7] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Amb_Arm_Female");

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


            int numberOfHairStyles = 49;

            for (int i = 0; i < numberOfHairStyles; i++)
            {
                Main.playerHairTexture[i] = ModContent.GetTexture("CrystalDragons/Content/RaceTextures/AmberRaptor/Hair/Amb_Hair_" + (i + 1));
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




