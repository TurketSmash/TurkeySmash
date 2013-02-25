#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Libraries
{
    public class Joueur : Personnage
    {
        private Input input;

        #region Construction

        public Joueur(PlayerIndex Player, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f, int life = 5)
        {
            base.Player = Player;
            this.input = new Input(Player);
            base.Life = life;
            this.XRot = xRot;
            this.YRot = yRot;
            this.ZRot = zRot;
        }

        #endregion

        public override void Update(GameTime gameTime)
        {
            input.Update();
            if (input.Right())
                base.Right();
            else 
                if (input.Left())
                    base.Left();
                else
                    velocityX = 0;

            if (input.Jump())
                base.Jump();

            base.Update(gameTime);
        }
    }
}
