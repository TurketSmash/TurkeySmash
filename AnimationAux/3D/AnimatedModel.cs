using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Libraries;

namespace Libraries
{
    /// <summary>
    /// An encloser for an XNA model that we will use that includes support for
    /// bones, animation, and some manipulations.
    /// </summary>
    public class AnimatedModel
    {
        #region Fields

        private Model model = null;
        private ModelExtra modelExtra = null;
        private List<Bone> bones = new List<Bone>();
        private AnimationPlayer player = null;
        private float modelRotationX = 0.0f;
        private float modelRotationY = 0.0f;
        private float modelRotationZ = 0.0f;
        private Vector3 modelPosition = new Vector3(0, 0, 0);
        protected Matrix[] transforms;
        private float scale = 5.0f;
        private Matrix world;
        private Vector2 modelSize;
        private Rectangle hitbox;
        private Vector2 velocity = new Vector2(0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// The actual underlying XNA model
        /// </summary>
        public Model Model
        {
            get { return model; }
        }

        /// <summary>
        /// The underlying bones for the model
        /// </summary>
        public List<Bone> Bones { get { return bones; } }

        /// <summary>
        /// The model animation clips
        /// </summary>
        public List<AnimationClip> Clips { get { return modelExtra.Clips; } }
        public Vector3 Position { get { return modelPosition; } set { modelPosition = value; } }
        public float XPos { get { return modelPosition.X; } set { modelPosition.X = value; } }
        public float YPos { get { return modelPosition.Y; } set { modelPosition.Y = value; } }
        public float ZPos { get { return modelPosition.Z; } set { modelPosition.Z = value; } }
        public float XRot { get { return modelRotationX; } set { modelRotationX = value; } }
        public float YRot { get { return modelRotationY; } set { modelRotationY = value; } }
        public float ZRot { get { return modelRotationZ; } set { modelRotationZ = value; } }
        public float Scalecale { get { return scale; } set { scale = value; } }
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

        #region Construction and Loading

        /// <summary>
        /// Constructor. Creates the model from an XNA model
        /// </summary>
        /// <param name="assetName">The name of the asset for this model</param>
        public AnimatedModel() { }
        
        public AnimatedModel(Vector3 position, float xRot = 0.0f, float yRot = 0.0f, float zRot = 0.0f)
        {
            this.modelPosition = position;
            this.modelRotationX = xRot;
            this.modelRotationY = yRot;
            this.modelRotationZ = zRot;
        }

        /// <summary>
        /// Load the model asset from content
        /// </summary>
        /// <param name="content"></param>
        public void Load(string assetName, ContentManager content)
        {
            this.model = content.Load<Model>(assetName);
            modelExtra = model.Tag as ModelExtra;
            System.Diagnostics.Debug.Assert(modelExtra != null);

            ObtainBones();
        }


        #endregion

        #region Bones Management

        /// <summary>
        /// Get the bones from the model and create a bone class object for
        /// each bone. We use our bone class to do the real animated bone work.
        /// </summary>
        private void ObtainBones()
        {
            bones.Clear();
            foreach (ModelBone bone in model.Bones)
            {
                // Create the bone object and add to the heirarchy
                Bone newBone = new Bone(bone.Name, bone.Transform, bone.Parent != null ? bones[bone.Parent.Index] : null);

                // Add to the bones for this model
                bones.Add(newBone);
            }
        }

        /// <summary>
        /// Find a bone in this model by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Bone FindBone(string name)
        {
            foreach(Bone bone in Bones)
            {
                if (bone.Name == name)
                    return bone;
            }

            return null;
        }

        #endregion

        #region Animation Management

        /// <summary>
        /// Play an animation clip
        /// </summary>
        /// <param name="clip">The clip to play</param>
        /// <returns>The player that will play this clip</returns>
        public AnimationPlayer PlayClip(AnimationClip clip)
        {
            // Create a clip player and assign it to this model
            player = new AnimationPlayer(clip, this);
            return player;
        }

        #endregion

        #region Updating

        /// <summary>
        /// Update animation for the model.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            if (player != null)
            {
                player.Update(gameTime);
            }
        }

        public Rectangle HitBox()
        {
            hitbox = new Rectangle((int)(XPos - (modelSize.X / 2)), (int)YPos, (int)modelSize.X, (int)modelSize.Y);
            return hitbox;
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Draw the model
        /// </summary>
        /// <param name="graphics">The graphics device to draw on</param>
        /// <param name="camera">A camera to determine the view</param>
        public void Draw(GraphicsDevice graphics, Camera camera)
        {
            if (model == null)
                return;

            world = Matrix.CreateScale(scale) * Matrix.CreateRotationX(modelRotationX) *
                Matrix.CreateRotationY(modelRotationY) * Matrix.CreateRotationZ(modelRotationZ)
                        * Matrix.CreateTranslation(modelPosition);

            //
            // Compute all of the bone absolute transforms
            //

            Matrix[] boneTransforms = new Matrix[bones.Count];

            for (int i = 0; i < bones.Count; i++)
            {
                Bone bone = bones[i];
                bone.ComputeAbsoluteTransform();

                boneTransforms[i] = bone.AbsoluteTransform;
            }

            //
            // Determine the skin transforms from the skeleton
            //

            Matrix[] skeleton = new Matrix[modelExtra.Skeleton.Count];
            for (int s = 0; s < modelExtra.Skeleton.Count; s++)
            {
                Bone bone = bones[modelExtra.Skeleton[s]];
                skeleton[s] = bone.SkinTransform * bone.AbsoluteTransform;
            }

            // Draw the model.
            foreach (ModelMesh modelMesh in model.Meshes)
            {
                foreach (Effect effect in modelMesh.Effects)
                {
                    if (effect is BasicEffect)
                    {
                        BasicEffect beffect = effect as BasicEffect;
                        beffect.World = boneTransforms[modelMesh.ParentBone.Index] * world;
                        beffect.View = camera.View;
                        beffect.Projection = camera.Projection;
                        beffect.EnableDefaultLighting();
                        beffect.PreferPerPixelLighting = true;
                    }

                    if (effect is SkinnedEffect)
                    {
                        SkinnedEffect seffect = effect as SkinnedEffect;
                        seffect.World = boneTransforms[modelMesh.ParentBone.Index] * world;
                        seffect.View = camera.View;
                        seffect.Projection = camera.Projection;
                        seffect.EnableDefaultLighting();
                        seffect.PreferPerPixelLighting = true;
                        seffect.SetBoneTransforms(skeleton);
                    }
                }

                modelMesh.Draw();
            }
        }


        #endregion

    }
}
