using Microsoft.Xna.Framework;

namespace Libraries
{
    /// <summary>
    /// Personnage implemente toutes les features réalisablent par les joueurs et l'IA.
    /// Classe abstraite, ne peut être utilisé directement.
    /// </summary>
    public class Personnage : AnimatedModel
    {
        #region Fields

        private PlayerIndex playerNum = PlayerIndex.One;
        private int percent = 0;
        private int life;
        protected bool isJumping = false;
        private float jumpSpeed = 0;
        private bool jumpAllowed = true;

        #endregion

        #region Properties 

        /// <summary>
        /// PlayerIndex représente le numéro du joueur et le controle de la manette.
        /// </summary>
        public PlayerIndex Player { get { return playerNum; } set { playerNum = value; } }
        public int Life { get { return life; } set { life = value; } }
        public int Percent { get { return percent; } set { percent = value; } }
        /// <summary>
        /// Boolean indiquant vrai si le personnage n'a plus de vie.
        /// </summary>
        public bool Mort { get { return life < 1; } }

        #endregion

        public void Init(Vector3 positionSpawn)
        {
            Position = positionSpawn;
            if (XPos > 0)
                YRot = 0.0f;
            else
                YRot = 3.14f;
        }

        #region deplacement

        protected void Right()
        {
            if (velocityY == 0)
            {
                velocityX += 2.0f;
                player.Position = velocityX;
                YRot = 3.14f;  // rotation 180
            }
            else
                XPos += 6.0f;
        }

        protected void Left()
        {
            if (velocityY == 0)
            {
                velocityX += -2.0f;
                player.Position = velocityX;
                YRot = 0.0f;
            }
            else
                XPos -= 6.0f;
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

        #endregion
    }
}
