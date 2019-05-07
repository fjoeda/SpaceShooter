using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.Objects
{
    class Pesawat : Sprite
    {
        Texture2D bulletTexture;
        List<Bullet> bullets;
        public Pesawat(SpriteBatch sp, Texture2D texture, Vector2 position, float width, float height, Texture2D bulletTexture)
            : base(sp, texture, position, width, height)
        {
            this.sp = sp;
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
            this.bulletTexture = bulletTexture;
            bullets = new List<Bullet>();
        }

        public void MoveRight(double value) { this.position.X += (float)value; }
        public void MoveLeft(double value) { this.position.X -= (float)value; }
        public void MoveUp(double value) { this.position.Y -= (float)value; }
        public void MoveDown(double value) { this.position.Y += (float)value; }

        public void Fire()
        {
            Bullet bullet = new Bullet(sp, bulletTexture, new Vector2(position.X, position.Y - 0.5f * height), 32, 48);
            bullet.SetAngle((new Random()).Next(-10, 10));
            bullets.Add(bullet);
            
        }

        public void LaunchBullet()
        {
            if (bullets.Count != 0)
            {
                foreach(Bullet bullet in bullets)
                {
                    
                    bullet.Launch(10, bullet.angle);
                }
                try
                {
                    foreach (Bullet bullet in bullets)
                    {
                        if (bullet.position.Y < 0)
                        {
                            bullets.Remove(bullet);
                        }
                    }
                }
                catch (Exception)
                {
                }
                
                
            }
        }
        
        public List<Bullet> GetBullets()
        {
            return bullets;
        }
    }
}
