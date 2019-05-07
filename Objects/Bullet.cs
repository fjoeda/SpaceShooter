using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter.Objects
{
    class Bullet : Sprite
    {
        public Bullet(SpriteBatch sp,Texture2D texture, Vector2 position, float width, float height)
            : base(sp, texture, position, width, height)
        {
            this.sp = sp;
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public void Launch(double speed, double angle)
        {
            double speedX = speed * Math.Sin(angle * Math.PI / 180);
            double speedY = -speed * Math.Cos(angle * Math.PI / 180);
            this.position += new Vector2((float)speedX, (float)speedY);
        }
    }
}
