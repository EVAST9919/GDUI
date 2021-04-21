using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Select.Carousel
{
    public class CarouselItem
    {
        public Color4 Colour { get; set; }

        public string Name { get; set; }

        public int StarDiff { get; set; }

        public LegacyDiff LegacyDiff { get; set; }

        public int Progress { get; set; }

        public int PracticeProgress { get; set; }

        public int[] CoinsTaken { get; set; }

        public Vector2 Orbs { get; set; }
    }

    public enum LegacyDiff
    {
        Easy,
        Normal,
        Hard,
        Harder,
        Insane,
        Demon
    }
}
