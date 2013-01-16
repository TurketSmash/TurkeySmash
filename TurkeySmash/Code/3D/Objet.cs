using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    class Objet : Element3D
    {
        private Vector2 modelSize;
        private Rectangle hitbox;
        private Vector2 velocity = new Vector2(0, 0);

        #region Properties

        public Vector2 Size { get { return modelSize; } set { modelSize = value; } }
        public float XSize { get { return modelSize.X; } set { modelSize.X = value; } }
        public float YSize { get { return modelSize.Y; } set { modelSize.Y = value; } }
        
        public float velocityX
        {
            get
            {
                return velocity.X;
            }
            set
            {
                velocity.X = value;
                if (velocity.X > 30.0f)
                    velocity.X = 30.0f;
                else if (velocity.X < -30.0f)
                    velocity.X = -30.0f;
            }
        }
        
        public float velocityY 
        { 
            get 
            { 
                return velocity.Y; 
            } 
            set 
            { 
                velocity.Y = value;
                if (velocity.Y > 30.0f)
                    velocity.Y = 30.0f;
                else if (velocity.Y < -30.0f)
                    velocity.Y = -30.0f;
            } 
        }

        #endregion

        public Objet(float rotation = 0.0f)
        {
            Position = Vector3.Zero;
            Rotation = rotation;
        }

        public Objet(Vector3 position, float rotation = 0.0f)
        {
            Position = position;
            Rotation = rotation;
        }

        public override void Update()
        {
            XPos += velocity.X;
            YPos += velocity.Y;
            Gravity.Pesenteur(ref velocity.Y);
        }

        public Rectangle HitBox()
        {
            hitbox = new Rectangle((int)(XPos - (modelSize.X / 2)), (int)YPos, (int)modelSize.X, (int)modelSize.Y);
            return hitbox;
        }
    }
}
