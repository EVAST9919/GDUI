using GD.Game.Graphics.Containers;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK.Graphics;
using osuTK.Input;

namespace GD.Game.Overlays
{
    public abstract class FullScreenOverlay : CompositeDrawable
    {
        protected readonly BindableBool IsVisible = new();

        protected Box Bg { get; private set; }
        protected Drawable Window { get; private set; }

        public FullScreenOverlay()
        {
            RelativeSizeAxes = Axes.Both;
            AddRangeInternal(new Drawable[]
            {
                new InputBlockContainer
                {
                    RelativeSizeAxes = Axes.Both
                },
                Bg = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black.Opacity(0.5f),
                    Alpha = 0,
                },
                Window = CreateWindow()
            });

            Alpha = 0;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            IsVisible.BindValueChanged(onVisibilityChanged);
        }

        protected abstract Drawable CreateWindow();

        public override void Show() => IsVisible.Value = true;

        public override void Hide() => IsVisible.Value = false;

        private void onVisibilityChanged(ValueChangedEvent<bool> visible)
        {
            if (visible.NewValue)
                PopIn();
            else
                PopOut();
        }

        protected abstract void PopIn();

        protected abstract void PopOut();

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (IsVisible.Value && e.Key == Key.Escape && !e.Repeat)
            {
                IsVisible.Value = false;
                return true;
            };

            return base.OnKeyDown(e);
        }
    }
}
