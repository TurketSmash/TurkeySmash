using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Libraries;

namespace TurkeySmash
{
    class HUD
    {
        private Font[] pourcentages = new Font[4];
        private int playersCount = 0;

        public HUD() { }

        public void Load(List<AnimatedModel> players)
        {
            int i = 0;
            playersCount = players.Count;
            foreach (Personnage player in players)
            {
                pourcentages[i] = new Font((i + 1) * (TurkeySmashGame.manager.PreferredBackBufferWidth / 4), 
                                        (3.5f * TurkeySmashGame.manager.PreferredBackBufferHeight / 4));
                pourcentages[i].NameFont = "Pourcent";
                pourcentages[i].Load(TurkeySmashGame.content);
                pourcentages[i].SizeText = 1.0f;
                i++;
            }

            pourcentages[0].Color = Color.Red;
        }

        public void Update(List<AnimatedModel> players)
        {
            int i = 0;
            foreach (Personnage player in players)
            {
                pourcentages[i].Texte = Convert.ToString(player.Percent) + " %";
                i++;
            }
        }

        public void Draw()
        {
            TurkeySmashGame.spriteBatch.Begin();

            for (int i = 0; i <= playersCount - 1; i++)
            {
                pourcentages[i].Draw(TurkeySmashGame.spriteBatch);
            }

            TurkeySmashGame.spriteBatch.End(); 
        }
    }
}