using Microsoft.Xna.Framework;
using CrystalDragons.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CrystalDragons.Content.Projectiles
{
    public class RubyBombardment : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Bombardment");
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.alpha = 255;
            projectile.timeLeft = 1;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            ProjectileExtras.Explode(projectile.whoAmI, 600, 600,
            delegate
            {
                for (int i = 0; i < 60; i++)
                {
                    int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].scale = 4f;
                    Dust expr_62_cp_0 = Main.dust[num];
                    expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_0 = Main.dust[num];
                    expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num].position != projectile.Center)
                    {
                        Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 30f;
                    }



                    int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num2].noGravity = true;
                    Main.dust[num2].scale = 4f;
                    Dust expr_62_cp_1 = Main.dust[num2];
                    expr_62_cp_1.position.X = expr_62_cp_1.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_1 = Main.dust[num2];
                    expr_92_cp_1.position.Y = expr_92_cp_1.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num2].position != projectile.Center)
                    {
                        Main.dust[num2].velocity = projectile.DirectionTo(Main.dust[num2].position) * 26f;
                    }


                    int num3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].scale = 4f;
                    Dust expr_62_cp_2 = Main.dust[num3];
                    expr_62_cp_2.position.X = expr_62_cp_2.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_2 = Main.dust[num3];
                    expr_92_cp_2.position.Y = expr_92_cp_2.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num3].position != projectile.Center)
                    {
                        Main.dust[num3].velocity = projectile.DirectionTo(Main.dust[num3].position) * 24f;
                    }

                    int num4 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num4].noGravity = true;
                    Main.dust[num4].scale = 4f;
                    Dust expr_62_cp_3 = Main.dust[num4];
                    expr_62_cp_3.position.X = expr_62_cp_3.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_3 = Main.dust[num4];
                    expr_92_cp_3.position.Y = expr_92_cp_3.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num4].position != projectile.Center)
                    {
                        Main.dust[num4].velocity = projectile.DirectionTo(Main.dust[num4].position) * 20f;
                    }

                    int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].scale = 4f;
                    Dust expr_62_cp_4 = Main.dust[num5];
                    expr_62_cp_4.position.X = expr_62_cp_4.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_4 = Main.dust[num5];
                    expr_92_cp_4.position.Y = expr_92_cp_4.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num5].position != projectile.Center)
                    {
                        Main.dust[num5].velocity = projectile.DirectionTo(Main.dust[num5].position) * 16f;
                    }

                    int num6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num6].noGravity = true;
                    Main.dust[num6].scale = 4f;
                    Dust expr_62_cp_5 = Main.dust[num6];
                    expr_62_cp_5.position.X = expr_62_cp_5.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_5 = Main.dust[num6];
                    expr_92_cp_5.position.Y = expr_92_cp_5.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num6].position != projectile.Center)
                    {
                        Main.dust[num6].velocity = projectile.DirectionTo(Main.dust[num6].position) * 12f;
                    }

                    int num7 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num7].noGravity = true;
                    Main.dust[num7].scale = 5f;
                    Dust expr_62_cp_6 = Main.dust[num7];
                    expr_62_cp_6.position.X = expr_62_cp_6.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_6 = Main.dust[num7];
                    expr_92_cp_6.position.Y = expr_92_cp_6.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num7].position != projectile.Center)
                    {
                        Main.dust[num7].velocity = projectile.DirectionTo(Main.dust[num7].position) * 8f;
                    }

                    int num8 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, 0f, -2f, 0, default(Color), 1.1f);
                    Main.dust[num8].noGravity = true;
                    Main.dust[num8].scale = 8f;
                    Dust expr_62_cp_7 = Main.dust[num8];
                    expr_62_cp_7.position.X = expr_62_cp_7.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5
                    Dust expr_92_cp_7 = Main.dust[num8];
                    expr_92_cp_7.position.Y = expr_92_cp_7.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f); //was 1.5

                    if (Main.dust[num8].position != projectile.Center)
                    {
                        Main.dust[num8].velocity = projectile.DirectionTo(Main.dust[num8].position) * 4f;
                    }
                }
            });
            projectile.active = false;
        }
    }
}