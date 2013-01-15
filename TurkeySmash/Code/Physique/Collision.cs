#region Using Statement

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

#endregion

namespace TurkeySmash
{
    static class Collision
    {
        static public void CheckHitBoxe(List<Rectangle> GlobalHitBoxesList, Objet objet)
        {
            foreach (Rectangle rect in GlobalHitBoxesList)
            {
                if (rect.Intersects(objet.HitBox(objet.Size)))
                {
                    if (rect.Top > objet.HitBox(objet.Size).Top)
                        objet.YPos = rect.Top - (objet.HitBox(objet.Size).Top / 2);

                    if (rect.Bottom < objet.HitBox(objet.Size).Bottom)
                        objet.YPos = rect.Bottom + (objet.HitBox(objet.Size).Bottom / 2);

                    if (rect.Left > objet.HitBox(objet.Size).Left)
                        objet.XPos = rect.Left - (objet.HitBox(objet.Size).Left / 2);

                    if (rect.Right < objet.HitBox(objet.Size).Right)
                        objet.XPos = rect.Right + (objet.HitBox(objet.Size).Right / 2);
                }
            }
        }
    }
}
