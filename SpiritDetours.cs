using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Linq;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace CrystalDragons.Utilities
{
    public static class SpiritDetours
    {
        public static void Initialize()
        {
            //On.Terraria.Main.DrawProjectiles += Main_DrawProjectiles;
            //On.Terraria.Main.DrawNPCs += Main_DrawNPCs;
            //On.Terraria.Main.DrawPlayers += Main_DrawPlayers;
            //On.Terraria.Projectile.NewProjectile_float_float_float_float_int_int_float_int_float_float += Projectile_NewProjectile;
            //On.Terraria.Player.KeyDoubleTap += Player_KeyDoubleTap;
            On.Terraria.Main.DrawDust += AddtiveCalls;
            //On.Terraria.Player.ToggleInv += Player_ToggleInv;
            //On.Terraria.Main.DrawInterface += DrawParticles;
            //On.Terraria.Localization.LanguageManager.GetTextValue_string += LanguageManager_GetTextValue_string1;

            //On.Terraria.Main.DrawPlayerChat += Main_DrawPlayerChat;

            //On.Terraria.Main.DrawNPCChatButtons += Main_DrawNPCChatButtons;
            //On.Terraria.WorldGen.SpreadGrass += WorldGen_SpreadGrass;

            //IL.Terraria.Player.ItemCheck += Player_ItemCheck;
            //IL.Terraria.WorldGen.hardUpdateWorld += WorldGen_hardUpdateWorld;
            //Main.OnPreDraw += Main_OnPreDraw;
        }

        public static void Unload()
        {
            //On.Terraria.Main.DrawProjectiles -= Main_DrawProjectiles;
            //On.Terraria.Main.DrawNPCs -= Main_DrawNPCs;
            //On.Terraria.Main.DrawPlayers -= Main_DrawPlayers;
            //On.Terraria.Projectile.NewProjectile_float_float_float_float_int_int_float_int_float_float -= Projectile_NewProjectile;
            //On.Terraria.Player.KeyDoubleTap -= Player_KeyDoubleTap;
            On.Terraria.Main.DrawDust -= AddtiveCalls;
            //On.Terraria.Player.ToggleInv -= Player_ToggleInv;
            //On.Terraria.Main.DrawInterface -= DrawParticles;
            //On.Terraria.Localization.LanguageManager.GetTextValue_string -= LanguageManager_GetTextValue_string1;
            //On.Terraria.Main.DrawNPCChatButtons -= Main_DrawNPCChatButtons;
            //On.Terraria.WorldGen.SpreadGrass -= WorldGen_SpreadGrass;
            //Main.OnPreDraw -= Main_OnPreDraw;
        }

        private static void AddtiveCalls(On.Terraria.Main.orig_DrawDust orig, Main self)
        {
            AdditiveCallManager.DrawAdditiveCalls(Main.spriteBatch);
            orig(self);
        }
    }
}