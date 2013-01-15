#region Using
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace TurkeySmash
{
    static class Basic
    {
        public static List<Screen> screens = new List<Screen>();

        public static void SetUp()
        {
            screens.Add(new Accueil()); // première image lors de l'ouverture du programme
            screens[0].Init();
        }

        public static void Update(Input input)
        {
            screens[screens.Count - 1].Update(input);
        }

        public static void Render()
        {
            if (screens.Count > 1)
                screens[screens.Count - 2].Render();
            screens[screens.Count - 1].Render();
        }

        public static void SetScreen(Screen newScreen)
        {
            screens.Add(newScreen);
            screens[screens.Count - 1].Init();
        }

        public static void Quit()
        {
            screens.Remove(screens[screens.Count - 1]);
        }

        public static void Exit()
        {
            screens.Clear();
            Basic.SetScreen(new Accueil());
        }
    }
}
