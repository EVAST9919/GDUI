using GD.Game.Graphics;
using GD.Game.Screens.Search.Filters;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Search
{
    public class SearchScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Green;

        protected override Color4 BackgroundColour => new(2, 100, 248, 255);

        protected override Drawable CreateContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                new GDSprite("select-corner")
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft
                },
                new GDSprite("select-corner", FlipOrientation.Horizontal)
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomLeft
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Width = 1230,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0, 20),
                    Children = new Drawable[]
                    {
                        new TextFilter
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        },
                        new GDSpriteText(42)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = "Quick Search"
                        },
                        new QuickSearchFilter
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                        },
                        new GDSpriteText(40)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = "Filters"
                        },
                        new DifficultyFilter
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        },
                        new LengthFilter
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        }
                    }
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Direction = FillDirection.Vertical,
                    AutoSizeAxes = Axes.Both,
                    Margin = new MarginPadding { Top = 23, Right = 23 },
                    Spacing = new Vector2(0, 45),
                    Children = new Drawable[]
                    {
                        new GDTexturedButton("cross", baseScale: 0.59f)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        },
                        new GDTexturedButton("plus", baseScale: 0.59f)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        }
                    }
                }
            }
        };
    }
}
