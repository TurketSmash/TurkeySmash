#region Using Statement
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Libraries;
#endregion

namespace TurkeySmash
{
    class Multi : Screen
    {
        #region Fields

        private Camera camera;
        private Joueur dude1;
        private Joueur dude2;
        private AnimatedModel walk;
        private Level level;
        private List<AnimatedModel> elements = new List<AnimatedModel>();
        private HUD hud = new HUD();
        public static SoundEffect sonEspace = TurkeySmashGame.content.Load<SoundEffect>("Sons\\sonEspace");
        public SoundEffectInstance sonInstance = sonEspace.CreateInstance();

        #endregion

        #region Construction and Initialization

        public Multi()
        {
            state = SceneState.Active;
        }

        public override void Init()
        {
            camera = new Libraries.Camera(TurkeySmashGame.manager);

            #region player1
            dude1 = new Joueur(PlayerIndex.Two, MathHelper.ToRadians(-90), MathHelper.ToRadians(180));
            dude1.Load("Models\\dude", TurkeySmashGame.content);
            walk = new AnimatedModel();
            walk.Load("Models\\dude-walk", TurkeySmashGame.content);
            AnimationClip clip1 = walk.Clips[0];
            AnimationPlayer player1 = dude1.PlayClip(clip1);
            player1.Looping = true;
            dude1.Size = new Vector2(50, 350);

            elements.Add(dude1);
            #endregion

            #region player2
            dude2 = new Joueur(PlayerIndex.Two, MathHelper.ToRadians(-90), MathHelper.ToRadians(180));
            dude2.Load("Models\\dude", TurkeySmashGame.content);
            walk = new AnimatedModel();
            walk.Load("Models\\dude-walk", TurkeySmashGame.content);
            AnimationClip clip2 = walk.Clips[0];
            AnimationPlayer player2 = dude2.PlayClip(clip2);
            player2.Looping = true;
            dude2.Size = new Vector2(50, 350);

            elements.Add(dude2);
            #endregion

            if (SelectionNiveau.niveauSelect == "spacefarm")
                level = new Level("Jeu\\space", "Models\\farm", elements, TurkeySmashGame.content);
            else
                level = new Level("Jeu\\citybackground", "Models\\MapCity2", elements, TurkeySmashGame.content);

            hud.Load(elements);
            camera.Initialize();

            sonInstance.Volume = 0.5f;
            sonInstance.IsLooped = true;
            sonInstance.Resume();
        }

        #endregion

        #region Update

        public override void Update(GameTime gameTime, Input input)
        {
            camera.Update(TurkeySmashGame.manager.GraphicsDevice, gameTime);

            level.Update(gameTime);
            hud.Update(elements);
            sonInstance.Resume();

            if (input.Escape())
            {
                sonInstance.Pause();
                Basic.SetScreen(new Pause());
            }
        }

        #endregion

        #region Drawing

        public override void Render()
        {
            if (state == SceneState.Active)
            {
                level.Draw(TurkeySmashGame.spriteBatch, TurkeySmashGame.manager.GraphicsDevice, camera);
                TurkeySmashGame.manager.GraphicsDevice.BlendState = BlendState.Opaque; 
                TurkeySmashGame.manager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                foreach (AnimatedModel element in elements)
                {
                    element.Draw(TurkeySmashGame.manager.GraphicsDevice, camera);
                }

                hud.Draw();
            }
        }

        #endregion
    }
}
