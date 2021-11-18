using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MrPlagueRaces.Common.Races;
using CrystalDragons.Common.Races;
using CrystalDragons.Content.Buffs;
using CrystalDragons.Content.Dusts;
using Microsoft.Xna.Framework.Audio;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;
using CrystalDragons.Content.Items.Weapons.Summon.Zones;
using CrystalDragons.Content.Items.Weapons.Ranged;

namespace CrystalDragons.Content
{
    public class CrystalDragonPlayer : ModPlayer
    {
        public bool amethyst = false;
        public bool diamond = false;
        public bool ruby = false;
        public bool amber = false;
        public bool topaz = false;
        public bool sapphire = false;
        public bool emerald = false;

        public bool diamondGuard = false;
        public bool diamondGuardDone = false;
        public bool ancientInstinct = false;
        public bool ancientInstinctDone = false;
        public bool sapphireSurge = false;
        public bool sapphireSurgeDone = false;
        public bool emeraldInstinct = false;

        public int emeraldPrecisionCount = 0;

        public bool gotRaceItems = false;

        public int dodgeChance = 0;

        public bool inventoryOpened;

        public bool testNearbyTileName = false;

        public int nearbyGemTileCount = 0;
        public int nearbyGemBoostCount = 0;

        public enum DragonType
        {
            Amethyst,
            Diamond,
            Ruby,
            Amber,
            Topaz,
            Sapphire,
            Emerald,
            NotADragon
        }

        public DragonType FindDragonType()
        {
            if (amethyst)
            {
                return DragonType.Amethyst;
            }
            else if (diamond)
            {
                return DragonType.Diamond;
            }
            else if (ruby)
            {
                return DragonType.Ruby;
            }
            else if (amber)
            {
                return DragonType.Amber;
            }
            else if (topaz)
            {
                return DragonType.Topaz;
            }
            else if (sapphire)
            {
                return DragonType.Sapphire;
            }
            else if (emerald)
            {
                return DragonType.Emerald;
            }

            return DragonType.NotADragon;
        }

        public override void PostUpdateMiscEffects()
        {
            base.PostUpdateMiscEffects();

            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Mod thorium = ModLoader.GetMod("ThoriumMod");
            Mod calamity = ModLoader.GetMod("CalamityMod");

            if (amethyst && player == Main.LocalPlayer)
            {
                if (modPlayer.RaceStats)
                {
                    player.buffImmune[BuffID.Frostburn] = true;
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;

                    //Thorium-specific debuff immunities
                    if (thorium != null && player.active)
                    {

                    }

                    //Calamity-specific debuff immunities
                    if (calamity != null && player.active)
                    {
                        player.buffImmune[calamity.BuffType("FrozenLungs")] = true;
                        player.buffImmune[calamity.BuffType("GlacialState")] = true;
                    }
                }
            }

            if (diamond && player == Main.LocalPlayer)
            {
                if (modPlayer.RaceStats)
                {
                    player.buffImmune[BuffID.BrokenArmor] = true;
                    player.buffImmune[BuffID.WitheredArmor] = true;
                }
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            base.ModifyHitNPC(item, target, ref damage, ref knockback, ref crit);

            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Mod thorium = ModLoader.GetMod("ThoriumMod");
            Mod calamity = ModLoader.GetMod("CalamityMod");

            //Emerald crit bonuses
            if (emerald && player == Main.LocalPlayer)
            {
                if (modPlayer.RaceStats)
                {
                    if (crit)
                    {
                        damage = (int)(damage * 1.1f);

                        if (emeraldPrecisionCount != 15)
                        {
                            emeraldPrecisionCount++;
                        }

                        ApplyEmeraldPrecision(emeraldPrecisionCount, player);
                    }
                    else
                    {
                        damage = (int)(damage * 0.9f);
                    }

                    if (emeraldInstinct)
                    {
                        target.AddBuff(ModContent.BuffType<EmeraldExploit>(), 600);
                    }
                }
            }
        }


        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPCWithProj(proj, target, ref damage, ref knockback, ref crit, ref hitDirection);

            var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
            Mod thorium = ModLoader.GetMod("ThoriumMod");
            Mod calamity = ModLoader.GetMod("CalamityMod");

            //Emerald crit bonuses
            if (emerald && player == Main.LocalPlayer)
            {
                if (modPlayer.RaceStats)
                {
                    if (calamity != null)
                    {
                        if ((bool)calamity.Call("IsRogue", proj))
                        {
                            //The projectile was a rogue projectile
                        }
                    }

                    if (crit)
                    {
                        damage = (int)(damage * 1.1f);

                        if (emeraldPrecisionCount != 15)
                        {
                            emeraldPrecisionCount++;
                        }

                        ApplyEmeraldPrecision(emeraldPrecisionCount, player);
                    }
                    else
                    {
                        damage = (int)(damage * 0.9f);
                    }

                    if (emeraldInstinct)
                    {
                        target.AddBuff(ModContent.BuffType<EmeraldExploit>(), 600);
                    }
                }
            }

        }

