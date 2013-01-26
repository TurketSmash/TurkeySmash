namespace TurkeySmash
{
    class Accueil : Menu
    {
        #region Fields

        private float xPos = 300;
        private float yPos = 200;
        private BoutonTexte bouton1;
        private BoutonTexte bouton2;
        private BoutonTexte bouton3;
        private BoutonTexte bouton4;

        #endregion

        #region Construction and Initialization

        public Accueil()
        {
            xPos = TurkeySmashGame.manager.PreferredBackBufferWidth / 4;
            yPos = TurkeySmashGame.manager.PreferredBackBufferHeight / 4;
            bouton1 = new BoutonTexte(xPos, yPos + 100);
            bouton2 = new BoutonTexte(xPos, yPos + 200);
            bouton3 = new BoutonTexte(xPos, yPos + 300);
            bouton4 = new BoutonTexte(xPos, yPos + 450);
            bouton1.Texte = "Jouer";
            bouton2.Texte = "Multijoueur";
            bouton3.Texte = "Options";
            bouton4.Texte = "Quitter";
        }

        public override void Init()
        {
            backgroundMenu.Load(TurkeySmashGame.content, "Menu\\MenuPrincipal");
            bouton1.Load(TurkeySmashGame.content, boutons);
            bouton2.Load(TurkeySmashGame.content, boutons);
            bouton3.Load(TurkeySmashGame.content, boutons);
            bouton4.Load(TurkeySmashGame.content, boutons);
        }

        #endregion

        public override void Bouton1()
        {
            Basic.SetScreen(new SelectionNiveau());
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
