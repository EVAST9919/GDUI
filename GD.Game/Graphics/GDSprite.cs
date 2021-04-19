using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace GD.Game.Graphics
{
    public class GDSprite : Sprite
    {
        private readonly string textureName;
        private readonly bool useLarge;
        private readonly FlipOrientation flipOrientation;
        private readonly float baseScale;

        public GDSprite(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.83f, bool useLarge = false)
        {
            this.textureName = textureName;
            this.flipOrientation = flipOrientation;
            this.baseScale = baseScale;
            this.useLarge = useLarge;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures, LargeTextureStore largeTextures)
        {
            Texture = useLarge ? largeTextures.Get(textureName) : textures.Get(textureName);
            Size = Texture.Size;

            var scale = new Vector2(baseScale);

            switch (flipOrientation)
            {
                case FlipOrientation.Vertical:
                    scale *= new Vector2(1, -1);
                    break;

                case FlipOrientation.Horizontal:
                    scale *= new Vector2(-1, 1);
                    break;
            }

            Scale = scale;
        }
    }

    public enum FlipOrientation
    {
        None,
        Vertical,
        Horizontal
    }
}
