using GD.Game.Graphics;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osuTK.Graphics;

namespace GD.Game.UserInterface
{
    public class GDActivatedTextButton : GDTextButton
    {
        public readonly BindableBool IsActive = new();

        public GDActivatedTextButton(string text, float textSize, Typeface typeface)
            : base(text, textSize, typeface)
        {
            ClickAction = IsActive.Toggle;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            IsActive.BindValueChanged(active => this.FadeColour(active.NewValue ? Color4.White : Color4.Gray), true);
        }
    }
}
