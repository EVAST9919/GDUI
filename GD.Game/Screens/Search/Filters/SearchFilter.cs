using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace GD.Game.Screens.Search.Filters
{
    public abstract class SearchFilter : Container
    {
        protected override Container<Drawable> Content => content;

        private readonly Container content;

        public SearchFilter()
        {
            Width = 1230;
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                    CornerRadius = 33,
                    Child = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black.Opacity(0.5f)
                    }
                },
                content = new Container
                {
                    RelativeSizeAxes = Axes.Both
                }
            };
        }
    }
}
