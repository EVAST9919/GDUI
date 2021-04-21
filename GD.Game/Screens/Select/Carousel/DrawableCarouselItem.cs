using System;
using System.Linq;
using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Select.Carousel
{
    public class DrawableCarouselItem : CompositeDrawable
    {
        public CarouselItemState State { get; set; }

        public readonly Bindable<CarouselItem> Item = new();

        private GDSpriteText drawableName;
        private GDSpriteText drawableDiff;
        private DiffIcon icon;
        private ProgressBar normalProgress;
        private ProgressBar practiceProgress;
        private CoinsContainer coinsContainer;

        private Sample playSample;

        [BackgroundDependencyLoader]
        private void load(ISampleStore samples)
        {
            playSample = samples.Get("select-play");

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Y = -30;
            RelativePositionAxes = Axes.X;
            Width = 1150;
            AutoSizeAxes = Axes.Y;
            InternalChild = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 45),
                Children = new Drawable[]
                {
                    new GDButton(1.05f)
                    {
                        RelativeSizeAxes = Axes.X,
                        Height = 320,
                        Anchor = Anchor.TopCentre,
                        Origin = Anchor.TopCentre,
                        ClickAction = () =>
                        {
                            playSample.Play();
                        },
                        Child = new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Masking = true,
                            CornerRadius = 30,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4.Black.Opacity(0.5f)
                                },
                                new GDSprite("star-small", FlipOrientation.None, baseScale: 0.6f)
                                {
                                    Anchor = Anchor.TopRight,
                                    Origin = Anchor.TopRight,
                                    Margin = new MarginPadding { Top = 20, Right = 35 }
                                },
                                drawableDiff = new GDSpriteText(45)
                                {
                                    Anchor = Anchor.TopRight,
                                    Origin = Anchor.TopRight,
                                    Colour = Color4.Yellow,
                                    Margin = new MarginPadding { Top = 15, Right = 85 }
                                },
                                new FillFlowContainer
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    AutoSizeAxes = Axes.Both,
                                    Direction = FillDirection.Horizontal,
                                    Spacing = new Vector2(50, 0),
                                    Y = -10,
                                    Children = new Drawable[]
                                    {
                                        new Container
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre,
                                            Size = new Vector2(110),
                                            Child = icon = new DiffIcon()
                                        },
                                        drawableName = new GDSpriteText(77)
                                        {
                                            Anchor = Anchor.Centre,
                                            Origin = Anchor.Centre
                                        }
                                    }
                                },
                                coinsContainer = new CoinsContainer
                                {
                                    Anchor = Anchor.BottomRight,
                                    Origin = Anchor.BottomRight,
                                    Margin = new MarginPadding(15)
                                }
                            }
                        }
                    },
                    normalProgress = new ProgressBar("Normal Mode", new Color4(0, 255, 0, 255)),
                    practiceProgress = new ProgressBar("Practice Mode", new Color4(0, 255, 255, 255))
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            Item.BindValueChanged(i =>
            {
                drawableName.Text = i.NewValue.Name;
                drawableDiff.Text = i.NewValue.StarDiff.ToString();
                icon.LegacyDiff.Value = i.NewValue.LegacyDiff;
                normalProgress.Progress = i.NewValue.Progress;
                practiceProgress.Progress = i.NewValue.PracticeProgress;
                coinsContainer.CoinsTaken = i.NewValue.CoinsTaken;
            }, true);
        }

        private class CoinsContainer : FillFlowContainer
        {
            private int[] coinsTaken;

            public int[] CoinsTaken
            {
                get => coinsTaken;
                set
                {
                    coinsTaken = value ?? Array.Empty<int>();
                    updateCoins();
                }
            }

            public CoinsContainer()
            {
                AutoSizeAxes = Axes.Both;
                Direction = FillDirection.Horizontal;
                Spacing = new Vector2(10, 0);
            }

            private void updateCoins()
            {
                Clear();
                AddRange(new Drawable[]
                {
                    new GDSprite(coinsTaken.Contains(1) ? "coin" : "coin-gray")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre
                    },
                    new GDSprite(coinsTaken.Contains(2) ? "coin" : "coin-gray")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre
                    },
                    new GDSprite(coinsTaken.Contains(3) ? "coin" : "coin-gray")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre
                    }
                });
            }
        }

        private class DiffIcon : Sprite
        {
            public readonly Bindable<LegacyDiff> LegacyDiff = new();

            [Resolved]
            private TextureStore textures { get; set; }

            [BackgroundDependencyLoader]
            private void load()
            {
                RelativeSizeAxes = Axes.Both;
                FillMode = FillMode.Fit;
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
            }

            protected override void LoadComplete()
            {
                base.LoadComplete();
                LegacyDiff.BindValueChanged(diff => Texture = textures.Get($"diff-legacy/{diff.NewValue}"), true);
            }
        }

        private class ProgressBar : FillFlowContainer
        {
            private int progress;

            public int Progress
            {
                get => progress;
                set
                {
                    progress = value;
                    progressBox.Width = value / 100f;
                    progressText.Text = $"{value}%";
                }
            }

            private readonly Box progressBox;
            private readonly GDSpriteText progressText;

            public ProgressBar(string name, Color4 colour)
            {
                RelativeSizeAxes = Axes.X;
                AutoSizeAxes = Axes.Y;
                Direction = FillDirection.Vertical;
                Spacing = new Vector2(0, 15);
                Children = new Drawable[]
                {
                    new GDSpriteText(42)
                    {
                        Anchor = Anchor.TopCentre,
                        Origin = Anchor.TopCentre,
                        Text = name
                    },
                    new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        Height = 70,
                        Anchor = Anchor.TopCentre,
                        Origin = Anchor.TopCentre,
                        Children = new Drawable[]
                        {
                            new CircularContainer
                            {
                                Masking = true,
                                RelativeSizeAxes = Axes.Both,
                                Child = new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4.Black.Opacity(0.5f)
                                }
                            },
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Padding = new MarginPadding(5),
                                Child = new CircularContainer
                                {
                                    Masking = true,
                                    RelativeSizeAxes = Axes.Both,
                                    Children = new Drawable[]
                                    {
                                        new Box
                                        {
                                            RelativeSizeAxes = Axes.Both,
                                            Alpha = 0,
                                            AlwaysPresent = true
                                        },
                                        progressBox = new Box
                                        {
                                            RelativeSizeAxes = Axes.Both,
                                            Width = 0,
                                            Colour = colour
                                        }
                                    }
                                }
                            },
                            progressText = new GDSpriteText(42)
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre
                            }
                        }
                    }
                };
            }
        }
    }

    public enum CarouselItemState
    {
        Current,
        Prev,
        Next
    }
}
