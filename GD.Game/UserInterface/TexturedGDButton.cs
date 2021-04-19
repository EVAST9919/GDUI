using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics;
using GD.Game.Graphics;
using osuTK;

namespace GD.Game.UserInterface
{
    public class TexturedGDButton : GDButton
    {
        private readonly string textureName;
        private readonly FlipOrientation flipOrientation;

        public TexturedGDButton(string textureName, FlipOrientation flipOrientation = FlipOrientation.None)
        {
            this.textureName = textureName;
            this.flipOrientation = flipOrientation;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            var s = new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Texture = textures.Get(textureName)
            };

            switch (flipOrientation)
            {
                case FlipOrientation.Horizontal:
                    s.Scale = new Vector2(-1, 1);
                    break;

                case FlipOrientation.Vertical:
                    s.Scale = new Vector2(1, -1);
                    break;
            }

            Add(s);
        }
    }
}
