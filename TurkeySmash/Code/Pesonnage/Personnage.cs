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
    abstract class Personnage : Objet
    {
        #region Fields

        private PlayerIndex player = PlayerIndex.One;
        private int percent = 0;
        private int life;
        private int modelVelocity = 5;
        private int hauteurSaut = 1;
        private bool jumpAllowed = false;
        private bool isJumping = false;
        private float jumpSpeed;

        #endregion

        #region Properties 

        public PlayerIndex Player { get { return player; } set { player = value; } }
        public int Life { get { return life; } set { life = value; } }
        public int Percent { get { return percent; } set { percent = value; } }
        public int Velocity { get { return 5 * modelVelocity; } set { modelVelocity = value; } }
        public int HauteurSaut { get { return hauteurSaut; } set { hauteurSaut = value; } }

        #endregion

        public void Init(Vector3 positionSpawn)
        {
            Position = positionSpawn;
        }

        #region gameplay
        // chaque feature du gameplay sont crées ici de la meme manière
        // l'utilisation de ces fonctions se fait ensuite dans les classes filles : Joueur et AI 

        protected void Jump()               
        {
            if (YPos == 0 & (XPos > -1800 & XPos < 1800))
            {
                jumpAllowed = true;
                jumpSpeed = 50;
                isJumping = false;
            }

            if (jumpAllowed)
            {
                isJumping = true;
                jumpAllowed = false;
            }

            if (jumpSpeed == 0)
                isJumping = true;

            if (isJumping & jumpSpeed > 0)
            {
                YPos += jumpSpeed;
                jumpSpeed -= 1;
            }
        }

        public bool Mort()
        {
            return life <= 0;
        }

        public void DelLife()
        {
            life--;
        }

        #endregion
    }
}
