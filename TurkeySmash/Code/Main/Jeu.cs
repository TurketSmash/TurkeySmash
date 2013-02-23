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
    class Jeu : Screen
    {
        #region Fields

        private Sprite background;
        private Libraries.Camera camera;
        private AnimatedModel model;
        private AnimatedModel walk;
        //private Decor level;
        //private List<Personnage> players = new List<Personnage>();
        //private List<Element3D> elements = new List<Element3D>();
        private HUD hud = new HUD();
        public static SoundEffect sonEspace = TurkeySmashGame.content.Load<SoundEffect>("Sons\\sonEspace");
        public SoundEffectInstance sonInstance = sonEspace.CreateInstance();

        #endregion

        #region Construction and Initialization

        public Jeu()
        {
            state = SceneState.Active;
        }

        public override void Init()
        {
            camera = new Libraries.Camera(TurkeySmashGame.manager);
            background = new Sprite();
            model = new AnimatedModel(new Vector3(0, 0, 0), MathHelper.ToRadians(-90), MathHelper.ToRadians(180));
            model.Load("Models\\dude", TurkeySmashGame.content);
            walk = new AnimatedModel();
            walk.Load("Models\\dude-walk", TurkeySmashGame.content);
            AnimationClip clip = walk.Clips[0];
            AnimationPlayer player = model.PlayClip(clip);
            player.Looping = true;

            //players.Add(new Joueur(PlayerIndex.One));
            background.Load(TurkeySmashGame.content, "Jeu\\space");
            //if (SelectionPersonnage.persoSelect == "soldat")
            //    players[0].Load(TurkeySmashGame.content, "Models\\dude", elements);
            //else
            //    players[0].Load(TurkeySmashGame.content, "Models\\dude", elements);
            //players[0].Size = new Vector2(50, 375);
            //level = new Decor(elements);
            //if (SelectionNiveau.niveauSelect == "spacefarm")
            //    level.Load(TurkeySmashGame.content, "Models\\farm");
            //else
            //    level.Load(TurkeySmashGame.content, "Models\\building");
            //hud.Load(players);
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
            model.Update(gameTime);

            //level.Update();
            //hud.Update(players);
            sonInstance.Resume();

            //
            // fin de partie
            // si les joueurs sont morts, alors le dernier est vainqueurs et la partie est terminée.
            // les joueurs sont stockés dans une liste : players de type Player 
            // la mort du personnage se vérifié grace à la Propriété "Mort" (bool).
            //

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
                TurkeySmashGame.spriteBatch.Begin();

                background.Draw(TurkeySmashGame.spriteBatch);

                TurkeySmashGame.spriteBatch.End();

                TurkeySmashGame.manager.GraphicsDevice.BlendState = BlendState.Opaque; //rendre les textures opaques
                TurkeySmashGame.manager.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                model.Draw(TurkeySmashGame.manager.GraphicsDevice, camera);
                //level.Draw(camera);
                //foreach (Element3D element in elements)
                //{
                //    element.Draw(camera);
                //}

                //hud.Draw();
            }
        }

        #endregion
    }
}
