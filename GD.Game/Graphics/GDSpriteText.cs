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

        private float textSize;

        public float TextSize
        {
            get => textSize;
            set
            {
                textSize = value;
                updateText();
            }
        }

        private readonly Typeface typeface;
        private readonly SpriteText drawableText;

        public GDSpriteText(float textSize, Typeface typeface = Typeface.GDFont)
        {
            this.typeface = typeface;

            AutoSizeAxes = Axes.X;
            AddInternal(drawableText = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                X = -6
            });

            TextSize = textSize;
        }

        private void updateText()
        {
            Height = textSize;
            drawableText.Font = GDFont.GetFont(typeface, textSize);
            drawableText.Y = -textSize / (typeface == Typeface.GDFont ? 5 : 8);
        }
    }
}
