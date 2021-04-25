using GD.Game.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Transforms;
using osuTK.Graphics;

namespace GD.Game.TransformableExtensions
{
    public static class GroundTransformableExtensions
    {
        public static TransformSequence<Ground> FadeSpeiteColour(this Ground ground, Color4 value, double duration = 0, Easing easing = Easing.None)
            => ground.TransformTo(nameof(ground.SpriteColour), value, duration, easing);
    }
}