        public void ApplyEmeraldPrecision(int emeraldPrecisionCount, Player player)
        {
            player.AddBuff(mod.BuffType("EmeraldPrecision" + emeraldPrecisionCount), 180);

            for (int i = 0; i < emeraldPrecisionCount; i++)
            {
                if (player.HasBuff(mod.BuffType("EmeraldPrecision" + i)))
                {
                    player.DelBuff(player.FindBuffIndex(mod.BuffType("EmeraldPrecision" + i)));                   
                }
            }
        }

        public void ApplyGemBoost(int gemBoostCount, Player player)
        {
            string gemType = "";

            switch ((int)(FindDragonType()))
            {
                case (int)DragonType.Amethyst:
                    gemType = "Amethyst";
                    break;
                case (int)DragonType.Ruby:
                    gemType = "Ruby";
                    break;
                case (int)DragonType.Diamond:
                    gemType = "Diamond";
                    break;
                case (int)DragonType.Topaz:
                    gemType = "Topaz";
                    break;
                case (int)DragonType.Amber:
                    gemType = "Amber";
                    break;
                case (int)DragonType.Sapphire:
                    gemType = "Sapphire";
                    break;
                case (int)DragonType.Emerald:
                    gemType = "Emerald";
                    break;
                case (int)DragonType.NotADragon:
                    gemType = "";
                    break;
            }

            //removes old tiers of buffs when applying a new one
            for (int i = 0; i < 6; i++)
            {
                if (player.HasBuff(mod.BuffType(gemType + "GemBoost" + i)))
                {
                    player.DelBuff(player.FindBuffIndex(mod.BuffType(gemType + "GemBoost" + i)));
                }
            }

            player.AddBuff(mod.BuffType(gemType + "GemBoost" + gemBoostCount), 20);

        }

