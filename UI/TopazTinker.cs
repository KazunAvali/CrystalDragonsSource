using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Buffs;
using CrystalDragons.Content;
using CrystalDragons.Config;
using CrystalDragons.Items;

namespace CrystalDragons.UI
{
    // This class represents the UIState for our ExamplePerson Awesomeify chat function. It is similar to the Goblin Tinkerer's Reforge function, except it only gives Awesome and ReallyAwesome prefixes. 
    internal class TopazTinkerUI : UIState
    {
        private VanillaItemSlotWrapper _vanillaItemSlot;
        private VanillaItemSlotWrapper _vanillaItemSlotInvTest;

        public override void OnInitialize()
        {
            var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();

            if (crystalPlayer.topaz)
            {
                _vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
                {
                    Left = { Pixels = 496 },
                    Top = { Pixels = 20 },
                    ValidItemFunc = item => item.IsAir || !item.IsAir && item.Prefix(-3) && item.accessory
                };

                // Here we limit the items that can be placed in the slot. We are fine with placing an empty item in or a non-empty item that can be prefixed. Calling Prefix(-3) is the way to know if the item in question can take a prefix or not.
                Append(_vanillaItemSlot);
            }
        }

        // OnDeactivate is called when the UserInterface switches to a different state. In this mod, we switch between no state (null) and this state (ExamplePersonUI).
        // Using OnDeactivate is useful for clearing out Item slots and returning them to the player, as we do here.
        public override void OnDeactivate()
        {
            var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();

            if (crystalPlayer.topaz)
            {
                if (!_vanillaItemSlot.Item.IsAir)
                {
                    // QuickSpawnClonedItem will preserve mod data of the item. QuickSpawnItem will just spawn a fresh version of the item, losing the prefix.
                    Main.LocalPlayer.QuickSpawnClonedItem(_vanillaItemSlot.Item, _vanillaItemSlot.Item.stack);
                    // Now that we've spawned the item back onto the player, we reset the item by turning it into air.
                    _vanillaItemSlot.Item.TurnToAir();
                }
            }
        }

        // Update is called on a UIState while it is the active state of the UserInterface.
        // We use Update to handle automatically closing our UI when the player is no longer talking to our Example Person NPC.
        public override void Update(GameTime gameTime)
        {
            // Don't delete this or the UIElements attached to this UIState will cease to function.
            base.Update(gameTime);
        }

        private bool tickPlayed;

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            var crystalPlayer = Main.LocalPlayer.GetModPlayer<CrystalDragonPlayer>();

