using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrystalDragons.Content.Projectiles.Summon.Zones;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Terraria.ModLoader.IO;
using System.Collections.Generic;

namespace CrystalDragons.Content.Items.Weapons.Summon.Zones
{
    public class SpiritCodex : ModItem
    {
        int level = 0;
        int activeCodex = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Codex");
            Tooltip.SetDefault("Only Amethyst dragons can channel the magic contained in these tomes.\nSummon a Zone that provides various buffs or debuffs.\nZones count as sentries.\nRight click to change the spell selected. Unlock more spells with boss progression.\nFrom Spirit Mod, Used with permission.\nSpells unlocked:");
            SetGlowMask();
            item.rare = ItemRarityID.Expert;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(item.position, 0.217f, .184f, .037f);
            Texture2D texture;
            texture = Main.itemTexture[item.type];

            Texture2D glowTexture = null;

            switch (activeCodex)
            {
                case 0:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/HealingCodex_Glow");
                    break;
                case 1:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/StaminaCodex_Glow");
                    break;
                case 2:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/RepulsionCodex_Glow");
                    break;
                case 3:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/DefenseCodex_Glow");
                    break;
                case 4:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/SlowCodex_Glow");
                    break;
                case 5:
                    glowTexture = mod.GetTexture("Content/Items/Weapons/Summon/Zones/DefenseCodex_Glow");
                    break;
            }

            spriteBatch.Draw
            (
                glowTexture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.summon = true;
            item.mana = 10;
            item.width = 54;
            item.height = 50;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 10;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.DD2_EtherianPortalSpawnEnemy;
            item.autoReuse = false;
            item.rare = ItemRarityID.Expert;

            SelectCodex();
            SetGlowMask();

            item.shootSpeed = 0f;
        }

        public override TagCompound Save() => new TagCompound
        {
            {nameof(level),level },
            {nameof(activeCodex),activeCodex }
        };

        void SetGlowMask()
        {
            switch (activeCodex)
            {
                case 0:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/HealingCodex_Glow", mod);
                    break;
                case 1:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/StaminaCodex_Glow", mod);
                    break;
                case 2:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/RepulsionCodex_Glow", mod);
                    break;
                case 3:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/DefenseCodex_Glow", mod);
                    break;
                case 4:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/SlowCodex_Glow", mod);
                    break;
                case 5:
                    SpiritGlowmask.Unload();
                    SpiritGlowmask.AddGlowMask(item.type, "Content/Items/Weapons/Summon/Zones/DefenseCodex_Glow", mod);
                    break;
            }
        }

        void SelectCodex()
        {
            switch (activeCodex)
            {
                case 0:
                    item.shoot = ModContent.ProjectileType<HealingZone>();
                    break;
                case 1:
                    item.shoot = ModContent.ProjectileType<StaminaZone>();
                    break;
                case 2:
                    item.shoot = ModContent.ProjectileType<RepulsionZone>();
                    break;
                case 3:
                    item.shoot = ModContent.ProjectileType<DefenseZone>();
                    break;
                case 4:
                    item.shoot = ModContent.ProjectileType<SlowZone>();
                    break;
                case 5:
                    item.shoot = ModContent.ProjectileType<DefenseZone>();
                    break;
            }
        }

        public override void Load(TagCompound tag)
        {
            if (!tag.ContainsKey(nameof(level)))
            {
                return;
            }

            level = tag.Get<int>(nameof(level));
            activeCodex = tag.Get<int>(nameof(activeCodex));

            ApplyStats();
        }

        //Net
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(level);
            writer.Write(activeCodex);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            level = reader.ReadInt32();
            activeCodex = reader.ReadInt32();

            ApplyStats();
        }

        public void ApplyStats()
        {
            level = 1;

            ////Eye of Cthulu
            //if (NPC.downedBoss1)
            //{
            //    rubyBombDamage = 560;
            //}

            //SKELEMAN
            if (NPC.downedBoss3)
            {
                //Level 2
                level = 2;
            }

            //Wall of Flesh
            if (Main.hardMode)
            {
                //Level 3
                level = 3;
            }

            //Any Mecha
            if (NPC.downedMechBossAny)
            {
                //Level 4
                level = 4;
            }

            ////Plantera
            //if (NPC.downedPlantBoss)
            //{
            //    //Level 4
            //    level = 4;
            //}

            //Golem
            if (NPC.downedGolemBoss)
            {
                //Level 5
                //level = 5;
            }

            //Moon Lord
            if (NPC.downedMoonlord)
            {
                //Bonus level or something?
            }

            SelectCodex();
            SetGlowMask();
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ApplyStats();
            if(level >= 1)
            {
                var unlock1 = new TooltipLine(mod, "Spirit Codex", "Healing");
                unlock1.overrideColor = Color.Red;
                tooltips.Add(unlock1);
                var unlock2 = new TooltipLine(mod, "Spirit Codex", "Stamina");
                unlock2.overrideColor = Color.Green;
                tooltips.Add(unlock2);
            }
            if (level >= 2)
            {
                var unlock = new TooltipLine(mod, "Spirit Codex", "Repulsion");
                unlock.overrideColor = new Color(147, 105, 255);
                tooltips.Add(unlock);
            }
            if (level >= 3)
            {
                var unlock = new TooltipLine(mod, "Spirit Codex", "Defense");
                unlock.overrideColor = Color.Yellow;
                tooltips.Add(unlock);
            }
            if (level >= 4)
            {
                var unlock = new TooltipLine(mod, "Spirit Codex", "Slow");
                unlock.overrideColor = Color.Cyan;
                tooltips.Add(unlock);
            }
            if (level >= 5)
            {
                var unlock = new TooltipLine(mod, "Spirit Codex", "Unused");
                unlock.overrideColor = Color.Red;
                tooltips.Add(unlock);
            }

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            CrystalDragonPlayer crystalPlayer = player.GetModPlayer<CrystalDragonPlayer>();

            if (crystalPlayer.amethyst)
            {
                if (player.altFunctionUse == 2)
                {
                    activeCodex++;
                    
                    if (activeCodex > level)
                    {
                        activeCodex = 0;
                    }

                    ApplyStats();
                    //Main.NewText("Active Codex: " + activeCodex);
                    //Main.NewText("Level: " + level);
                }
                else
                {
                    Vector2 value18 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    position = value18;

                    //can set type here manually if I need to but will miss all other aspects of the projectile. Need to figure out if there's a "preshoot" or something.

                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                    player.UpdateMaxTurrets();
                }

                return false;
            }
            else
            {
                Main.PlaySound(SoundID.Item32);
                return false;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.BewitchingTable);
            recipe.RecipeAvailable(); //need to override this
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}