using osu.Framework.Graphics.Sprites;

namespace GD.Game.Graphics
{
    public class GDGoldSpriteText : SpriteText
    {
        public GDGoldSpriteText(float textSize)
        {
            Font = GDFont.GetFont(Typeface.GDFontGold, textSize);
        }
    }
}
