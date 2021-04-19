using osu.Framework.Graphics.Sprites;

namespace GD.Game.Graphics
{
    public class GDSpriteText : SpriteText
    {
        public GDSpriteText(float textSize)
        {
            Font = GDFont.GetFont(Typeface.GDFont, textSize);
        }
    }
}