            if (!Main.LocalPlayer.HasBuff(BuffType<RacialCooldown>()) && crystalPlayer.topaz)
            {
                // This will hide the crafting menu similar to the reforge menu. For best results this UI is placed before "Vanilla: Inventory" to prevent 1 frame of the craft menu showing.
                //Main.HidePlayerCraftingMenu = true;

                // Here we have a lot of code. This code is mainly adapted from the vanilla code for the reforge option.
                // This code draws "Place an item here" when no item is in the slot and draws the reforge cost and a reforge button when an item is in the slot.
                // This code could possibly be better as different UIElements that are added and removed, but that's not the main point of this example.
                // If you are making a UI, add UIElements in OnInitialize that act on your ItemSlot or other inputs rather than the non-UIElement approach you see below.

                const int slotX = 496;
                const int slotY = 30;
                if (!_vanillaItemSlot.Item.IsAir)
                {
                    //int awesomePrice = Item.buyPrice(0, 0, 0, 0);

                    //string costText = Language.GetTextValue("LegacyInterface.46") + ": ";
                    //string coinsText = "";
                    //int[] coins = Utils.CoinsSplit(awesomePrice);
                    //if (coins[3] > 0)
                    //{
                    //    coinsText = coinsText + "[c/" + Colors.AlphaDarken(Colors.CoinPlatinum).Hex3() + ":" + coins[3] + " " + Language.GetTextValue("LegacyInterface.15") + "] ";
                    //}
                    //if (coins[2] > 0)
                    //{
                    //    coinsText = coinsText + "[c/" + Colors.AlphaDarken(Colors.CoinGold).Hex3() + ":" + coins[2] + " " + Language.GetTextValue("LegacyInterface.16") + "] ";
                    //}
                    //if (coins[1] > 0)
                    //{
                    //    coinsText = coinsText + "[c/" + Colors.AlphaDarken(Colors.CoinSilver).Hex3() + ":" + coins[1] + " " + Language.GetTextValue("LegacyInterface.17") + "] ";
                    //}
                    //if (coins[0] > 0)
                    //{
                    //    coinsText = coinsText + "[c/" + Colors.AlphaDarken(Colors.CoinCopper).Hex3() + ":" + coins[0] + " " + Language.GetTextValue("LegacyInterface.18") + "] ";
                    //}

                    //ItemSlot.DrawSavings(Main.spriteBatch, slotX + 130, Main.instance.invBottom, true);
                    //ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, costText, new Vector2(slotX + 50, slotY), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, Vector2.Zero, Vector2.One, -1f, 2f);
                    //ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, coinsText, new Vector2(slotX + 50 + Main.fontMouseText.MeasureString(costText).X, (float)slotY), Color.White, 0f, Vector2.Zero, Vector2.One, -1f, 2f);

                    int reforgeX = slotX + 70;
                    int reforgeY = slotY + 40;
                    bool hoveringOverReforgeButton = Main.mouseX > reforgeX - 15 && Main.mouseX < reforgeX + 15 && Main.mouseY > reforgeY - 15 && Main.mouseY < reforgeY + 15 && !PlayerInput.IgnoreMouseInterface;
                    Texture2D reforgeTexture = Main.reforgeTexture[hoveringOverReforgeButton ? 1 : 0];
                    Main.spriteBatch.Draw(reforgeTexture, new Vector2(reforgeX, reforgeY), null, Color.White, 0f, reforgeTexture.Size() / 2f, 0.8f, SpriteEffects.None, 0f);
                    if (hoveringOverReforgeButton)
                    {
                        Main.hoverItemName = Language.GetTextValue("LegacyInterface.19");
                        if (!tickPlayed)
                        {
                            Main.PlaySound(12, -1, -1, 1, 1f, 0f);
                        }
                        tickPlayed = true;
                        Main.LocalPlayer.mouseInterface = true;
                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.LocalPlayer.CanBuyItem(0, -1) && ItemLoader.PreReforge(_vanillaItemSlot.Item))
                        {
                            Main.LocalPlayer.BuyItem(0, -1);
                            bool favorited = _vanillaItemSlot.Item.favorited;
                            int stack = _vanillaItemSlot.Item.stack;
                            Item reforgeItem = new Item();
                            reforgeItem.netDefaults(_vanillaItemSlot.Item.netID);
                            reforgeItem = reforgeItem.CloneWithModdedDataFrom(_vanillaItemSlot.Item);

                            

                            //setting base roll ranges and caps
                            int commonRange = 25;
                            int numOfCommons = 7;
                            int finalCommonRng = (commonRange * numOfCommons);

                            int rareRange = 5;
                            int numOfRares = 7;

                            int additionalLAKErng = 69;

                            int rngCap = (commonRange * numOfCommons) + (rareRange * numOfRares);

                            //increasing rng cap by 1 per rare roll, start of the giving a 2.6% to 2.1% boost to rares.
                            for (int i = 1; i < 6; i++)
                            {
                                if (Main.LocalPlayer.HasBuff(crystalPlayer.mod.BuffType("TopazGemBoost" + i)) && crystalPlayer.topaz)
                                {
                                    rngCap += i * 7;
                                    rareRange += i;

                                    if (i == 5)
                                    {
                                        //adds an additional chance to get LAKE boosting it from 0.47% → 0.81% if you have the cap buff. 
                                        additionalLAKErng = 169;
                                    }
                                }
                            }

                            int rng = Main.rand.Next(0, rngCap);
                            //Main.NewText("rng: " + rng + " | cap : " + rngCap);

                            if (rng < commonRange)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazWarding"));
                            }
                            else if (rng < commonRange*2)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazShinobi"));
                            }
                            else if (rng == 69 || rng == additionalLAKErng) //nice
                            {
                                reforgeItem.rare = ItemRarityID.Expert;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("L A K E"));
                            }
                            else if (rng < commonRange*3)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazBalanced"));
                            }
                            else if (rng < commonRange*4)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazStriking"));
                            }
                            else if (rng < commonRange*5)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazStrong"));
                            }
                            else if (rng < commonRange*6)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazFleet"));
                            }
                            else if (rng < commonRange*7)
                            {
                                reforgeItem.rare += 2;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazDestructive"));
                            }

                            //Start of the rarity change based on the TopazGemBoost. checks finalCommonRng + rareRange for the base number (e.g. 1 rare range would be 175 + 6 = 181)
                            //then adds another rarerange per slot for offset. e.g. 1 range slot 0 is 181 instead of base 180, slot 1 is 175+6+6 = 187 so the range is 181-186, slot 2 
                            //is 175+6+6+6 = 193 so range is 187-193, etc. This keeps the rarity ranges bumped up dynamically.
                            else if (rng < finalCommonRng + rareRange)
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazBulwark"));
                            }
                            else if (rng < finalCommonRng + (rareRange * 2))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazIai"));
                            }
                            else if (rng < finalCommonRng + (rareRange * 3))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazEqualized"));
                            }
                            else if (rng < finalCommonRng + (rareRange * 4))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazEviscerating"));
                            }
                            else if (rng < finalCommonRng + (rareRange * 5))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazAnnihilating"));
                            }
                            else if (rng < finalCommonRng + (rareRange * 6))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazMighty"));
                            }
                            else if (rng <= finalCommonRng + (rareRange * 7))
                            {
                                reforgeItem.rare += 3;
                                reforgeItem.Prefix(GetInstance<CrystalDragons>().PrefixType("TopazQuantum"));
                            }

                            _vanillaItemSlot.Item = reforgeItem.Clone();
                            _vanillaItemSlot.Item.position.X = Main.LocalPlayer.position.X + (float)(Main.LocalPlayer.width / 2) - (float)(_vanillaItemSlot.Item.width / 2);
                            _vanillaItemSlot.Item.position.Y = Main.LocalPlayer.position.Y + (float)(Main.LocalPlayer.height / 2) - (float)(_vanillaItemSlot.Item.height / 2);
                            _vanillaItemSlot.Item.favorited = favorited;
                            _vanillaItemSlot.Item.stack = stack;

                            ItemLoader.PostReforge(_vanillaItemSlot.Item);
                            ItemText.NewText(_vanillaItemSlot.Item, _vanillaItemSlot.Item.stack, true, false);
                            Main.PlaySound(SoundID.Item37, -1, -1);

                            //10 minute cooldown
                            Main.LocalPlayer.AddBuff(ModContent.BuffType<RacialCooldown>(), (ModContent.GetInstance<CrystalDragonsConfigServer>().RacialCooldown * 60), false);

                            //debug 2s cooldown
                            //Main.LocalPlayer.AddBuff(ModContent.BuffType<RacialCooldown>(), 120, false);
                        }
                    }
                    else
                    {
                        tickPlayed = false;
                    }
                }
                else
                {
                    string message = "Topaz Tinker";
                    ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, message, new Vector2(slotX + 50, slotY), Color.Orange, 0f, Vector2.Zero, Vector2.One, -1f, 2f);
                }
            }
        }
    }
}
