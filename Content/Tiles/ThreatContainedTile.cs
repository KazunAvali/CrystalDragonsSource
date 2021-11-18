using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace CrystalDragons.Content.Tiles
{
    internal class ThreatContainedTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Hetuni (Contained)");
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, ItemType<Items.Placeable.ThreatContained>());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            //if(closer)
            //{
                var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();
                crystalPlayer.testNearbyTileName = true;
                //Note: need to add a ModWorld like in examplemod VoidMonolith.
                //make an override ResetNearbyTileEffects() and set the bool to false.
            //}

        }

        //public override void MouseOver(int i, int j)
        //{
        //    Player player = Main.LocalPlayer;
        //    player.noThrow = 2;
        //    player.showItemIcon = true;
        //    player.showItemIcon2 = ItemType<Items.Placeable.ThreatContained>();
        //}
    }
}