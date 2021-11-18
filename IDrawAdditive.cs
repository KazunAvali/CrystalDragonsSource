using Terraria;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrystalDragons
{
    public interface IDrawAdditive
    {
        void AdditiveCall(SpriteBatch sb);
    }
}
