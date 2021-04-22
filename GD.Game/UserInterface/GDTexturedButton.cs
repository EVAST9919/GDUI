using osu.Framework.Graphics;
using GD.Game.Graphics;

namespace GD.Game.UserInterface
{
    public class GDTexturedButton : GDButton
    {
        private readonly bool useTextureAspectRatio;

        public GDTexturedButton(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.84f, bool useLarge = false, bool useTextureAspectRatio = true)
        {
            this.useTextureAspectRatio = useTextureAspectRatio;

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

            if (useTextureAspectRatio)
                Size = Content.Size;
        }
    }
}
