using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace GD.Game.Screens.Search.Filters
{
    public class QuickSearchFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 390;
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding { Horizontal = 30, Vertical = 20 },
                Children = new Drawable[]
                {
                    new GDLongButton(LongButtonType.Long, "Most Downloaded", "download", 37)
                    {
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft
                    },
                    new GDLongButton(LongButtonType.Long, "Most Liked", "like", 45)
                    {
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.TopRight
                    },
                    new GDLongButton(LongButtonType.Medium, "Trending", "trending")
                    {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft
                    },
                    new GDLongButton(LongButtonType.Medium, "Recent", "recent")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre
                    },
                    new GDLongButton(LongButtonType.Medium, "Magic", "magic")
                    {
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight
                    },
                    new GDLongButton(LongButtonType.Medium, "Awarded", "star")
                    {
                        Anchor = Anchor.BottomLeft,
                        Origin = Anchor.BottomLeft
                    },
                    new GDLongButton(LongButtonType.Medium, "Followed", "follow")
                    {
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.BottomCentre
                    },
                    new GDLongButton(LongButtonType.Medium, "Friends", "friends")
                    {
                        Anchor = Anchor.BottomRight,
                        Origin = Anchor.BottomRight
                    }
                }
            };
        }
    }
}
