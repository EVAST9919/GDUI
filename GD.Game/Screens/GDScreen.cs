using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace GD.Game.Screens
{
    public partial class GDScreen : Screen
    {
        public static readonly float SCREEN_CHANGE_DURATION = 600;

        public GDScreen()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Alpha = 0;
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (!e.Repeat && e.Key == Key.Escape)
            {
                OnEscapePressed();
                return true;
            }

            return base.OnKeyDown(e);
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            base.OnEntering(e);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeIn();
        }

        public override bool OnExiting(ScreenExitEvent e)
        {
            if (base.OnExiting(e))
                return true;

            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeOut();
            return false;
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            base.OnSuspending(e);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeOut();
        }

        public override void OnResuming(ScreenTransitionEvent e)
        {
            base.OnResuming(e);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeIn();
        }

        protected virtual void OnEscapePressed() => this.Exit();
    }
}
