using System;
using GD.Game.Graphics;
using GD.Game.Overlays.Settings.Items.Controls;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace GD.Game.Overlays.Settings
{
    public class SettingsContent : CompositeDrawable
    {
        public Action GraphicsClicked;

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(1100, 700);
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding { Horizontal = 10 },
                    Child = new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Children = new Drawable[]
                        {
                            new GridContainer
                            {
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                RowDimensions = new[]
                                {
                                    new Dimension(GridSizeMode.AutoSize),
                                    new Dimension(GridSizeMode.AutoSize)
                                },
                                ColumnDimensions = new[]
                                {
                                    new Dimension(GridSizeMode.Relative, size: 0.5f),
                                    new Dimension()
                                },
                                Content = new[]
                                {
                                    new Drawable[]
                                    {
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Account", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        },
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("How to play", ButtonColour.Green, 70)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        }
                                    },
                                    new Drawable[]
                                    {
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Options", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        },
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Graphics", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre,
                                                ClickAction = () => GraphicsClicked?.Invoke()
                                            }
                                        }
                                    }
                                }
                            },
                            new GridContainer
                            {
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                RowDimensions = new[]
                                {
                                    new Dimension(GridSizeMode.AutoSize)
                                },
                                ColumnDimensions = new[]
                                {
                                    new Dimension(GridSizeMode.Relative, size: 1f/3),
                                    new Dimension(GridSizeMode.Relative, size: 1f/3),
                                    new Dimension()
                                },
                                Content = new[]
                                {
                                    new Drawable[]
                                    {
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Rate", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        },
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Songs", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        },
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Padding = new MarginPadding(20),
                                            Child = new GDColoredButton("Help", ButtonColour.Green)
                                            {
                                                RelativeSizeAxes = Axes.X,
                                                Anchor = Anchor.Centre
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Container
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Y = -13,
                    Padding = new MarginPadding { Horizontal = 200 },
                    Child = new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(0, 20),
                        Children = new Drawable[]
                        {
                            new GDSpriteText(50)
                            {
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                Text = "Music"
                            },
                            new SettingsSlider
                            {
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                Current = frameworkConfig.GetBindable<double>(FrameworkSetting.VolumeMusic)
                            },
                            new GDSpriteText(50)
                            {
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                Text = "SFX"
                            },
                            new SettingsSlider
                            {
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                Current = frameworkConfig.GetBindable<double>(FrameworkSetting.VolumeEffect)
                            }
                        }
                    }
                }
            };
        }
    }
}
