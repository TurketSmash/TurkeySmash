namespace TurkeySmash
{
    class SelectionNiveau : Menu
    {
        #region Fields

        private BoutonImage bouton1;
        private BoutonTexte bouton2;

        #endregion

        #region Consctruction & initialization

        public SelectionNiveau()
        {
            bouton1 = new BoutonImage();
            bouton2 = new BoutonTexte(TurkeySmashGame.manager.PreferredBackBufferWidth / 2, 700);
            bouton2.Texte = "Retour";
        }

        public override void Init()
        {
            backgroundMenu.Load(TurkeySmashGame.content, "Menu\\MenuPrincipal");
            bouton1.Load(TurkeySmashGame.content, "Menu\\Farm Space", boutons);
            bouton1.Position = new Microsoft.Xna.Framework.Vector2(TurkeySmashGame.manager.PreferredBackBufferWidth / 3, TurkeySmashGame.manager.PreferredBackBufferHeight / 2);
            bouton2.Load(TurkeySmashGame.content, boutons);
        }

        public override void Bouton1()
        {
            Basic.SetScreen(new Jeu());
        }

        public override void Bouton2()
        {
            Basic.Quit();
        }

        #endregion
    }
}
