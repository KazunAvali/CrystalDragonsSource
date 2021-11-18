using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CrystalDragons.Content.Buffs;

namespace CrystalDragons.Content.Projectiles
{
	public class AmethystHeal : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.width = 600;
			projectile.height = 600;
			projectile.alpha = 10;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 10;
            projectile.ignoreWater = true;
		}

		public override bool? CanCutTiles() 
		{
			return false;
		}

		public override void AI() 
		{
            //Dust 178 is "light green particles" from Dust & Sound 2 mod

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];

                if (player.active && (player.whoAmI == projectile.owner))
                {
                    projectile.width = player.statManaMax2 * 3;
                    projectile.height = player.statManaMax2 * 3;
                    projectile.Center = player.Center;
                }
            }

            Rectangle bounds = projectile.getRect();

            for (int i = 0; i < Main.maxPlayers; i++)
		    {
			    Player player = Main.player[i];
                //Able to exclude Amethyst themselves with commented line.
                if (player.active && bounds.Intersects(player.getRect())) // && player.whoAmI != projectile.owner)
			    {
                    if (!(player.statLife == player.statLifeMax2))
					{
						 player.AddBuff(ModContent.BuffType<AmethystHealing>(), 60);
			        }
			    }
		    }
		}
	}
}