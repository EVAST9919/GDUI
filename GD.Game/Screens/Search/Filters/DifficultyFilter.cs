using System;
using System.Linq;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace GD.Game.Screens.Search.Filters
{
    public class DifficultyFilter : SearchFilter
    {
        public CustomDiff[] SelectedDifficulties => flow?.Children.Where(c => c.IsActive.Value).Select(c => c.Difficulty).ToArray() ?? Array.Empty<CustomDiff>();

        private FillFlowContainer<DiffButton> flow;

        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 170;
            Child = flow = new FillFlowContainer<DiffButton>
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(65, 0),
                Children = ((CustomDiff[])Enum.GetValues(typeof(CustomDiff))).Select(d => new DiffButton(d)).ToList()
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
