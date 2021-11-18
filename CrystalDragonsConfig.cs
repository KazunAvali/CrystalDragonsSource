using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CrystalDragons.Config
{
    [Label("Server Settings")]
    public class CrystalDragonsConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Increment(10)]
        [Range(10, 1800)]
        [DefaultValue(600)]
        [Slider] // The Slider attribute makes this field be presented with a slider rather than a text input. The default ticks is 1.
        [Label("Racial Cooldown (seconds)")]
        public int RacialCooldown;

        [DefaultValue(typeof(bool), "true")]//There are different types of configs. Sliders, booleans and more. Well in your case you'll just need a boolean. Since you want it to be visible by default, we'll set it to true as shown.
        [Label("Topaz Kobold Sunlight Weakness")]//Here is the name in game of our config. Name it whatever you want. Be sure to make it short and easily understandable/
        [Tooltip("Turn on or off the sunlight weakness debuff for Topaz Kobolds.")]
        public bool TopSunlightWeak { get; set; }//Here we set the name of the config in the code. Name it whatever you want.
    }

    [Label("Personal Settings")]
    public class CrystalDragonsConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide; //Ok, here we decide whether this config file scopes in a server or in a client. For client we do as shown, for server we do `ConfigScope.ServerSide` Do not know much about server sided configs tho.

        [DefaultValue(typeof(bool), "true")]//There are different types of configs. Sliders, booleans and more. Well in your case you'll just need a boolean. Since you want it to be visible by default, we'll set it to true as shown.
        [Label("Amethyst Aura Visuals")]//Here is the name in game of our config. Name it whatever you want. Be sure to make it short and easily understandable/
        public bool AmeAuraVisible { get; set; }//Here we set the name of the config in the code. Name it whatever you want.

        [Increment(10)]
        [Range(10, 100)]
        [DefaultValue(100)]
        [Slider]
        [Label("Spirit Codex Field Opacity")]
        public int AmeCodexOpacity;


        //ADD SLIDER FOR SPIRIT BOOK OPACITY
    }
}