        public override void ResetEffects()
        {
            SoundEffectInstance soundEffectInstance = Main.soundInstancePixie;

            base.ResetEffects();

            dodgeChance = 0;
            //nearbyGemBoostCount = 0;

            if (diamondGuard)
            {
                //Main.PlaySoundInstance(soundEffectInstance);
                //Main.PlaySoundInstance(Main.soundInstancePixie);
            }

            if (!diamondGuard && diamondGuardDone)
            {
                soundEffectInstance.Stop();
                Main.PlaySound(SoundID.Item25, player.Center);
            }

            if (ancientInstinct)
            {
                Vector2 eyePosition = new Vector2(player.position.X + 8, player.position.Y + 10);
                Dust dust = Dust.NewDustPerfect(eyePosition, ModContent.DustType<AncientInstinctDust>(), Vector2.Zero, Scale: 8);
                //Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<diamondGuardDust>(), 0f, 0f);
            }

            if (!ancientInstinct && ancientInstinctDone)
            {
                //play stop sound
            }

            if (topaz)
            {
                //Might need to do a MrPlagueRaces player get here to check if using modraces or not to enable/disable


                UserInterface topazTinkerUI = GetInstance<CrystalDragons>().TopazUI;

                //opening and closing the topaz UI depending on if the inventory was just opened or closed.
                if (!inventoryOpened && Main.playerInventory)
                {
                    topazTinkerUI.SetState(new UI.TopazTinkerUI());
                }
                else if (inventoryOpened && !Main.playerInventory)
                {
                    topazTinkerUI.SetState(null);
                }
            }

            if (amethyst && !gotRaceItems && player.active && player == Main.LocalPlayer)
            {
                gotRaceItems = true;
                player.QuickSpawnItem(ModContent.ItemType<SpiritCodex>());
            }

            if (ruby && !gotRaceItems && player.active && player == Main.LocalPlayer)
            {
                gotRaceItems = true;
                player.QuickSpawnItem(ModContent.ItemType<RustyPistol>());
                player.QuickSpawnItem(ItemType<PebbleBullet>(), 100);
            }

            //This is to clear precision count if the player cancels the buff themselves or dies
            if (emerald && player.active && player == Main.LocalPlayer)
            {
                bool shouldReset = true;

                for (int i = 1; i <= emeraldPrecisionCount; i++)
                {
                    if (player.HasBuff(mod.BuffType("EmeraldPrecision" + i)))
                    {
                        shouldReset = false;
                    }
                }

                if (shouldReset)
                {
                    emeraldPrecisionCount = 0;
                }
            }


            inventoryOpened = Main.playerInventory;
            diamondGuardDone = diamondGuard;
            diamondGuard = false;
            ancientInstinctDone = ancientInstinct;
        }

        public override void PostUpdate()
        {
            base.PostUpdate();

            if (sapphire && player == Main.LocalPlayer)
            {
                if (player.HasBuff(BuffType<SapphireSurge>()))
                {
                    player.wet = true;
                }
            }

            if (emerald && emeraldInstinct && player == Main.LocalPlayer)
            {
                player.armorEffectDrawShadowLokis = true;
                player.armorEffectDrawOutlines = true;
                player.armorEffectDrawShadowEOCShield = true;
            }

            //Gem Locks are 9 tiles, so / 9 to get the number of active nearby gem locks.
            nearbyGemBoostCount = nearbyGemTileCount / 9;

            //This is in place because for some reason 4/5 frames the tilecount is 0, so I only want to apply the gem boost and remove previous tiers when it's actually detecting properly.
            if (nearbyGemBoostCount != 0)
            {
                //apply the specific gem boost buff
                ApplyGemBoost(nearbyGemBoostCount, player);
                //Main.NewText("PostUpdate boost count: " + nearbyGemBoostCount + " | tile count: " + nearbyGemTileCount);
            }

            //reset tile count
            nearbyGemTileCount = 0;
        }

        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();

            if (amethyst && player == Main.LocalPlayer)
            {
                var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
                Mod thorium = ModLoader.GetMod("ThoriumMod");
                Mod calamity = ModLoader.GetMod("CalamityMod");

                if (modPlayer.RaceStats)
                {
                    if (thorium != null && player.active)
                    {
                        thorium.Call("BonusHealerDamage", player.whoAmI, 0.15f);
                        thorium.Call("BonusHealerHealBonus", player.whoAmI, 1);
                        thorium.Call("BonusBardDamage", player.whoAmI, -0.25f);
                    }

                    if (calamity != null && player.active)
                    {
                        //calamity.Call("AddRogueDamage", player.whoAmI, -0.25f);
                        calamity.Call("MakeColdImmune", player.whoAmI);
                    }
                }
            }

            if (emerald && player == Main.LocalPlayer)
            {
                var modPlayer = player.GetModPlayer<MrPlagueRaces.MrPlagueRacesPlayer>();
                //Mod thorium = ModLoader.GetMod("ThoriumMod");
                //Mod calamity = ModLoader.GetMod("CalamityMod");

                //if (modPlayer.RaceStats)
                //{
                //    if (thorium != null && player.active)
                //    {
                //        //thorium-specific calls
                //    }

                //    if (calamity != null && player.active)
                //    {
                //        //calamity.Call("AddRogueDamage", player.whoAmI, 0.15f);
                //        calamity.Call("AddRogueCrit", player.whoAmI, 15);
                //    }
                //}

                if (emeraldInstinct)
                {
                    player.armorEffectDrawOutlinesForbidden = true;
                    player.armorEffectDrawShadowLokis = true;
                }
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            base.PostHurt(pvp, quiet, damage, hitDirection, crit);
            
            if (sapphire && player == Main.LocalPlayer)
            {
                player.immuneTime -= (int)(player.immuneTime * 0.5f);
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "gotRaceItems", gotRaceItems },
            };
        }

