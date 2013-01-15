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
    class IA : Personnage
    {
        public IA(PlayerIndex player, Vector3 position, float rotation = 0.0f, int life = 5)
        {
            Position = position;
            Rotation = rotation;
            base.Player = player;
            base.Life = life;
        }
    }
}
