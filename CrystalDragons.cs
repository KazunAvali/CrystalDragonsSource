using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace CrystalDragons
{
	public class CrystalDragons : Mod
	{
        public static CrystalDragons Instance { get; private set; }

        internal UserInterface TopazUI;

        public override void Load()
        {
            MrPlagueRaces.Core.Loadables.LoadableManager.Autoload(this);

            Utilities.SpiritDetours.Initialize();
            AdditiveCallManager.Load();

            TopazUI = new UserInterface();
        }

        public override void Unload()
        {
            MrPlagueRaces.Common.Races.RaceLoader.Races.Clear();
            MrPlagueRaces.Common.Races.RaceLoader.RacesByLegacyIds.Clear();
            MrPlagueRaces.Common.Races.RaceLoader.RacesByFullNames.Clear();
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            //int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            //if (mouseTextIndex != -1)
            //{
            //    layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
            //        "ExampleMod: Coins Per Minute",
            //        delegate {
            //            if (ExampleUI.Visible)
            //            {
            //                _exampleUserInterface.Draw(Main.spriteBatch, new GameTime());
            //            }
            //            return true;
            //        },
            //        InterfaceScaleType.UI)
            //    );
            //}

            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "CrystalDragons: Topaz Tinker",
                    delegate {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
                        TopazUI.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}