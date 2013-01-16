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

namespace TurkeySmash
{
    class Joueur : Personnage
    {
        private Input input;

        #region Construction

        public Joueur(PlayerIndex Player, float rotation = 0, int life = 5)
        {
            if (rotation == 0)
                Rotation = MathHelper.ToRadians(90);
            else
                Rotation = rotation;
            base.Player = Player;
            this.input = new Input(Player);
            base.Life = life;
        }

        #endregion

        public override void Update()
        {
            input.Update();
            if (velocityY == 0)
            {
                if (input.Right())
                    velocityX += 2.0f;
                else if (input.Left())
                    velocityX += -2.0f;
                else
                    velocityX = 0;
            }
            else
            {
                if (input.Right())
                    XPos += 6.0f;
                else if (input.Left())
                    XPos -= 6.0f;
            }

            if (input.Jump())
                base.Jump();

            base.Update();
        }
    }
}
