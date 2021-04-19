using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace GD.Game.Graphics.Containers
{
    public class ReverseFillFlowContainer<T> : FillFlowContainer<T>
        where T : Drawable
    {
        protected override int Compare(Drawable x, Drawable y) => CompareReverseChildID(x, y);
    }
}
