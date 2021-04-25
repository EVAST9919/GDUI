using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Utils;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using osu.Framework.Graphics.OpenGL.Textures;

namespace GD.Game.Screens.Menu
{
    public class MenuBackground : CompositeDrawable
    {
        private GDBackgrop bg;
        private Ground ground;

        [BackgroundDependencyLoader]
        private void load()
        {
            var bgIndex = RNG.Next(20);
            var groundIndex = RNG.Next(7);

            RelativeSizeAxes = Axes.Both;
            InternalChildren = new Drawable[]
            {
                bg = new GDBackgrop(() => new BGSprite(bgIndex), 25000),
                ground = new Ground(RNG.Next(groundIndex), true)
            };
        }

        private float h;
        private float s;
        private float v;

        protected override void LoadComplete()
        {
            base.LoadComplete();
            bg.Start();

            var initialColour = ((LegacyColour)RNG.Next(8)).ToColor4();
            bg.Colour = ground.SpriteColour = initialColour;

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

            bg.Colour = ground.SpriteColour = Color4Extensions.FromHSV(h, s, v);
        }

        private class BGSprite : Sprite
        {
            private readonly int index;

            public BGSprite(int index)
            {
                this.index = index;
            }

            [BackgroundDependencyLoader]
            private void load(LargeTextureStore textures)
            {
                Anchor = Anchor.BottomLeft;
                Origin = Anchor.BottomLeft;
                Size = new Vector2(2160);
                Texture = textures.Get($"backgrounds/{index}", WrapMode.ClampToBorder, WrapMode.ClampToBorder);
            }
        }
    }
}
