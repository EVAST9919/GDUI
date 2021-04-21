using System;
using osu.Framework.Graphics.Sprites;

namespace GD.Game.Graphics
{
    public static class GDFont
    {
        public const float DEFAULT_FONT_SIZE = 16;

        public static FontUsage GetFont(Typeface typeface = Typeface.GDFont, float size = DEFAULT_FONT_SIZE)
            => new(getTypefaceString(typeface), size);

        private static string getTypefaceString(Typeface typeface)
        {
            switch (typeface)
            {
                case Typeface.GDFont:
                    return "bigFont-uhd";

                case Typeface.GDFontGold:
                    return "goldFont-uhd";
            }

            throw new NotSupportedException($"{typeface} typeface is not supported.");
        }
    }

    public enum Typeface
    {
        GDFont,
        GDFontGold
    }
}
