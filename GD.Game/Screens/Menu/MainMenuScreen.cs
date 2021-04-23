using GD.Game.Graphics;
using GD.Game.Overlays;
using GD.Game.Overlays.Settings;
using GD.Game.Screens.More;
using GD.Game.Screens.Profile;
using GD.Game.Screens.Select;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using osu.Framework.Screens;
using osuTK;

namespace GD.Game.Screens.Menu
{
    public class MainMenuScreen : GDScreen
    {
        private ExitOverlay exitOverlay;
        private SettingsOverlay settingsOverlay;

        [BackgroundDependencyLoader]
        private void load(osu.Framework.Game game, GameHost host)
        {
            AddRangeInternal(new Drawable[]
            {
                new MenuBackground(),
                new GDSprite("logo", useLarge:true)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.BottomCentre,
                    Y = -285
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
                        new GDTexturedButton("customize")
                        {
                            Anchor = Anchor.Centre,
                            ClickAction = () => this.Push(new ProfileScreen())
                        },
                        new GDTexturedButton("play")
                        {
                            Anchor = Anchor.Centre,
                            ClickAction = () => this.Push(new SelectScreen())
                        },
                        new GDTexturedButton("more")
                        {
                            Anchor = Anchor.Centre,
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
                    Spacing = new Vector2(22),
                    Y = -55,
                    Children = new[]
                    {
                        new GDTexturedButton("leaderboard")
                        {
                            Anchor = Anchor.Centre
                        },
                        new GDTexturedButton("settings")
                        {
                            Anchor = Anchor.Centre,
                            ClickAction = () => settingsOverlay?.Show()
                        },
                        new GDTexturedButton("statistics")
                        {
                            Anchor = Anchor.Centre
                        },
                        new GDTexturedButton("new-grounds")
                        {
                            Anchor = Anchor.Centre
                        }
                    }
                },
                new GDTexturedButton("cross", baseScale: 0.59f)
                {
                    Position = new Vector2(63),
                    ClickAction = () => exitOverlay?.Show()
                },
                new GDTexturedButton("robtop", baseScale: 0.67f)
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Position = new Vector2(35, -45),
                    ClickAction = () => host.OpenUrlExternally("http://www.robtopgames.com/")
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
