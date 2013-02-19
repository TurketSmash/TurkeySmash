using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TurkeySmash
{
    abstract class Element3D
    {

        #region Fields

        private Model model = null;
        private float modelRotation = 0.0f;
        private Vector3 modelPosition = new Vector3(0, 0, 0);
        protected Matrix[] transforms;
        private float scale = 5.0f;
        private Matrix baseWorld;
        private Matrix localWorld;

        #endregion

        #region Properties

        public Vector3 Position { get { return modelPosition; } set { modelPosition = value; } }
        public float XPos { get { return modelPosition.X; } set { modelPosition.X = value; } }
        public float YPos { get { return modelPosition.Y; } set { modelPosition.Y = value; } }
        public float ZPos { get { return modelPosition.Z; } set { modelPosition.Z = value; } }
        public float Rotation { get { return modelRotation; } set { modelRotation = value; } }
        public float Scalecale { get { return scale; } set { scale = value; } }

        #endregion

        public Element3D(float rotation = 5.0f)
        {
            modelPosition = Vector3.Zero;
            modelRotation = rotation;
        }

        public Element3D(Vector3 position, float rotation = 5.0f)
        {
            Position = position;
            Rotation = rotation;
        }

        public virtual void Load(ContentManager content, string name, List<Element3D> elements)
        {
            model = content.Load<Model>(name);
            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            elements.Add(this);                              // Rentre l'elment dans la liste
        }

        public virtual void Update() { }

        public virtual void Draw(Camera camera)
        {
            baseWorld = Matrix.CreateScale(scale) * Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(modelPosition); // Etablit les rotations et translations

            // Dessine le model mesh par mesh
            foreach (ModelMesh mesh in model.Meshes)
            {
                localWorld = baseWorld * transforms[mesh.ParentBone.Index]; // 
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.View = camera.View;                  // erasement de l'image de la 3D vers la 2D
                    effect.Projection = camera.Projection;      // angle de vu, ratio de l'image
                    effect.World = localWorld;
                }
                // Dessine le model avec les effects définis ci-dessus
                mesh.Draw();
            }
        }
    }
}
