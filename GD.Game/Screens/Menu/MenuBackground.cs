using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Utils;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using GD.Game.Graphics;

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

        private class BGSprite : GDSprite
        {
            public BGSprite(int index)
                : base($"backgrounds/{index}", useLarge: true)
            {
                Anchor = Anchor.BottomLeft;
                Origin = Anchor.BottomLeft;
            }
        }
    }
}
