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
using System.Threading;
#endregion

namespace Libraries
{
    public class IA : Personnage
    {
        public Vector3 targetPosition = Vector3.Zero;
        public IA(PlayerIndex Player, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f, int life = 5)
        {
            base.Player = Player;
            base.Life = life;
            this.XRot = xRot;
            this.YRot = yRot;
            this.ZRot = zRot;
        }

        public override void Update(GameTime gameTime)
        {
            if (targetPosition.X > base.XPos)
                base.Right(gameTime);
            else if (targetPosition.X < base.XPos)
                base.Left(gameTime);
            else
                base.velocityX = 0;

            if (targetPosition.Y > base.YPos)
                base.Jump();

            base.Update(gameTime);
        }
    }
}
