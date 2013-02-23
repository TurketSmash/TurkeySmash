﻿using Microsoft.Xna.Framework.Media;
namespace TurkeySmash
{
    class SelectionNiveau : Menu
    {
        #region Fields

        private BoutonImage bouton1;
        private BoutonImage bouton2;
        private BoutonTexte bouton3;
        public static string niveauSelect;

        #endregion

        #region Consctruction & initialization

        public SelectionNiveau()
        {
            bouton1 = new BoutonImage();
            bouton2 = new BoutonImage();
            bouton3 = new BoutonTexte(TurkeySmashGame.manager.PreferredBackBufferWidth / 2, 700);
            bouton3.Texte = "Retour";
        }

        public override void Init()
        {
            backgroundMenu.Load(TurkeySmashGame.content, "Menu\\MenuPrincipal");
            bouton1.Load(TurkeySmashGame.content, "Menu\\Farm Space", boutons);
            bouton1.Position = new Microsoft.Xna.Framework.Vector2(TurkeySmashGame.manager.PreferredBackBufferWidth / 3, TurkeySmashGame.manager.PreferredBackBufferHeight / 2);
            bouton2.Load(TurkeySmashGame.content, "Menu\\Farm Space", boutons);
            bouton2.Position = new Microsoft.Xna.Framework.Vector2(2 * TurkeySmashGame.manager.PreferredBackBufferWidth / 3, TurkeySmashGame.manager.PreferredBackBufferHeight / 2);
            bouton3.Load(TurkeySmashGame.content, boutons);
        }

        public override void Bouton1()
        {
            niveauSelect = "spacefarm";
            MediaPlayer.Pause();
            Basic.SetScreen(new Jeu());
        }

        public override void Bouton2()
        {
            niveauSelect = "building";
            MediaPlayer.Pause();
            Basic.SetScreen(new Jeu());
        }

        public override void Bouton3()
        {
            Basic.Quit();
        }

        #endregion
    }
}
