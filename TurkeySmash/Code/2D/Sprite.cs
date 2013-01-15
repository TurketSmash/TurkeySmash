using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    class Sprite
    {
        #region Fields 

        private Vector2 position = new Vector2(0, 0);
        private Texture2D texture;
        private Rectangle size;
        private float scale = 1.0f;

        #endregion

        #region Properties

        public float Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
                size = new Rectangle(0, 0, (int)(texture.Width * Scale), (int)(texture.Height * Scale));
            }
        }

        #endregion

        #region Construction

        public Sprite(float x = 0, float y = 0)
        {
            x = position.X;
            y = position.Y;
        }

        #endregion

        public void Load(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void Resize(float largeur)
        {
            Scale = largeur / texture.Width;
        }
    }
}
