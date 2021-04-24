using osu.Framework.Graphics;

namespace GD.Game.UserInterface
{
    public class GDAutosizedButton : GDButton
    {
        private readonly bool autosized;

        public GDAutosizedButton(bool autosized = true)
        {
            this.autosized = autosized;

            Content.RelativeSizeAxes = Axes.None;
            Content.AutoSizeAxes = Axes.Both;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (autosized)
                Size = Content.Size;
        }
    }
}