        public override void Load(TagCompound tag)
        {
            gotRaceItems = tag.GetBool("gotRaceItems");
        }

        public override float UseTimeMultiplier(Item item)
        {
            float bonusSpeed = 0f;

            //bonus of +4% ranged speed per Amber Gem Boost buff
            for (int i = 1; i < 6; i++)
            {
                if (player.HasBuff(mod.BuffType("AmberGemBoost" + i)))
                {
                    bonusSpeed += i * 0.04f;
                }
            }

            if (ancientInstinct && item.ranged && player == Main.LocalPlayer)
            {
                return (3f + bonusSpeed);
            }
            else
            {
                return (base.UseTimeMultiplier(item) + bonusSpeed);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (amethyst && player == Main.LocalPlayer)
            {
                if (player.HasBuff(BuffID.OnFire))
                {
                    player.lifeRegen -= 4;
                }

                if (player.HasBuff(BuffID.Burning))
                {
                    player.lifeRegen -= 40;
                }
            }
        }

        public override void PostUpdateBuffs()
        {
            base.PostUpdateBuffs();

            if (diamond && player == Main.LocalPlayer)
            {
                if (player.HasBuff(BuffID.Tipsy))
                {
                    player.endurance -= 0.1f;
                    player.statDefense -= 4;
                    player.meleeCrit += 2;
                    player.meleeSpeed += 0.1f;
                    player.meleeDamage += 0.1f;
                }
            }

            diamondGuard = player.HasBuff(ModContent.BuffType<DiamondGuard>());
            ancientInstinct = player.HasBuff(ModContent.BuffType<AncientInstinct>());
            emeraldInstinct = player.HasBuff(ModContent.BuffType<EmeraldInstinct>());
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            //Most of this is just for adding the dodge property from Topaz Tinker.
            int dodgeRng = Main.rand.Next(100);

            //Caps dodge chance at 80%, if it rolls over 80 it doesn't dodge.
            if (dodgeRng < dodgeChance && dodgeRng < 80)
            {
                player.immune = true;
                player.immuneTime = 80;
                if (player.longInvince)
                {
                    player.immuneTime += 40;
                }
                for (int i = 0; i < player.hurtCooldowns.Length; i++)
                {
                    player.hurtCooldowns[i] = player.immuneTime;
                }

                //Dust spawning
                for (int j = 0; j < 100; j++)
                {
                    int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
                    Dust expr_A4_cp_0 = Main.dust[num];
                    expr_A4_cp_0.position.X = expr_A4_cp_0.position.X + (float)Main.rand.Next(-20, 21);
                    Dust expr_CB_cp_0 = Main.dust[num];
                    expr_CB_cp_0.position.Y = expr_CB_cp_0.position.Y + (float)Main.rand.Next(-20, 21);
                    Main.dust[num].velocity *= 0.4f;
                    Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                    Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(player.cWaist, player);
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                        Main.dust[num].noGravity = true;
                    }
                }
                int num2 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num2].scale = 1.5f;
                Main.gore[num2].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity *= 0.4f;
                num2 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num2].scale = 1.5f;
                Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity *= 0.4f;
                num2 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num2].scale = 1.5f;
                Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity *= 0.4f;
                num2 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num2].scale = 1.5f;
                Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity *= 0.4f;
                num2 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num2].scale = 1.5f;
                Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
                Main.gore[num2].velocity *= 0.4f;

                //Networking
                if (player.whoAmI == Main.myPlayer)
                {
                    NetMessage.SendData(MessageID.Dodge, -1, -1, null, player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
                }
                return false;
            }
            return true;
        }

        #region Horn & Tail PlayerLayers

        public static readonly PlayerLayer AmethystHorns = new PlayerLayer("CrystalDragons", "AmethystHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            //Setting up variables I'll need later
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            //Getting the custom sprite
            Texture2D texture = mod.GetTexture("Content/RaceTextures/AmethystDragon/Ame_Horns");


            //Determine where the sprite gets drawn. Adding drawPlayer.gfxOffY to Y makes sure it follows the player when they move on slopes, if you don't have that it will jitter up and down.
            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            //This is because the horns are on the head. Basically the head sprite itself moves up and down during the walk cycle, the horns need to move with that bob, and this code makes it do that.
            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            //Initialize the sprite effect I'll be using to flip the sprite
            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                //if the player is upside down, flip vertically as well.
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    //more of the horns bouncing with player walking code
                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                //more of the horns bouncing with player walking code
                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            //Setting up all the data into a DrawData. Setting the color to drawPlayer.GetImmuneAlphaPure makes it so it will flash when the player gets hit.
            //By NOT making the color reference world lighting, the sprite will always be fullbright even in total darkness. This helps make the horn's "glow" effect.
            //If you want the layer to be affected by worldlighting, you'd replace that line with drawPlayer.GetImmuneAlphaPure(Lighting.GetColor(drawX /16, drawY /16, Color.White), drawInfo.shadow)
            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            //This code just adds the faint light that the horns emit in darkness.
            float lightStrength = 0.07f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0.85f * lightStrength), (0.38f * lightStrength), (1f * lightStrength));

            //And finally add the data to the playerDrawData so we can call it later.
            Main.playerDrawData.Add(data);
        });


        public static readonly PlayerLayer AmethystTail = new PlayerLayer("CrystalDragons", "AmethystTail", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/AmethystDragon/Ame_Tail");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
            }

            Rectangle sourceRectangle = drawPlayer.bodyFrame;

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), sourceRectangle, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer DiamondHorns = new PlayerLayer("CrystalDragons", "DiamondHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/DiamondDragon/Dia_Horns");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlpha(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.045f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0.87f * lightStrength), (0.96f * lightStrength), (1f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer DiamondTail = new PlayerLayer("CrystalDragons", "DiamondTail", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/DiamondDragon/Dia_Tail");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
            }

            Rectangle sourceRectangle = drawPlayer.bodyFrame;

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), sourceRectangle, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer AmberHorns = new PlayerLayer("CrystalDragons", "AmberHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/AmberRaptor/Amb_Horns");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlpha(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.07f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0.8f * lightStrength), (0.61f * lightStrength), (0.15f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer RubyHorns = new PlayerLayer("CrystalDragons", "RubyHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/RubyDragon/Rub_Horns");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlpha(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.07f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0.85f * lightStrength), (0.24f * lightStrength), (0.25f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer TopazHorns = new PlayerLayer("CrystalDragons", "TopazHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/TopazKobold/Top_Horns");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlpha(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.07f;
            Lighting.AddLight(new Vector2(drawX, drawY), (1f * lightStrength), (0.84f * lightStrength), (0.27f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer SapphireHorns = new PlayerLayer("CrystalDragons", "SapphireHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/SapphireDragon/Sap_Horns");

            SpriteEffects flip = SpriteEffects.None;

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.15f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0.1f * lightStrength), (0.2f * lightStrength), (1f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer SapphireTail = new PlayerLayer("CrystalDragons", "SapphireTail", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/SapphireDragon/Sap_Tail");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
            }

            Rectangle sourceRectangle = drawPlayer.bodyFrame;

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), sourceRectangle, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer EmeraldHorns = new PlayerLayer("CrystalDragons", "EmeraldHorns", PlayerLayer.Hair, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/EmeraldDragon/Eme_Horns");

            SpriteEffects flip = SpriteEffects.None;

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
            {
                drawY = (int)(drawPlayer.position.Y + 16 + drawPlayer.gfxOffY);
            }

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                    if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                    {
                        drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                    }
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);

                if (drawPlayer.bodyFrame.Y >= (6 * 56) && ((drawPlayer.legFrame.Y >= (7 * 56) && drawPlayer.legFrame.Y <= (9 * 56)) || (drawPlayer.legFrame.Y >= (14 * 56) && drawPlayer.legFrame.Y <= (16 * 56))))
                {
                    drawY = (int)(drawPlayer.position.Y + 26 + drawPlayer.gfxOffY);
                }
            }

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), null, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            float lightStrength = 0.15f;
            Lighting.AddLight(new Vector2(drawX, drawY), (0f * lightStrength), (0.8f * lightStrength), (0.2f * lightStrength));
            Main.playerDrawData.Add(data);
        });

        public static readonly PlayerLayer EmeraldTail = new PlayerLayer("CrystalDragons", "EmeraldTail", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CrystalDragons");

            Texture2D texture = mod.GetTexture("Content/RaceTextures/EmeraldDragon/Eme_Tail");

            int drawX = (int)(drawPlayer.position.X + 10);
            int drawY = (int)(drawPlayer.position.Y + 18 + drawPlayer.gfxOffY);

            SpriteEffects flip = SpriteEffects.None;

            //if the player is facing left, flip horiz
            if (drawPlayer.direction == -1)
            {
                if (drawPlayer.gravDir == -1)
                {
                    flip = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                    drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            //If the player is upside down (e.g. gravity potion), flip vert
            if (drawPlayer.gravDir == -1 && drawPlayer.direction != -1)
            {
                flip = SpriteEffects.FlipVertically;

                drawY = (int)(drawPlayer.position.Y + 24 + drawPlayer.gfxOffY);
            }

            Rectangle sourceRectangle = drawPlayer.bodyFrame;

            DrawData data = new DrawData(texture, (new Vector2(drawX, drawY) - Main.screenPosition), sourceRectangle, drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow), 0f, new Vector2(20, 28), 1f, flip, 0);

            Main.playerDrawData.Add(data);
        });
        #endregion

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            //checking my custom ModPlayer variable that I use to determine which race you are. You don't need something like this unless you have multiple races in one mod.
            if (amethyst)
            {
                //Turn the Horns layer visible and determine where it is in the draw order. This is mostly figured out by experimentation, start on a PlayerLayer close to where you want to have it draw on and add or subtract
                //numbers until the correct stuff is drawing over and under it.
                AmethystHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, AmethystHorns);

                //This is specifically for the tail because it's part of the body sprite in my mod, the tail itself is overwritten when the player is transformed.
                //Because of this I don't want the tail gem to appear when the player is transformed, so I only draw the tail gem's layer if the player is NOT transformed.
                if (!player.wereWolf && !player.merman)
                {
                    AmethystTail.visible = true;
                    layers.Insert(layers.IndexOf(PlayerLayer.Body) + 1, AmethystTail);
                }

                //Make sure you run the base modify draw layers code as well or errors could occur!
                base.ModifyDrawLayers(layers);
            }
            else if (diamond)
            {
                DiamondHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, DiamondHorns);

                if (!player.wereWolf && !player.merman)
                {
                    DiamondTail.visible = true;
                    layers.Insert(layers.IndexOf(PlayerLayer.Body) + 1, DiamondTail);
                }

                base.ModifyDrawLayers(layers);
            }
            else if (ruby)
            {
                RubyHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, RubyHorns);
                base.ModifyDrawLayers(layers);
            }
            else if (amber)
            {
                AmberHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, AmberHorns);
                base.ModifyDrawLayers(layers);
            }
            else if (topaz)
            {
                TopazHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, TopazHorns);
                base.ModifyDrawLayers(layers);
            }
            else if (sapphire)
            {
                SapphireHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, SapphireHorns);

                if (!player.wereWolf && !player.merman)
                {
                    SapphireTail.visible = true;
                    layers.Insert(layers.IndexOf(PlayerLayer.Body) + 1, SapphireTail);
                }

                base.ModifyDrawLayers(layers);
            }
            else if (emerald)
            {
                EmeraldHorns.visible = true;
                layers.Insert(layers.IndexOf(PlayerLayer.Hair) + 2, EmeraldHorns);

                if (!player.wereWolf && !player.merman)
                {
                    EmeraldTail.visible = true;
                    layers.Insert(layers.IndexOf(PlayerLayer.Body) + 1, EmeraldTail);
                }

                base.ModifyDrawLayers(layers);
            }
        }
    }

    public static class CrystalDragonHelpers
    {
        /// <summary>
        /// Heals the player's life by the given amount. If the amount is less or equal to 0, it does nothing.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="healAmount">The amount to heal the player by.</param>
        /// <param name="healer">The other player healing this player. If null, defaults to self healing.</param>
        /// <param name="healOverMax">Whether the healing is always shown regardless of healing amount going over maximum health. defaults to false.</param>
        public static void HealLife(this Player player, int healAmount, Player healer = null, bool healOverMax = false)
        {
            if (!healOverMax && player.statLife >= player.statLifeMax2 || healAmount <= 0)
            {
                return;
            }
            if (!healOverMax && player.statLifeMax2 < healAmount + player.statLife)
            {
                healAmount = player.statLifeMax2 - player.statLife;
            }

            player.statLife += healAmount;

            if (healOverMax && player.statLife > player.statLifeMax2)
            {
                player.statLife = player.statLifeMax2;
            }
            if (healer == null)
            {
                healer = player;
            }
            if (healer.whoAmI == Main.myPlayer)
            {
                player.HealEffect(healAmount);
            }
            if (player.whoAmI != Main.myPlayer)
            {
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, healAmount);
            }
        }

        /// <summary>
        /// Checks if the player is exposed to the sky, platforms don't block sky. If you want platforms to block, use MrPlagueRaces's Modplayer ExposedToSky method.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True if player is exposed to sky, False if not.</returns>
        public static bool ExposedToSkyPlat(this Player player)
        {
            bool hasCeilingTile = false;
            Point playerTileCoordinate = player.Center.ToTileCoordinates();
            Vector2 playerLocation = new Vector2(player.Center.X / 16, player.Center.Y / 16);
            for (int i = 0; i < 60; i++)
            {
                Tile ceilingTile = Main.tile[(int)playerLocation.X, (int)playerLocation.Y];
                if (ceilingTile != null && Main.tileSolid[ceilingTile.type] && !Main.tileSolidTop[ceilingTile.type] && ceilingTile.nactive())
                {
                    hasCeilingTile = true;
                }
                if (playerLocation.Y > 0)
                {
                    playerLocation.Y -= 1;
                }
            }
            return !(playerTileCoordinate.Y <= Main.maxTilesY - 200 && (double)playerTileCoordinate.Y > Main.rockLayer) && !hasCeilingTile;
        }

        public static bool ExposedToSunlight(this Player player)
        {
            Tile[] smallWallTiles = new Tile[2];
            Point playerTilePointSmall = (Main.LocalPlayer.position / 16).ToPoint();
            smallWallTiles[0] = Framing.GetTileSafely(playerTilePointSmall.X, playerTilePointSmall.Y);
            smallWallTiles[1] = Framing.GetTileSafely(playerTilePointSmall.X + 1, playerTilePointSmall.Y);
            bool behindSmallWall = false;
            foreach (var tile in smallWallTiles)
            {
                if (tile.wall > 0)
                {
                    behindSmallWall = true;
                }
                else
                {
                    behindSmallWall = false;
                    break;
                }
            }
            Tile[] wallTiles = new Tile[6];
            Point playerTilePoint = (Main.LocalPlayer.position / 16).ToPoint();
            wallTiles[0] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y);
            wallTiles[1] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y + 1);
            wallTiles[2] = Framing.GetTileSafely(playerTilePoint.X, playerTilePoint.Y + 2);
            wallTiles[3] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y);
            wallTiles[4] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y + 1);
            wallTiles[5] = Framing.GetTileSafely(playerTilePoint.X + 1, playerTilePoint.Y + 2);
            bool behindWall = false;
            foreach (var tile in wallTiles)
            {
                if (tile.wall > 0)
                {
                    behindWall = true;
                }
                else
                {
                    behindWall = false;
                    break;
                }
            }

            ////Commenting out large wall tile check because it fails in multiplayer for some reason out of bounds. This is mostly MrPlague's code, not mine,
            ////So tbh I'm not sure the purpose of this besides just checking if like... there was a HUGE wall that could reasonably block sunlight. Would be
            ////Nice to have, but not required, so I'd rather fix Revengeance and other similar items from not working than have that contingency for my mod.

            //Tile[] largeWallTiles = new Tile[36];
            ////Main.NewText(largeWallTiles.Length);

            ////Point playerTilePointLarge = (Main.LocalPlayer.position / 16).ToPoint();
            //Point playerTilePointLarge = Main.LocalPlayer.position.ToTileCoordinates();

            //for (int i = 0; i < largeWallTiles.Length; i++)
            //{
            //    if (i <= 17)
            //    {
            //        largeWallTiles[i] = Framing.GetTileSafely(playerTilePointLarge.X, playerTilePointLarge.Y + (i - 15));
            //    }
            //    else
            //    {
            //        largeWallTiles[i] = Framing.GetTileSafely(playerTilePointLarge.X + 1, playerTilePointLarge.Y + (i - 33));
            //    }
            //}

            //bool behindLargeWall = false;
            //foreach (var tile in largeWallTiles)
            //{
            //    if (tile.wall > 0)
            //    {
            //        behindLargeWall = true;
            //    }
            //    else
            //    {
            //        behindLargeWall = false;
            //        break;
            //    }
            //}

            bool hasCeilingTile = false;
            Vector2 playerLocation = new Vector2(player.Center.X / 16, player.Center.Y / 16);
            for (int i = 0; i < 60; i++)
            {
                Tile ceilingTile = Main.tile[(int)playerLocation.X, (int)playerLocation.Y];
                if (ceilingTile != null && Main.tileSolid[ceilingTile.type] && ceilingTile.nactive())
                {
                    hasCeilingTile = true;
                }
                if (playerLocation.Y > 0)
                {
                    playerLocation.Y -= 1;
                }
            }
            bool hasCeilingAbove = false;
            if (hasCeilingTile)// || behindLargeWall)
            {
                hasCeilingAbove = true;
            }
            else
            {
                hasCeilingAbove = false;
            }

            return (!hasCeilingAbove || !behindSmallWall) && !((double)player.Center.Y > Main.worldSurface * 16.0) && Main.dayTime && !(Collision.DrownCollision(player.position, player.width, player.height, player.gravDir));
        }

        /// <summary>
        /// Start a Rain event
        /// </summary>
        public static void StartRain()
        {
            int num = 86400;
            int num2 = num / 24;

            Main.rainTime = Main.rand.Next(num2 * 8, num);
            if (Main.rand.Next(3) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2);
            }
            if (Main.rand.Next(4) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(5) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(6) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 3);
            }
            if (Main.rand.Next(7) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 4);
            }
            if (Main.rand.Next(8) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 5);
            }
            float num3 = 1f;
            if (Main.rand.Next(2) == 0)
            {
                num3 += 0.05f;
            }
            if (Main.rand.Next(3) == 0)
            {
                num3 += 0.1f;
            }
            if (Main.rand.Next(4) == 0)
            {
                num3 += 0.15f;
            }
            if (Main.rand.Next(5) == 0)
            {
                num3 += 0.2f;
            }

            Main.rainTime = (int)((float)Main.rainTime * num3);
            ChangeRain();
            Main.raining = true;

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        /// <summary>
        /// More rain helpers, shouldn't be called outside of the StartRain() method.
        /// </summary>
        private static void ChangeRain()
        {
            if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150.0)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
                }
                else
                {
                    Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
                }
            }
            else if ((double)Main.numClouds > 100.0)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
                }
                else
                {
                    Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
                }
            }
            else if (Main.rand.Next(3) == 0)
            {
                Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
            }
            else
            {
                Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}