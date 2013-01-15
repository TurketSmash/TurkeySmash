#region Using
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace TurkeySmash
{
    class Options : Menu
    {
        #region Fields 

        private BoutonMenu bouton1;
        private BoutonMenu bouton2;
        private BoutonMenu bouton3;
        private BoutonMenu bouton4;
        private float xPos = 350;
        private float yPos = 300;

        #endregion

        #region Construction and Initialization

        public Options()
        {
            xPos = 3 * TurkeySmashGame.manager.PreferredBackBufferWidth / 4;
            yPos = TurkeySmashGame.manager.PreferredBackBufferHeight / 4;
            bouton1 = new BoutonMenu(xPos, yPos + 100);
            bouton2 = new BoutonMenu(xPos, yPos + 200);
            bouton3 = new BoutonMenu(xPos, yPos + 300);
            bouton4 = new BoutonMenu(xPos, yPos + 450);
            bouton1.Texte = "Son";
            bouton2.Texte = "Resolution";
            bouton3.Texte = "Plein Ecran";
            bouton4.Texte = "Retour";
        }

        public override void Init()
        {
            backgroundMenu.Load(TurkeySmashGame.content, "Images\\MenuOption");
            bouton1.Load(TurkeySmashGame.content, boutons);
            bouton2.Load(TurkeySmashGame.content, boutons);
            bouton3.Load(TurkeySmashGame.content, boutons);
            bouton4.Load(TurkeySmashGame.content, boutons);
        }

        #endregion


        public override void Bouton1()
        {

        }

        public override void Bouton2()
        {
            Basic.SetScreen(new Resolution());
        }
        
        public override void Bouton3()
        {
            TurkeySmashGame.manager.ToggleFullScreen();
        }

        public override void Bouton4()
        {
            Basic.Quit();
        }
    }
}