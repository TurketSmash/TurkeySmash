using Microsoft.Xna.Framework;

namespace TurkeySmash
{
    static class Gravity
    {
        static public void Pesenteur(ref float velocity)
        {
            velocity -= 0.5f;
        }
    }
}
