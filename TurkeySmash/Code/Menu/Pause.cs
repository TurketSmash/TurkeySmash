using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TurkeySmash
{
    class Pause : Menu
    {
            #region Fields

            private BoutonMenu bouton1;
            private BoutonMenu bouton2;
            private BoutonMenu bouton3;
            private float xPos = 500;
            private float yPos = 200;

            #endregion

            #region Construction and Initialization

            public Pause()
            {
                xPos = TurkeySmashGame.manager.PreferredBackBufferWidth / 4;
                yPos = TurkeySmashGame.manager.PreferredBackBufferHeight / 4;
                bouton1 = new BoutonMenu(xPos, yPos + 100);
                bouton2 = new BoutonMenu(xPos, yPos + 200);
                bouton1.Texte = "Retour";
                bouton2.Texte = "Menu Principal";
            }

            public override void Init()
            {
                backgroundMenu.Load(TurkeySmashGame.content, "Images\\MenuPause");
                bouton1.Load(TurkeySmashGame.content, boutons);
                bouton2.Load(TurkeySmashGame.content, boutons);
            }

            #endregion
            
            public override void Bouton1()
            {
                Basic.Quit();
            }
            
            public override void Bouton2()
            {
                Basic.Quit();
                Basic.Quit();
            }
    }
}
