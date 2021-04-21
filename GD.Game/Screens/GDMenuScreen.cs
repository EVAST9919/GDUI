using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens
{
    public abstract class GDMenuScreen : GDScreen
    {
        protected abstract BackButtonColour BackButtonColour { get; }

        protected abstract Color4 BackgroundColour { get; }

        protected Box Background { get; private set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                Background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = BackgroundColour
                },
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = ColourInfo.GradientVertical(new Color4(0, 0, 0, 0), Color4.Black.Opacity(0.5f))
                },
                CreateContent(),
                new TexturedGDButton(BackButtonColour == BackButtonColour.Green ? "back-arrow" : "back-arrow-pink")
                {
                    Position = new Vector2(85, 80),
                    ClickAction = this.Exit
                }
            };
        }

        protected abstract Drawable CreateContent();
    }

    public enum BackButtonColour
    {
        Green,
        Pink
    }
}
