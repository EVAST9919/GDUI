using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Overlays.Settings
{
    public class SettingsOverlay : FullScreenOverlay
    {
        private Sprite windowBg;

        protected override Drawable CreateWindow() => new Container
        {
            Anchor = Anchor.TopCentre,
            Origin = Anchor.TopCentre,
            RelativePositionAxes = Axes.Y,
            RelativeSizeAxes = Axes.Both,
            Y = -1,
            Children = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Size = new Vector2(1920, 1080),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Size = new Vector2(1250, 800),
                            Colour = Color4.Black.Opacity(0.7f)
                        },
                        windowBg = new Sprite
                        {
                            RelativeSizeAxes = Axes.Both
                        },
                        new GDSpriteText(70)
                        {
                            Text = "Settings",
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            Y = 90
                        },
                        new SettingsContent
                        {
                            GraphicsClicked = () => videoSettingsOverlay?.Show()
                        }
                    }
                },
                new GDTexturedButton("back-arrow-pink")
                {
                    ClickAction = () => IsVisible.Value = false,
                    Position = new Vector2(85),
                }
            }
        };

        private VideoSettingsOverlay videoSettingsOverlay;

        [BackgroundDependencyLoader]
        private void load(LargeTextureStore textures)
        {
            windowBg.Texture = textures.Get("chained-window");

            AddInternal(videoSettingsOverlay = new VideoSettingsOverlay());
        }

        protected override void PopIn()
        {
            this.FadeIn();
            Bg.FadeIn(400, Easing.Out);
            Window.MoveToY(0, 400, Easing.OutSine);
        }

        protected override void PopOut()
        {
            Bg.FadeOut(400, Easing.Out);
            Window.MoveToY(-1, 400, Easing.In).Finally(_ => this.FadeOut());
        }
    }
}
