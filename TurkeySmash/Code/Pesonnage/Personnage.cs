using Microsoft.Xna.Framework;

namespace TurkeySmash
{
    abstract class Personnage : Objet
    {
        #region Fields

        private PlayerIndex player = PlayerIndex.One;
        private int percent = 0;
        private int life;
        protected bool isJumping = false;
        private float jumpSpeed = 0;
        private bool jumpAllowed = true;

        #endregion

        #region Properties 

        public PlayerIndex Player { get { return player; } set { player = value; } }
        public int Life { get { return life; } set { life = value; } }
        public int Percent { get { return percent; } set { percent = value; } }

        #endregion

        public void Init(Vector3 positionSpawn)
        {
            Position = positionSpawn;
        }

        #region deplacement

        protected void Right()
        {
            if (velocityY == 0)
                velocityX += 2.0f;
            else
                XPos += 6.0f;
            Rotation = MathHelper.ToRadians(90);
        }

        protected void Left()
        {
            if (velocityY == 0)
                velocityX += -2.0f;
            else
                XPos -= 6.0f;
            Rotation = MathHelper.ToRadians(270);
        }

        #endregion


        #region gameplay
        // chaque feature du gameplay sont crées ici de la meme manière
        // l'utilisation de ces fonctions se fait ensuite dans les classes filles : Joueur et AI 

        protected void Jump()               
        {
            if (velocityY == 0)
            {
                jumpAllowed = true;
                jumpSpeed = 30;
                isJumping = false;
            }

            if (jumpAllowed)
            {
                isJumping = true;
                jumpAllowed = false;
            }

            if (isJumping & jumpSpeed > 0)
            {
                YPos += jumpSpeed;
                jumpSpeed -= 1;
            }

        }

        public bool Mort()
        {
            return life < 1;
        }

        #endregion
    }
}
