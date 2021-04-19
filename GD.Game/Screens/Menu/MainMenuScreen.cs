using GD.Game.Graphics;
using GD.Game.Overlays;
using GD.Game.Overlays.Settings;
using GD.Game.Screens.More;
using GD.Game.Screens.Select;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Menu
{
    public class MainMenuScreen : GDScreen
    {
        private ExitOverlay exitOverlay;
        private SettingsOverlay settingsOverlay;

        [BackgroundDependencyLoader]
        private void load(osu.Framework.Game game)
        {
            AddRangeInternal(new Drawable[]
            {
                new MenuBackground
                {
                    Colour = Color4.Red
                },
                new GDSprite("logo", useLarge:true)
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Y = 90
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Y = -30,
                    Direction = FillDirection.Horizontal,
                    AutoSizeAxes = Axes.Both,
                    Spacing = new Vector2(80),
                    Children = new Drawable[]
                    {
                        new TexturedGDButton("customize")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(220)
                        },
                        new TexturedGDButton("play")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(350),
                            ClickAction = () => this.Push(new SelectScreen())
                        },
                        new TexturedGDButton("more")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(220),
                            ClickAction = () => this.Push(new MoreScreen())
                        }
                    }
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Direction = FillDirection.Horizontal,
                    AutoSizeAxes = Axes.Both,
                    Spacing = new Vector2(20),
                    Y = -65,
                    Children = new[]
                    {
                        new TexturedGDButton("leaderboard")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(195, 201),
                            Scale = new Vector2(0.85f)
                        },
                        new TexturedGDButton("settings")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(195, 201),
                            Scale = new Vector2(0.85f),
                            ClickAction = () => settingsOverlay?.Show()
                        },
                        new TexturedGDButton("statistics")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(195, 201),
                            Scale = new Vector2(0.85f)
                        },
                        new TexturedGDButton("new-grounds")
                        {
                            Anchor = Anchor.Centre,
                            Size = new Vector2(195, 201),
                            Scale = new Vector2(0.9f)
                        }
                    }
                },
                new TexturedGDButton("cross")
                {
                    Size = new Vector2(180, 183),
                    Scale = new Vector2(0.6f),
                    Position = new Vector2(65),
                    ClickAction = () => exitOverlay?.Show()
                },
                exitOverlay = new ExitOverlay
                {
                    ConfirmAction = game.Exit
                },
                settingsOverlay = new SettingsOverlay()
            });
        }

        protected override void OnEscapePressed() => exitOverlay?.Show();
    }
}
