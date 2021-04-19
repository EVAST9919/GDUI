using GD.Game.Graphics;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Graphics.Containers;

namespace GD.Tests.Visual
{
    public class TestSceneGDSpriteText : TestScene
    {
        public TestSceneGDSpriteText()
        {
            FillFlowContainer flow;

            Add(new GDScrollContainer
            {
                Child = flow = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Vertical
                }
            });

            for (int i = 1; i < 100; i++)
            {
                flow.Add(new GDSpriteText(i)
                {
                    Text = $"GDSpriteText with text size {i}"
                });
            }
        }
    }
}
