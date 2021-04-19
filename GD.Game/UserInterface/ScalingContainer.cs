using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace GD.Game.UserInterface
{
    public class ScalingContainer : Container
    {
        private readonly Container content;
        protected override Container<Drawable> Content => content;

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

        public ScalingContainer()
        {
            RelativeSizeAxes = Axes.Both;

            InternalChild = new AlwaysInputContainer
            {
                RelativeSizeAxes = Axes.Both,
                RelativePositionAxes = Axes.Both,
                Child = content = new ScalingDrawSizePreservingFillContainer()
            };
        }

        private class ScalingDrawSizePreservingFillContainer : DrawSizePreservingFillContainer
        {
            public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

            public ScalingDrawSizePreservingFillContainer()
            {
                TargetDrawSize = new Vector2(1920, 1080);
            }
        }

        private class AlwaysInputContainer : Container
        {
            public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

            public AlwaysInputContainer()
            {
                RelativeSizeAxes = Axes.Both;
            }
        }
    }
}
