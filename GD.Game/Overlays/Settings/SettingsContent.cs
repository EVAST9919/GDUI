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
                    RelativeSizeAxes = Axes.X,
                    Height = 400,
                    Padding = new MarginPadding { Horizontal = 40, Top = 30 },
                    Children = new Drawable[]
                    {
                        new GDColoredButton("Account", ButtonColour.Green)
                        {
                            Anchor = Anchor.TopLeft,
                            Origin = Anchor.TopLeft,
                            Width = 490
                        },
                        new GDColoredButton("How to play", ButtonColour.Green, 66)
                        {
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            Width = 490
                        },
                        new GDColoredButton("Options", ButtonColour.Green)
                        {
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            Width = 490
                        },
                        new GDColoredButton("Graphics", ButtonColour.Green)
                        {
                            Anchor = Anchor.CentreRight,
                            Origin = Anchor.CentreRight,
                            Width = 490,
                            ClickAction = () => GraphicsClicked?.Invoke()
                        },
                        new GDColoredButton("Rate", ButtonColour.Green)
                        {
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft,
                            Width = 315
                        },
                        new GDColoredButton("Songs", ButtonColour.Green)
                        {
                            Anchor = Anchor.BottomCentre,
                            Origin = Anchor.BottomCentre,
                            Width = 315
                        },
                        new GDColoredButton("Help", ButtonColour.Green)
                        {
                            Anchor = Anchor.BottomRight,
                            Origin = Anchor.BottomRight,
                            Width = 315
                        },
                    }
                },
                new Container
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Y = -10,
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
