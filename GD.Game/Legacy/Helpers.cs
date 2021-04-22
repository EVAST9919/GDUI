using System;
using osuTK.Graphics;

namespace GD.Game.Legacy
{
    public static class Helpers
    {
        public static Color4 ToColor4(this LegacyColour legacyColour)
        {
            switch (legacyColour)
            {
                case LegacyColour.Blue:
                    return Color4.Blue;

                case LegacyColour.Purple:
                    return new Color4(248, 2, 248, 255);

                case LegacyColour.PurpleRed:
                    return new Color4(248, 2, 123, 255);

                case LegacyColour.Red:
                    return Color4.Red;

                case LegacyColour.Orange:
                    return new Color4(250, 124, 4, 255);

                case LegacyColour.Yellow:
                    return new Color4(252, 253, 6, 255);

                case LegacyColour.Green:
                    return new Color4(5, 251, 5, 255);

                case LegacyColour.Cyan:
                    return new Color4(5, 251, 252, 255);

                case LegacyColour.BlueSky:
                    return new Color4(2, 124, 248, 255);
            }

            throw new NotSupportedException($"{legacyColour} legacy colour is not supported.");
        }
    }
}
