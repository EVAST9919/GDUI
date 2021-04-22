using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics;
using GD.Game.Graphics;
using GD.Game.UserInterface;

namespace GD.Game.Overlays.Settings.Items.Controls
{
    public class SettingsEnumerator<T> : SettingControl<T>
        where T : Enum
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            AddInternal(new DrawableEnumerator<T>
            {
                Current = Current
            });
        }

        private class DrawableEnumerator<U> : CompositeDrawable, IHasCurrentValue<U>
            where U : Enum
        {
            private readonly BindableWithCurrent<U> current = new();

            public Bindable<U> Current
            {
                get => current.Current;
                set => current.Current = value;
            }

            private GDSpriteText drawableValue;

            [BackgroundDependencyLoader]
            private void load()
            {
                RelativeSizeAxes = Axes.X;
                Height = 100;
                InternalChild = new GridContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    RowDimensions = new[]
                    {
                        new Dimension()
                    },
                    ColumnDimensions = new[]
                    {
                        new Dimension(GridSizeMode.AutoSize),
                        new Dimension(),
                        new Dimension(GridSizeMode.AutoSize)
                    },
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            new GDTexturedButton("edit-arrow")
                            {
                                Anchor = Anchor.Centre,
                                ClickAction = () => changeValue(-1)
                            },
                            drawableValue = new GDSpriteText(60)
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre
                            },
                            new GDTexturedButton("edit-arrow", FlipOrientation.Horizontal)
                            {
                                Anchor = Anchor.Centre,
                                ClickAction = () => changeValue(1)
                            }
                        }
                    }
                };
            }

            protected override void LoadComplete()
            {
                base.LoadComplete();
                Current.BindValueChanged(v => drawableValue.Text = v.NewValue.ToString(), true);
            }

            private void changeValue(int direction)
            {
                var values = (U[])Enum.GetValues(typeof(U));

                int currentIndex = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    if (Current.Value.Equals(values[i]))
                    {
                        currentIndex = i;
                        break;
                    }
                }

                var newIndex = currentIndex + direction;
                if (newIndex > values.Length - 1)
                    newIndex = 0;
                else if (newIndex < 0)
                    newIndex = values.Length - 1;

                Current.Value = values[newIndex];
            }
        }
    }
}
