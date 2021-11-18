using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Items.Weapons.Ranged
{
    public class PebbleBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A makeshift bullet made of crushed stone.");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 0.5f;
            item.value = 10;
            item.rare = ItemRarityID.Blue;
            item.shoot = ProjectileID.Bullet;   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
        }

        //// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
        //public override void OnConsumeAmmo(Player player)
        //{
        //    if (Main.rand.NextBool(5))
        //    {
        //        player.AddBuff(BuffID.Wrath, 300);
        //    }
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}