using osu.Framework.Graphics;
using GD.Game.Graphics;

namespace GD.Game.UserInterface
{
    public class GDTexturedButton : GDAutosizedButton
    {
        public GDTexturedButton(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.84f, bool useLarge = false, bool autosized = true)
            : base(autosized)
        {
            var s = new GDSprite(textureName, flipOrientation, baseScale, useLarge);

            switch (flipOrientation)
            {
                case FlipOrientation.Horizontal:
                    s.Origin = Anchor.TopRight;
                    break;

                case FlipOrientation.Vertical:
                    s.Origin = Anchor.BottomLeft;
                    break;
            }

            Add(s);
        }
    }
}
