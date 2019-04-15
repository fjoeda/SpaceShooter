using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter.Objects
{
    class Sprite
    {
        SpriteBatch sp;
        Texture2D texture;
        Vector2 position;

        float angle, width, height;

        public Sprite(Texture2D texture, Vector2 position, float width, float height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        [Obsolete]
        public void Draw()
        {
            sp.Begin();
            sp.Draw(texture, destinationRectangle: new Rectangle((int)position.X, (int)position.Y,(int)width,(int)height),
                origin:new Vector2(width/2,height/2),rotation:angle);
            sp.End();
        }
    }
}
