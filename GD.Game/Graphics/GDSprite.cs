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

        public GDSprite(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.84f, bool useLarge = false)
        {
            this.textureName = textureName;
            this.useLarge = useLarge;

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

        [BackgroundDependencyLoader]
        private void load(TextureStore textures, LargeTextureStore largeTextures)
        {
            Texture = useLarge ? largeTextures.Get(textureName) : textures.Get(textureName);
            Size = Texture.Size;
        }
    }

    public enum FlipOrientation
    {
        None,
        Vertical,
        Horizontal
    }
}
