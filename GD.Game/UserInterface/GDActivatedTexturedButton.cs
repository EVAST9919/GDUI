using GD.Game.Graphics;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osuTK.Graphics;

namespace GD.Game.UserInterface
{
    public class GDActivatedTexturedButton : GDTexturedButton
    {
        public readonly BindableBool IsActive = new();

        public GDActivatedTexturedButton(string textureName, FlipOrientation flipOrientation = FlipOrientation.None, float baseScale = 0.84f, bool useLarge = false)
            : base(textureName, flipOrientation, baseScale, useLarge)
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
