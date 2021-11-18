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
    public class CrystalDragonsWorld : ModWorld
    {
        public override void ResetNearbyTileEffects()
        {
            var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();
            crystalPlayer.testNearbyTileName = false;
        }
    }
}
