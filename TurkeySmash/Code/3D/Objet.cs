using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    class Objet : Element3D
    {
        private Vector2 modelSize;
        private Rectangle hitbox;

        #region Properties

        public Vector2 Size { get { return modelSize; } set { modelSize = value; } }
        public float XSize { get { return modelSize.X; } set { modelSize.X = value; } }
        public float YSize { get { return modelSize.Y; } set { modelSize.Y = value; } }

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
            
        }

        public Rectangle HitBox()
        {
            hitbox = new Rectangle((int)(XPos - (modelSize.X / 2)), (int)YPos, (int)modelSize.X, (int)modelSize.Y);
            return hitbox;
        }
    }
}
