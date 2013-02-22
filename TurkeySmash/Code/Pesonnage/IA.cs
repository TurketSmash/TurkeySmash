﻿#region Using
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

namespace TurkeySmash
{
    class IA : Personnage
    {
        public IA(PlayerIndex Player, float rotation = 0.0f, int life = 5)
        {
            if (rotation == 0)
                Rotation = MathHelper.ToRadians(90);
            else
                Rotation = rotation;
            base.Player = Player;
            base.Life = life;
        }

        public override void Update()
        {
            if (Multi.players[0].XPos > base.XPos)
                base.Right();
            else if (Multi.players[0].XPos < base.XPos)
                base.Left();
            else
                base.velocityX = 0;

            if (Multi.players[0].velocityY ==0)
            base.Jump();

            base.Update();
        }

    }
}
