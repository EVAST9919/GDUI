using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using GD.Game.UserInterface;
using GD.Game.Graphics;

namespace GD.Game.Screens.Search.Filters
{
    public class LengthFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 120;
            Add(new FillFlowContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(48, 0),
                Children = new Drawable[]
                {
                    new LocalTextButton("Tiny"),
                    new LocalTextButton("Short"),
                    new LocalTextButton("Medium"),
                    new LocalTextButton("Long"),
                    new LocalTextButton("XL")
                }
            });
        }

        private class LocalTextButton : GDActivatedTextButton
        {
            public LocalTextButton(string text)
                : base(text, 42, Typeface.GDFont)
            {
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
            }
        }
    }
}
