using GD.Game.Graphics;

namespace GD.Game.UserInterface
{
    public class GDTextButton : GDAutosizedButton
    {
        public GDTextButton(string text, float textSize, Typeface typeface)
        {
            Add(new GDSpriteText(textSize, typeface)
            {
                Text = text
            });
        }
    }
}
