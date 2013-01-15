#region Using
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace TurkeySmash
{
    class Accueil : Menu
    {
        #region Fields

        private float xPos = 300;
        private float yPos = 200;
        private BoutonMenu bouton1;
        private BoutonMenu bouton2;
        private BoutonMenu bouton3;
        private BoutonMenu bouton4;

        #endregion

        #region Construction and Initialization

        public Accueil()
        {
            xPos = TurkeySmashGame.manager.PreferredBackBufferWidth / 4;
            yPos = TurkeySmashGame.manager.PreferredBackBufferHeight / 4;
            bouton1 = new BoutonMenu(xPos, yPos + 100);
            bouton2 = new BoutonMenu(xPos, yPos + 200);
            bouton3 = new BoutonMenu(xPos, yPos + 300);
            bouton4 = new BoutonMenu(xPos, yPos + 450);
            bouton1.Texte = "Jouer";
            bouton2.Texte = "Multijoueur";
            bouton3.Texte = "Options";
            bouton4.Texte = "Quitter";
        }

        public override void Init()
        {
            backgroundMenu.Load(TurkeySmashGame.content, "Images\\MenuPrincipal");
            bouton1.Load(TurkeySmashGame.content, boutons);
            bouton2.Load(TurkeySmashGame.content, boutons);
            bouton3.Load(TurkeySmashGame.content, boutons);
            bouton4.Load(TurkeySmashGame.content, boutons);
        }

        #endregion

        public override void Bouton1()
        {
            Basic.SetScreen(new Jeu());
        }

        public override void Bouton2()
        {

        }

        public override void Bouton3()
        {
            Basic.SetScreen(new Options());
        }

        public override void Bouton4()
        {
            Basic.Quit();
        }
    }
}
