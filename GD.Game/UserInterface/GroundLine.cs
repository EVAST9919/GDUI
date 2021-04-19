using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace GD.Game.UserInterface
{
    public class GroundLine : GridContainer
    {
        public GroundLine()
        {
            RowDimensions = new[]
            {
                new Dimension()
            };
            ColumnDimensions = new[]
            {
                new Dimension(GridSizeMode.Relative, size: 0.14f),
                new Dimension(),
                new Dimension(GridSizeMode.Relative, size: 0.14f)
            };
            Content = new[]
            {
                new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = ColourInfo.GradientHorizontal(Color4.White.Opacity(0), Color4.White)
                    },
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White
                    },
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = ColourInfo.GradientHorizontal(Color4.White, Color4.White.Opacity(0))
                    }
                }
            };
        }
    }
}
