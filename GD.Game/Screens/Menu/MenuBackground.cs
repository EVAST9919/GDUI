using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Utils;
using GD.Game.Legacy;

namespace GD.Game.Screens.Menu
{
    public class MenuBackground : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            InternalChild = new Container<BGSprite>
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

        private float h;
        private float s;
        private float v;

        protected override void LoadComplete()
        {
            base.LoadComplete();

            var initialColour = ((LegacyColour)RNG.Next(8)).FromLegacy();
            Colour = initialColour;

            var hsv = initialColour.ToHSV();
            h = hsv.h;
            s = hsv.s;
            v = hsv.v;
        }

        protected override void Update()
        {
            base.Update();

            h += (float)Clock.ElapsedFrameTime * 0.01f;
            if (h > 360)
                h = 0;

            Colour = Color4Extensions.FromHSV(h, s, v);
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
