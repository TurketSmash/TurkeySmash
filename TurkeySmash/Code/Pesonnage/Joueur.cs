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
            if (input.Right())
                base.Right();
            else if (input.Left())
                base.Left();
            else
                velocityX = 0;

            if (input.Jump())
                base.Jump();

            base.Update();
        }
    }
}
