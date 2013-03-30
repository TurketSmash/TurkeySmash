#region Using Statement

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

namespace Libraries
{
    public class Level
    {
        private Vector3[] spawnPoints = new Vector3[5];
        private Vector3 positionRespawn = new Vector3(0, 1100, 0);
        private Rectangle cadreDecor = new Rectangle(-3500, 2500, 7000, -5000);
        private Rectangle[] GlobalHitBoxesList = new Rectangle[3];
        private AnimatedModel[] elements;
        private Model model;
        private Vector3 modelPosition = new Vector3(0, 0, 0);
        private Matrix[] transforms;
        public Sprite background;

        public Vector3 Position { get { return modelPosition; } set { modelPosition = value; } }

        public Level(string backgroundName, string levelName, AnimatedModel[] elements, ContentManager content)
        {
            this.elements = elements;
            Position = Vector3.Zero;
            spawnPoints[0] = new Vector3(1200, 0, 0);
            spawnPoints[1] = new Vector3(-1300, 0, 0);
            spawnPoints[2] = new Vector3(700, 0, 0);
            spawnPoints[3] = new Vector3(700, 0, 0);

            Init();
            if (backgroundName == "Jeu\\space")
            {
                GlobalHitBoxesList[0] = new Rectangle(-1825, -150, 3650, 150);
                GlobalHitBoxesList[1] =new Rectangle(-750, 0, 850, 250);
                GlobalHitBoxesList[2] = new Rectangle(400, 450, 725, 50);
            }
            else
            {
                GlobalHitBoxesList[0] = new Rectangle(-1500, -50, 2800, 50);
                GlobalHitBoxesList[1] = new Rectangle(1530, 75, 780, 15);
                GlobalHitBoxesList[2] = new Rectangle(-550, 570, 1000, 30);
            }
            background = new Sprite();
            background.Load(content, backgroundName);
            Load(content, levelName);
        }

        public void Init()
        {
            int i = 0;
            foreach(Personnage player in elements)
            {
                if (player != null)
                    player.Init(spawnPoints[i]);
                i++;
            }
        }



        public void Load(ContentManager content, string assetName)
        {
            model = content.Load<Model>(assetName);
            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
        }



        public void Update(GameTime gameTime)
        {

            foreach (AnimatedModel objet in elements)
            {
                if (objet != null)
                {
                    if (objet is IA)
                    {
                        IA buffer = (IA)objet;
                        buffer.targetPosition = elements[0].Position;     // CODE GROS PORC SPECIAL SOUTENANCE 
                    }                                                                       // CHRIS BOULE
                    objet.Update(gameTime);
                    Collision.CheckHitBoxe(GlobalHitBoxesList, objet);
                }
            }

            foreach (Personnage personnage in elements)
            {
                if (personnage != null)
                {
                    if (IsOutScreen((AnimatedModel)personnage))
                    {
                        Respawn(personnage);
                    } 
                }
            }

            if (Partieterminee(elements))
            {
                // TODO
            }

        }



        public bool IsOutScreen(AnimatedModel objet)
        {
            return objet.XPos < cadreDecor.Left || objet.XPos > cadreDecor.Right || objet.YPos < cadreDecor.Bottom || objet.YPos > cadreDecor.Top;
        }



        public void Respawn(Personnage personnage)
        {
            if ((!personnage.Mort))
            {
                personnage.Position = positionRespawn;
                personnage.Life--;
            }
            personnage.velocityX = 0;
            personnage.velocityY = 0;
        }



        /// <summary>
        /// Retourne vrai si la partie est terminée 
        /// </summary>
        public bool Partieterminee(AnimatedModel[] models)
        {
            int i = 0; // compte de nombre de mort
            int j = 0; // compte de nombre de personnage 
            foreach (Personnage player in models)
            {
                if (player != null)
                {
                    j++;
                    if (player.Mort)
                        i++; 
                }
            }

            return i > j - 2; // si le nombre de mort est supérieur ou egal a 1 vivant 
        }




        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device, Camera camera) // Meme methode que Element3D sans rotation ni translation
        {
            spriteBatch.Begin();

            background.Draw(spriteBatch);

            spriteBatch.End();

            device.BlendState = BlendState.Opaque; //rendre les textures opaques
            device.DepthStencilState = DepthStencilState.Default;

            foreach (ModelMesh mesh in model.Meshes)
            {
                Matrix localWorld = transforms[mesh.ParentBone.Index];
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;
                    effect.World = localWorld;
                }
                mesh.Draw();
            }
        }
    }
}
