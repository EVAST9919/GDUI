using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace GD.Game.Screens
{
    public class GDScreen : Screen
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

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeIn();
        }

        public override bool OnExiting(IScreen next)
        {
            if (base.OnExiting(next))
                return true;

            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeOut();
            return false;
        }

        public override void OnSuspending(IScreen next)
        {
            base.OnSuspending(next);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeOut();
        }

        public override void OnResuming(IScreen last)
        {
            base.OnResuming(last);
            this.Delay(SCREEN_CHANGE_DURATION / 2f).FadeIn();
        }

        protected virtual void OnEscapePressed() => this.Exit();
    }
}
