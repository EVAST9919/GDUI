using osu.Framework.Graphics.Sprites;

namespace GD.Game.Graphics
{
    public static class ArialFont
    {
        public const float DEFAULT_FONT_SIZE = 16;

        public static FontUsage GetFont(float size = DEFAULT_FONT_SIZE)
            => new("Arial", size);
    }
}
