using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Utils;
using GD.Game.Legacy;
using GD.Game.UserInterface;
using GD.Game.Graphics;
using System.Collections.Generic;

namespace GD.Game.Screens.Menu
{
    public class MenuBackground : CompositeDrawable
    {
        private static readonly List<int> allowed_bgs = new() { 0, 6, 11, 19 };
        private static readonly List<int> allowed_grounds = new() { 0, 5 };

        private GDBackgrop bg;
        private Ground ground;

        [BackgroundDependencyLoader]
        private void load()
        {
            var bgIndex = allowed_bgs[RNG.Next(allowed_bgs.Count)];
            var groundIndex = allowed_grounds[RNG.Next(allowed_grounds.Count)];

            RelativeSizeAxes = Axes.Both;
            InternalChildren = new Drawable[]
            {
                bg = new GDBackgrop(() => new BGSprite(bgIndex), 25000),
                ground = new Ground(groundIndex, true)
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
