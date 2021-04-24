using osu.Framework.Graphics.Containers;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osuTK;
using GD.Game.UserInterface;

namespace GD.Tests.Visual
{
    public class TestSceneGDLongButton : TestScene
    {
        public TestSceneGDLongButton()
        {
            Add(new FillFlowContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(20),
                AutoSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new GDLongButton(LongButtonType.Short, "Short")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        ClickAction = () => { }
                    },
                    new GDLongButton(LongButtonType.ShortBlue, "Blue")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        ClickAction = () => { }
                    },
                    new GDLongButton(LongButtonType.Medium, "Medium")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        ClickAction = () => { }
                    },
                    new GDLongButton(LongButtonType.Long, "Long")
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        ClickAction = () => { }
                    }
                }
            });
        }
    }
}
