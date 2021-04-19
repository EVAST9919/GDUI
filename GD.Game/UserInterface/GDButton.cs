using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using System;
using osu.Framework.Input.Events;
using osu.Framework.Bindables;
using osuTK.Graphics;

namespace GD.Game.UserInterface
{
    public class GDButton : Container
    {
        public Action ClickAction;

        private readonly Bindable<ButtonState> state = new();
        private readonly BindableBool enabled = new();

        protected override Container<Drawable> Content => scalableContainer;

        private Container scalableContainer;

        private readonly float finalScale;

        public GDButton(float finalScale = 1.25f)
        {
            this.finalScale = finalScale;

            Origin = Anchor.Centre;
            InternalChild = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Child = scalableContainer = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            state.BindValueChanged(onStateChanged);

            enabled.Value = ClickAction != null;
            enabled.BindValueChanged(onEnabledChanged, true);
        }

        private void onEnabledChanged(ValueChangedEvent<bool> e)
        {
            this.FadeColour(e.NewValue ? Color4.White : Color4.Gray);
        }

        private void onStateChanged(ValueChangedEvent<ButtonState> u)
        {
            switch (u.NewValue)
            {
                case ButtonState.Idle:
                    scalableContainer.ScaleTo(1f);
                    break;

                case ButtonState.ScaleUp:
                    scalableContainer.ScaleTo(finalScale, 300, Easing.OutBounce);
                    return;

                case ButtonState.ScaleDown:
                    scalableContainer.ScaleTo(1f, 300, Easing.OutBounce);
                    return;
            }
        }

        protected override bool OnHover(HoverEvent e) => true;

        protected override void OnHoverLost(HoverLostEvent e)
        {
            base.OnHoverLost(e);
            state.Value = ButtonState.ScaleDown;
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            base.OnMouseDown(e);

            if (enabled.Value)
                state.Value = ButtonState.ScaleUp;

            return true;
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            base.OnMouseUp(e);

            if (enabled.Value)
            {
                if (IsHovered)
                {
                    state.Value = ButtonState.Idle;
                    ClickAction?.Invoke();
                    return;
                }

                state.Value = ButtonState.ScaleDown;
            }
        }

        private enum ButtonState
        {
            Idle,
            ScaleUp,
            ScaleDown
        }
    }
}
