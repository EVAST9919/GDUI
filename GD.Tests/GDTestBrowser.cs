using GD.Game;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using osu.Framework.Testing;
using osuTK.Graphics;

namespace GD.Tests
{
    public class GDTestBrowser : GDGameBase
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Host.Window.CursorState = CursorState.Default;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            // Have to construct this here, rather than in the constructor, because
            // we depend on some dependencies to be loaded within OsuGameBase.load().
            AddRange(new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Gray
                },
                new TestBrowser("GD.Tests")
            });
        }
    }
}
