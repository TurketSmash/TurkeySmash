using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    class BoutonMenu : Font
    {
        #region Fields 

        private bool etat = false;

        #endregion

        #region Properties

        public bool Etat { get { return etat; } set { etat = value; } }

        #endregion

        #region Construction 

        public BoutonMenu(float x = 0, float y = 0)
        {
            if (x != 0)
                Position = new Vector2(x, y);
            else
                Centrage(TurkeySmashGame.manager.GraphicsDevice);
        }

        public BoutonMenu(Vector2 position)
        {
            Position = position;
        }

        #endregion

        #region Load and Draw 

        public void Load(ContentManager Content, List<BoutonMenu> Boutons)
        {
            base.Load(Content);
            Boutons.Add(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (etat)
            {
                Color = Color.Red;
                SizeText = 1.5f;
            }
            else
            {
                Color = Color.Black;
                SizeText = 1.0f;
            }

            base.Draw(spriteBatch);
        }

        #endregion

        public void Centrage(GraphicsDevice device)
        { 
            Position = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
        }
    }
}
