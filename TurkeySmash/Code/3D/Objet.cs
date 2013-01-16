using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    class Objet : Element3D
    {
        private Vector2 modelSize;

        public Vector2 Size { get { return modelSize; } }

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
            if (YPos > 0 | XPos > 1800 | XPos < -1800)
                YPos -= 25;

            if (YPos > -30)
            {
                if (YPos < 0 & (XPos > -1800 & XPos < 1800))
                    YPos = 0;
            }
            else
                YPos -= 1;


        }

        public Rectangle HitBox(Vector2 modelSize) //Creer la hitbox du personnage
        {
            return new Rectangle(
                (int)Position.X, (int)Position.Y, (int)modelSize.X, (int)modelSize.Y);
        }

        public BoundingSphere HitSphere(float modelSize, Objet objet)  //Créer une hitbox spherique ?
        {
            return new BoundingSphere(objet.Position, modelSize);
        }
    }
}
