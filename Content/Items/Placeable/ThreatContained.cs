using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Tiles;
using Terraria.ID;

namespace CrystalDragons.Content.Items.Placeable
{
    public class ThreatContained : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hetuni (Contained)");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = TileType<Tiles.ThreatContainedTile>();
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Expert;
            item.value = 100000;
            item.accessory = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bird, 1);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.RecipeAvailable();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
