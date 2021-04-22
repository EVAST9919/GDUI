using osu.Framework.Graphics;
using GD.Game.Graphics;

namespace GD.Game.UserInterface
{
    public class GDTexturedButton : GDButton
    {
        public GDTexturedButton(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.84f, bool useLarge = false)
        {
            Content.RelativeSizeAxes = Axes.None;
            Content.AutoSizeAxes = Axes.Both;

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

            Child = s;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            Size = Content.Size;
        }
    }
}
