using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;

namespace GD.Game.Overlays.Settings.Items.Controls
{
    public abstract class SettingControl<T> : CompositeDrawable, IHasCurrentValue<T>
    {
        private readonly BindableWithCurrent<T> current = new();

        public Bindable<T> Current
        {
            get => current.Current;
            set => current.Current = value;
        }
    }
}
