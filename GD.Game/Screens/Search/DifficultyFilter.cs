using System;
using System.Linq;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Search
{
    public class DifficultyFilter : CompositeDrawable
    {
        public CustomDiff[] SelectedDifficulties => flow?.Children.Where(c => c.IsActive.Value).Select(c => c.Difficulty).ToArray() ?? Array.Empty<CustomDiff>();

        private FillFlowContainer<DiffButton> flow;

        [BackgroundDependencyLoader]
        private void load()
        {
            Size = new Vector2(1230, 170);
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                    CornerRadius = 20,
                    Child = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black.Opacity(0.5f)
                    }
                },
                flow = new FillFlowContainer<DiffButton>
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(60, 0),
                    Children = ((CustomDiff[])Enum.GetValues(typeof(CustomDiff))).Select(d => new DiffButton(d)).ToList()
                }
            };
        }

        private class DiffButton : GDActivatedTexturedButton
        {
            public readonly CustomDiff Difficulty;

            public DiffButton(CustomDiff diff)
                : base($"diff-custom/{diff}", baseScale: 0.65f)
            {
                Difficulty = diff;

                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
            }
        }
    }
}
