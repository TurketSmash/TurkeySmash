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

namespace TurkeySmash
{
    class Decor
    {
        #region Fields

        private Vector3[] spawnPoints = new Vector3[5];
        private Vector3 positionRespawn = new Vector3(0,1100 , 0);
        private Rectangle cadreDecor = new Rectangle(-3500, 2500, 7000, -5000);
        private List<Rectangle> GlobalHitBoxesList = new List<Rectangle>();
        private List<Element3D> elements;
        private Model model;
        private Vector3 modelPosition = new Vector3(0, 0, 0);
        protected Matrix[] transforms;

        #endregion

        #region Properties

        public Vector3 Position { get { return modelPosition; } set { modelPosition = value; } }

        #endregion

        #region Construction and Initialization



        public Decor(List<Element3D> elements)
        {
            this.elements = elements;
            Position = Vector3.Zero;
            spawnPoints[0] = new Vector3(-1450, 0, 0);
            Init();
            GlobalHitBoxesList.Add(new Rectangle(-1825, -150, 3650, 150));
            GlobalHitBoxesList.Add(new Rectangle(-750, 0, 850, 250));
            GlobalHitBoxesList.Add(new Rectangle(400, 450, 725, 50));
        }



        public void Init()
        {
            foreach(Personnage player in elements)
            {
                int i = 0;
                player.Position = spawnPoints[i];
                i++;
            }
        }



        public void Load(ContentManager content, string name)
        {
            model = content.Load<Model>(name);
            transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
        }

        #endregion



        public void Update()
        {
            foreach (Objet objet in elements)
            {
                objet.Update();
                Collision.CheckHitBoxe(GlobalHitBoxesList, objet);
            }

            foreach (Personnage personnage in elements)
            {
                if (IsOutScreen((Objet)personnage))
                {
                    Respawn(personnage);
                }
            }
        }



        public bool IsOutScreen(Objet objet)
        {
            return objet.XPos < cadreDecor.Left || objet.XPos > cadreDecor.Right || objet.YPos < cadreDecor.Bottom || objet.YPos > cadreDecor.Top;
        }



        public void Respawn(Personnage personnage)
        {
            if ((personnage.Mort() == false))
            {
                personnage.Position = positionRespawn;
                personnage.Life--;
            }
            personnage.velocityX = 0;
            personnage.velocityY = 0;
        }



        public void Update(Personnage personnage)
        {
            if (IsOutScreen(personnage))
                Respawn(personnage);
        }



        public void Draw(Camera camera) // Meme methode que Element3D sans rotation ni translation
        {
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

