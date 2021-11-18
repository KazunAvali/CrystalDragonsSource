﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Items.Labels
{
    public class RacialCooldownReady : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Just used for the label.");
        }

        public override void SetDefaults()
        {
            //item.damage = 7; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            //item.ranged = true; // sets the damage type to ranged
            //item.width = 40; // hitbox width of the item
            //item.height = 20; // hitbox height of the item
            //item.useTime = 35; // The item's use time in ticks (60 ticks == 1 second.)
            //item.useAnimation = 36; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            //item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
            //item.noMelee = true; //so the item's animation doesn't do damage
            //item.knockBack = 2.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            //item.value = 10; // how much the item sells for (measured in copper)
            item.rare = ItemRarityID.Orange; // the color that the item's name will be in-game
            //item.UseSound = SoundID.Item11; // The sound that this item plays when used.
            //item.autoReuse = true; // if you can hold click to automatically use it again
            //item.shoot = 10; //idk why but all the guns in the vanilla source have this
            //item.shootSpeed = 6f; // the speed of the projectile (measured in pixels per frame)
            //item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
        }
    }
}