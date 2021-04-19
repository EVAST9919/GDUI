using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK.Input;

namespace GD.Game.UserInterface
{
    public class GDScrollContainer : BasicScrollContainer
    {
        public GDScrollContainer()
        {
            RelativeSizeAxes = Axes.Both;
        }

        protected override ScrollbarContainer CreateScrollbar(Direction direction) => new GDScrollbar(direction);

        private class GDScrollbar : ScrollbarContainer
        {
            public const float SCROLL_BAR_HEIGHT = 7;
            public const float SCROLL_BAR_PADDING = 3;

            private Color4 hoverColour;
            private Color4 defaultColour;
            private Color4 highlightColour;

            private readonly Box box;

            public GDScrollbar(Direction direction)
                : base(direction)
            {
                const float margin = 3;

                Size = new Vector2(SCROLL_BAR_HEIGHT);
                Masking = true;
                CornerRadius = 2.5f;
                Margin = new MarginPadding
                {
                    Left = direction == Direction.Vertical ? margin : 0,
                    Right = direction == Direction.Vertical ? margin : 0,
                    Top = direction == Direction.Horizontal ? margin : 0,
                    Bottom = direction == Direction.Horizontal ? margin : 0,
                };
                Child = box = new Box { RelativeSizeAxes = Axes.Both };

                Colour = defaultColour = new Color4(220, 220, 220, 255);
                hoverColour = highlightColour = Color4.White;
            }

            public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
            {
                Vector2 size = new Vector2(SCROLL_BAR_HEIGHT)
                {
                    [(int)ScrollDirection] = val
                };
                this.ResizeTo(size, duration, easing);
            }

            protected override bool OnHover(HoverEvent e)
            {
                this.FadeColour(hoverColour, 100);
                return true;
            }

            protected override void OnHoverLost(HoverLostEvent e)
            {
                this.FadeColour(defaultColour, 100);
            }

            protected override bool OnMouseDown(MouseDownEvent e)
            {
                if (!base.OnMouseDown(e)) return false;

                // note that we are changing the colour of the box here as to not interfere with the hover effect.
                box.FadeColour(highlightColour, 100);
                return true;
            }

            protected override void OnMouseUp(MouseUpEvent e)
            {
                if (e.Button != MouseButton.Left) return;

                box.FadeColour(Color4.White, 100);

                base.OnMouseUp(e);
            }
        }
    }
}
