#region Using
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Input;
#endregion


namespace TurkeySmash
{
    class Menu : Screen
    {
        #region Fields 

        protected List<BoutonMenu> boutons = new List<BoutonMenu>();
        protected Sprite backgroundMenu = new Sprite();
        private int select = 1;
        private KeyboardState oldStateK;
        private GamePadState oldStateG;

        #endregion

        public Menu() { }

        public override void Update(Input input)
        {
            KeyboardState newStateK = Keyboard.GetState();
            GamePadState newStateG = GamePad.GetState(PlayerIndex.One);

            if ((oldStateK.IsKeyUp(Keys.Down) && newStateK.IsKeyDown(Keys.Down))
                    || (oldStateG.DPad.Down == ButtonState.Released && newStateG.DPad.Down == ButtonState.Pressed))
                    select++;
            if (oldStateK.IsKeyUp(Keys.Up) && newStateK.IsKeyDown(Keys.Up)
                    || (oldStateG.DPad.Up == ButtonState.Released && newStateG.DPad.Up == ButtonState.Pressed))
                    select--;

            if (select > boutons.Count)
                    select = 1;

            if (select < 1)
                    select = boutons.Count;

            foreach (BoutonMenu bouton in boutons)
            {
                bouton.Etat = false;
            }
            boutons[select - 1].Etat = true;

            if (input.Enter() || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) 
            {
                Thread.Sleep(200);

                switch (select)
                {
                    case 1:
                        Bouton1();
                        break;
                    case 2:
                        Bouton2();
                        break;
                    case 3:
                        Bouton3();
                        break;
                    case 4:
                        Bouton4();
                        break;
                }
            }

            oldStateK = newStateK;
            oldStateG = newStateG;
        }

        public override void Render()
        {
            TurkeySmashGame.spriteBatch.Begin();

            backgroundMenu.Resize(TurkeySmashGame.manager.PreferredBackBufferWidth);
            backgroundMenu.Draw(TurkeySmashGame.spriteBatch);
            foreach (BoutonMenu bouton in boutons)
            {
                bouton.Draw(TurkeySmashGame.spriteBatch);
            }

            TurkeySmashGame.spriteBatch.End();
        }

        public virtual void Bouton1() { }
        public virtual void Bouton2() { }
        public virtual void Bouton3() { }
        public virtual void Bouton4() { }
    }
}
