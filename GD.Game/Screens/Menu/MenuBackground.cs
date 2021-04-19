using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace GD.Game.Screens.Menu
{
    public class MenuBackground : CompositeDrawable
    {
        private const float full_duration = 10000f;

        private Container<BGSprite> sprites;

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            InternalChild = sprites = new Container<BGSprite>
            {
                Size = new Vector2(1920, 1080),
                Scale = new Vector2(2),
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
                Children = new[]
                {
                    new BGSprite(),
                    new BGSprite
                    {
                        X = 1080
                    },
                    new BGSprite
                    {
                        X = 2160
                    }
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        private class BGSprite : Sprite
        {
            [BackgroundDependencyLoader]
            private void load(LargeTextureStore textures)
            {
                Size = new Vector2(1080);
                Texture = textures.Get("bg-1");
            }
        }
    }
}
