using GD.Game.Graphics;
using GD.Game.Legacy;
using GD.Game.Screens.Search;
using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.More
{
    public class MoreScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Pink;

        protected override Color4 BackgroundColour => LegacyColour.BlueSky.FromLegacy();

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
                new GDSprite("select-corner", FlipOrientation.Vertical)
                {
                    Origin = Anchor.BottomLeft
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(50),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new[]
                    {
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("create"),
                                new BigButton("saved"),
                                new BigButton("scores")
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("quests"),
                                new BigButton("daily"),
                                new BigButton("weekly"),
                                new BigButton("gauntlets")
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(50),
                            Children = new[]
                            {
                                new BigButton("featured"),
                                new BigButton("fame"),
                                new BigButton("packs"),
                                new BigButton("search")
                                {
                                    ClickAction = () => this.Push(new SearchScreen())
                                }
                            }
                        }
                    }
                }
            }
        };

        private class BigButton : GDTexturedButton
        {
            public BigButton(string textureName)
                : base($"more-buttons/{textureName}", baseScale: 0.72f)
            {
                Anchor = Anchor.Centre;
            }
        }
    }
}
