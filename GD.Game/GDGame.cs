using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using GD.Game.UserInterface;
using GD.Game.Screens.Menu;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;
using GD.Game.Screens;

namespace GD.Game
{
    public class GDGame : GDGameBase
    {
        private DependencyContainer dependencies;

        private ScreenStack screens;
        private Box blackBox;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new ScalingContainer
            {
                Children = new Drawable[]
                {
                    screens = new ScreenStack(new MainMenuScreen()),
                    blackBox = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black,
                        Alpha = 0
                    }
                }
            });

            screens.ScreenExited += (u, v) => onScreenChanged();
            screens.ScreenPushed += (u, v) => onScreenChanged();
        }

        private void onScreenChanged()
        {
            blackBox.ClearTransforms();
            blackBox.FadeIn(GDScreen.SCREEN_CHANGE_DURATION / 2f, Easing.Out).Then().FadeOut(GDScreen.SCREEN_CHANGE_DURATION / 2f, Easing.Out);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            Scheduler.AddDelayed(() =>
            {
                var track = Audio.Tracks.Get("menuLoop");
                track.Looping = true;
                track.Start();
            }, 300);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
    }
}
