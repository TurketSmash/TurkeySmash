namespace TurkeySmash
{
    class Pause : Menu
    {
            #region Fields

            private BoutonTexte bouton1;
            private BoutonTexte bouton2;
            private BoutonTexte bouton3;
            private float xPos = 500;
            private float yPos = 200;

            #endregion

            #region Construction and Initialization

            public Pause()
            {
                xPos = TurkeySmashGame.manager.PreferredBackBufferWidth / 4;
                yPos = TurkeySmashGame.manager.PreferredBackBufferHeight / 4;
                bouton1 = new BoutonTexte(xPos, yPos + 100);
                bouton2 = new BoutonTexte(xPos, yPos + 200);
                bouton1.Texte = "Retour";
                bouton2.Texte = "Menu Principal";
            }

            public override void Init()
            {
                backgroundMenu.Load(TurkeySmashGame.content, "Menu\\MenuPause");
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
