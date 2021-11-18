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
    public class CrystalDragonsGlobalTile : GlobalTile
    {
        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            base.NearbyEffects(i, j, type, closer);

            if (type == TileID.GemLocks)
            {
				//Check the gem locks, apply a gemcount++ or something in player
				Tile tileSafely = Framing.GetTileSafely(i, j);
				if (!tileSafely.active() || (tileSafely.frameY < 54))
				{
					//Not active, do nothing.
					return;
				}

				//determine the gem type by checking what sprite is displayed
				int tileSpritePosition = Main.tile[i, j].frameX / 54;

				//default amethyst
				int gemItemID = 1522;

				var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();

				switch (tileSpritePosition)
				{
					case 0:
						//ruby
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.ruby)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1526;
						break;
					case 1:
						//sapphire
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.sapphire)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1524;
						break;
					case 2:
						//emerald
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.emerald)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1525;
						break;
					case 3:
						//topaz
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.topaz)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1523;
						break;
					case 4:
						//amethyst
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.amethyst)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1522;
						break;
					case 5:
						//diamond
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.diamond)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 1527;
						break;
					case 6:
						//amber
						if (crystalPlayer.player == Main.LocalPlayer && crystalPlayer.amber)
						{
							crystalPlayer.nearbyGemTileCount++;
						}
						gemItemID = 3643;
						break;
				}
				
				//Cap the number of boosts possible.
				int capBoosts = 5;
				int numOfTilesPerGemLock = 9;

				int capValue = capBoosts * numOfTilesPerGemLock;

				if (crystalPlayer.nearbyGemTileCount > capValue)
                {
					crystalPlayer.nearbyGemTileCount = capValue;
                }
			}
        }

		//public static void ToggleGemLock(int i, int j, bool on)
		//{
		//	Tile tileSafely = Framing.GetTileSafely(i, j);
		//	if (!tileSafely.active() || tileSafely.type != 440 || (tileSafely.frameY < 54 && !on))
		//	{
		//		return;
		//	}
		//	bool flag = false;
		//	int num = -1;
		//	if (tileSafely.frameY >= 54)
		//	{
		//		flag = true;
		//	}
		//	int num2 = Main.tile[i, j].frameX / 54;
		//	int num3 = Main.tile[i, j].frameX % 54 / 18;
		//	int num4 = Main.tile[i, j].frameY % 54 / 18;
		//	switch (num2)
		//	{
		//		case 0:
		//			//ruby
		//			num = 1526;
		//			break;
		//		case 1:
		//			//sapphire
		//			num = 1524;
		//			break;
		//		case 2:
		//			//emerald
		//			num = 1525;
		//			break;
		//		case 3:
		//			//topaz
		//			num = 1523;
		//			break;
		//		case 4:
		//			//amethyst
		//			num = 1522;
		//			break;
		//		case 5:
		//			//diamond
		//			num = 1527;
		//			break;
		//		case 6:
		//			//amber
		//			num = 3643;
		//			break;
		//	}
		//	for (int k = i - num3; k < i - num3 + 3; k++)
		//	{
		//		for (int l = j - num4; l < j - num4 + 3; l++)
		//		{
		//			Main.tile[k, l].frameY = (short)((on ? 54 : 0) + (l - j + num4) * 18);
		//		}
		//	}
		//	if (num != -1 && flag)
		//	{
		//		Item.NewItem(i * 16, j * 16, 32, 32, num);
		//	}
		//	WorldGen.SquareTileFrame(i, j);
		//	NetMessage.SendTileSquare(-1, i - num3 + 1, j - num4 + 1, 3);
		//	Wiring.HitSwitch(i - num3, j - num4);
		//	NetMessage.SendData(59, -1, -1, null, i - num3, j - num4);
		//}
	}
}
