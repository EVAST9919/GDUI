using GD.Game.Graphics;
using GD.Game.Overlays.Settings.Items.Controls;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace GD.Game.Overlays
{
    public class VideoSettingsOverlay : BrownOverlay
    {
        protected override GDSpriteText CreateTitle() => new GDGoldSpriteText(65)
        {
            Text = "Video Options"
        };

        private SettingsEnumerator<WindowMode> windowMode;
        private SettingsEnumerator<FrameSync> fps;

        protected override Drawable CreateWindowContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding { Horizontal = 300 },
                    Child = new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(0, 100),
                        Children = new Drawable[]
                        {
                            new FillFlowContainer
                            {
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                Direction = FillDirection.Vertical,
                                Spacing = new Vector2(0, 10),
                                Children = new Drawable[]
                                {
                                    new GDGoldSpriteText(70)
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "Window Mode"
                                    },
                                    windowMode = new SettingsEnumerator<WindowMode>
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre
                                    }
                                }
                            },
                            new FillFlowContainer
                            {
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                Direction = FillDirection.Vertical,
                                Spacing = new Vector2(0, 10),
                                Children = new Drawable[]
                                {
                                    new GDGoldSpriteText(70)
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "FPS"
                                    },
                                    fps = new SettingsEnumerator<FrameSync>
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            windowMode.Current = frameworkConfig.GetBindable<WindowMode>(FrameworkSetting.WindowMode);
            fps.Current = frameworkConfig.GetBindable<FrameSync>(FrameworkSetting.FrameSync);
        }
    }
}
