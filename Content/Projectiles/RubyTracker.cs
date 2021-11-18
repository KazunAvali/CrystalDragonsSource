using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystalDragons.Content.Projectiles

{
    public class RubyTracker : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Tracker");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 16;

            projectile.ranged = true;
            projectile.friendly = true;
            projectile.timeLeft = 600;

            projectile.penetrate = -1;
            projectile.tileCollide = true;
        }

        bool strike = false;

        public override bool PreAI()
        {
            Lighting.AddLight(projectile.Center, 0.6f, 0f, .0f);
            strike = true;
            if (projectile.ai[0] == 0)
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            else
            {
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
                int lifetime = 10;
                bool flag52 = false;
                bool flag53 = false;
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] % 30f == 0f)
                    flag53 = true;

                int num997 = (int)projectile.ai[1];
                if (projectile.localAI[0] >= (float)(60 * lifetime))
                    flag52 = true;
                else if (num997 < 0 || num997 >= 200)
                    flag52 = true;
                else if (Main.npc[num997].active && !Main.npc[num997].dontTakeDamage)
                {
                    projectile.Center = Main.npc[num997].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[num997].gfxOffY;
                    if (flag53)
                    {
                        Main.npc[num997].HitEffect(0, 1.0);
                    }
                }
                else
                    flag52 = true;

                if (flag52)
                {
                    projectile.Kill();
                }
            }

            int num = 5;

            for (int k = 0; k < 3; k++)
            {
                int index2 = Dust.NewDust(projectile.position, 1, 1, DustID.RubyBolt, 0.0f, 0.0f, 0, new Color(), 1f);
                Main.dust[index2].position = projectile.Center - projectile.velocity / num * (float)k;
                Main.dust[index2].scale = .5f;
                Main.dust[index2].velocity *= 0f;
                Main.dust[index2].noGravity = true;
                Main.dust[index2].noLight = false;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] = 1f;
            projectile.ai[1] = (float)target.whoAmI;
            projectile.velocity = (target.Center - projectile.Center) * 0.75f;
            projectile.netUpdate = true;
            projectile.damage = 0;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
            }

            Player player = Main.player[projectile.owner];

            int rubyBombDamage = 400;

            //Eye of Cthulu
            if (NPC.downedBoss1)
            {
                rubyBombDamage = 560;
            }

            //SKELEMAN
            if (NPC.downedBoss3)
            {
                rubyBombDamage = 1000;
            }

            //Wall of Flesh
            if (Main.hardMode)
            {
                rubyBombDamage = 2000;
            }

            //Any Mecha
            if (NPC.downedMechBossAny)
            {
                rubyBombDamage = 3500;
            }

            //Plantera
            if (NPC.downedPlantBoss)
            {
                rubyBombDamage = 5000;
            }

            //Golem
            if (NPC.downedGolemBoss)
            {
                rubyBombDamage = 10000;

            }

            //Moon Lord
            if (NPC.downedMoonlord)
            {
                rubyBombDamage = 20000;
            }

            //explosion
            //Make sure the projectile only spawns once
            if (player == Main.LocalPlayer)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ModContent.ProjectileType<RubyBombardment>(), (int)(rubyBombDamage * (player.rangedDamage + player.allDamage - 1)), 2.5f, Main.myPlayer);
            }

            Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode, projectile.Center);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity = Vector2.Zero;
            return false;
        }
    }
}
