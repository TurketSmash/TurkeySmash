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
                Console.WriteLine(rect.Intersects(objet.HitBox()));
                if (rect.Intersects(objet.HitBox()))
                {
                    // Bottom et Top sont inversés : Top est l'arret inférieur,
                    // car la Hitbox est crée en fonction de la position du model qui est à la base du model
                    // et le dessin du rectangle pose de gros probleme avec l'utilisation de valeur négative
                    // Intersect c'est de la GROSSE MERDE

                    if (rect.Bottom > objet.HitBox().Top && rect.Bottom < objet.HitBox().Bottom)
                    {
                        objet.velocityY = 0;
                        objet.YPos = rect.Bottom;
                    }

                    if (rect.Top < objet.HitBox().Bottom && rect.Top > objet.HitBox().Top)
                    {
                        objet.velocityY = 0;
                        objet.YPos = rect.Top - objet.YSize;
                    }

                    if (rect.Left < objet.HitBox().Right && rect.Left > objet.HitBox().Left)
                    {
                        objet.velocityX = 0;
                        objet.XPos = rect.Left - (objet.XSize / 2);
                    }

                    if (rect.Right > objet.HitBox().Left && rect.Right < objet.HitBox().Right)
                    {
                        objet.velocityX = 0;
                        objet.XPos = rect.Right + (objet.XSize / 2);
                    }
                }
            }
        }
    }
}
