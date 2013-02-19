#region Using Statement
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
        private List<Personnage> players = new List<Personnage>();
        private List<Element3D> elements = new List<Element3D>();
        private GameTime gameTime;
        private HUD hud = new HUD();

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
            players.Add(new Joueur(PlayerIndex.One));
            background.Load(TurkeySmashGame.content, "Jeu\\space");
            players[0].Load(TurkeySmashGame.content, "Models\\dude", elements);
            players[0].Size = new Vector2(50, 375);
            level = new Decor(elements);
            level.Load(TurkeySmashGame.content, "Models\\farm");
            hud.Load(players);
            camera.Initialize();
        }

        #endregion

        #region Update

        public override void Update(Input input)
        {
            camera.Update(TurkeySmashGame.manager.GraphicsDevice, gameTime);
            level.Update();
            hud.Update(players);

            //
            // fin de partie
            // si les joueurs sont morts, alors le dernier est vainqueurs et la partie est terminée.
            // les joueurs sont stockés dans une liste : players de type Player 
            // la mort du personnage se vérifié grace à la Propriété "Mort" (bool).
            //
            
            if (input.Escape())
            {
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

                level.Draw(camera);
                foreach (Element3D element in elements)
                {
                    element.Draw(camera);
                }

                hud.Draw();
            }
        }

        #endregion
    }
}
