using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using GD.Game.UserInterface;
using osu.Framework.Graphics.UserInterface;
using osuTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics.Sprites;
using GD.Game.Graphics;

namespace GD.Game.Screens.Search.Filters
{
    public class TextFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 135;
            Add(new Container
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding(15),
                Child = new GridContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    RowDimensions = new[]
                    {
                        new Dimension()
                    },
                    ColumnDimensions = new[]
                    {
                        new Dimension(),
                        new Dimension(GridSizeMode.AutoSize)
                    },
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Padding = new MarginPadding { Right = 20 },
                                Child = new LocalTextBox()
                            },
                            new FillFlowContainer
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                AutoSizeAxes = Axes.X,
                                RelativeSizeAxes = Axes.Y,
                                Direction = FillDirection.Horizontal,
                                Spacing = new Vector2(15, 0),
                                Children = new Drawable[]
                                {
                                    new GDLongButton(LongButtonType.ShortBlue, "Search", textSize: 50)
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre
                                    },
                                    new GDTexturedButton("friends-search")
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        private class LocalTextBox : BasicTextBox
        {
            protected override Color4 SelectionColour => Color4.White.Opacity(0.6f);

            public LocalTextBox()
            {
                CornerRadius = 15;
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
                RelativeSizeAxes = Axes.Both;
                TextContainer.Height = 0.36f;
                LengthLimit = 100;
                PlaceholderText = "Enter a level, user or id";
            }

            [BackgroundDependencyLoader]
            private void load()
            {
                BackgroundUnfocused = Color4.Black.Opacity(0.4f);
                BackgroundFocused = Color4.Black.Opacity(0.4f);
            }

            protected override SpriteText CreatePlaceholder() => new SpriteText
            {
                Font = GDFont.GetFont(),
                Colour = new Color4(109, 153, 213, 255),
                Y = -5
            };

            protected override Drawable GetDrawableCharacter(char c) => new SpriteText
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Margin = new MarginPadding { Bottom = 5 },
                Text = c.ToString(),
                Font = GDFont.GetFont(size: 50)
            };

            protected override float LeftRightPadding => 15;
        }
    }
}
