using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics;

namespace GD.Game.Graphics
{
    public class GDSpriteText : CompositeDrawable
    {
        public string Text
        {
            set => drawableText.Text = value;
        }

        private readonly SpriteText drawableText;

        public GDSpriteText(float textSize, Typeface typeface = Typeface.GDFont)
        {
            AutoSizeAxes = Axes.X;
            Height = textSize;
            AddInternal(drawableText = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Font = GDFont.GetFont(typeface, textSize),
                Y = -textSize / 8,
                X = -6
            });
        }
    }
}
