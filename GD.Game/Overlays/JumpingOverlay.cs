using osu.Framework.Graphics;

namespace GD.Game.Overlays
{
    public abstract class JumpingOverlay : FullScreenOverlay
    {
        protected override void PopIn()
        {
            this.FadeIn();
            Bg.FadeIn(250, Easing.Out);
            Window.ScaleTo(0.6f).Then().ScaleTo(1, 500, Easing.OutElasticHalf);
        }

        protected override void PopOut()
        {
            this.FadeOut();
            Bg.FadeOut();
        }
    }
}
