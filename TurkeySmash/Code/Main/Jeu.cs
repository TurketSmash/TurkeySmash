#region Using
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace TurkeySmash
{
    class Jeu : Screen
    {
        #region Fields

        private Sprite background;
        private Camera camera;
        private Decor level;
        private Joueur player;
        private List<Element3D> elements = new List<Element3D>();
        private GameTime gameTime;

        #endregion 

        #region Properties



        #endregion

        #region Construction and Initialization

        public Jeu()
        {
            gameTime = new GameTime();
            state = SceneState.Active;
        }

        public override void Init()
        {
            camera = new Camera(TurkeySmashGame.manager);
            background = new Sprite();
            player = new Joueur(PlayerIndex.One);
            background.Load(TurkeySmashGame.content, "Images\\space");
            player.Load(TurkeySmashGame.content, "Models\\dude", elements);
            level = new Decor(elements);
            level.Load(TurkeySmashGame.content, "Models\\farm");
            camera.Initialize();
        }

        #endregion

        #region Update

        public override void Update(Input input)
        {
            camera.Update(TurkeySmashGame.manager.GraphicsDevice, gameTime);
            level.Update();

            if (input.Escape())
            {
                Basic.SetScreen(new Pause());
            }

            if (input.Enter())
                camera.Target = player.Position;

            Console.Write(player.XPos + " ");
            Console.Write(player.YPos);
            Console.WriteLine();
        }

        #endregion

        #region Drawing

        public override void Render()
        {
            if (state == SceneState.Active)
            {
                TurkeySmashGame.spriteBatch.Begin();

                background.Draw(TurkeySmashGame.spriteBatch);

                TurkeySmashGame.spriteBatch.End();

                TurkeySmashGame.manager.GraphicsDevice.BlendState = BlendState.Opaque; //rendre les textures opaques
                TurkeySmashGame.manager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                level.Draw(camera);
                foreach (Element3D element in elements)
                {
                    element.Draw(camera);
                }
            }
        }

        #endregion
    }
}
