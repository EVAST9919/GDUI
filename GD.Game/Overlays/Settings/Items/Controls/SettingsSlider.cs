using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics;
using osuTK;
using osu.Framework.Input.Events;

namespace GD.Game.Overlays.Settings.Items.Controls
{
    public class SettingsSlider : SettingControl<double>
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
            AddInternal(new Slider
            {
                Current = Current
            });
        }

        private class Slider : CompositeDrawable, IHasCurrentValue<double>
        {
            private readonly BindableWithCurrent<double> current = new();

            public Bindable<double> Current
            {
                get => current.Current;
                set => current.Current = value;
            }

            private Nub nub;
            private Container fill;
            private Sprite fillSprite;

            [BackgroundDependencyLoader]
            private void load(TextureStore textures)
            {
                RelativeSizeAxes = Axes.X;
                Height = 50;
                InternalChildren = new Drawable[]
                {
                    fill = new Container
                    {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        RelativeSizeAxes = Axes.Both,
                        Masking = true,
                        Child = fillSprite = new Sprite
                        {
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            RelativeSizeAxes = Axes.Y,
                            Texture = textures.Get("slider-fill")
                        }
                    },
                    new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get("slider-border")
                    },
                    nub = new Nub
                    {
                        Current = Current,
                        DragInvoked = onNubDrag
                    }
                };
            }

            protected override void LoadComplete()
            {
                base.LoadComplete();
                Current.BindValueChanged(_ => updateSlider(), true);
            }

            protected override void Update()
            {
                base.Update();
                fillSprite.Width = DrawWidth;
            }

            private void onNubDrag()
            {
                Current.Value = Math.Clamp(ToLocalSpace(GetContainingInputManager().CurrentState.Mouse.Position).X / DrawWidth, 0, 1);
                updateSlider();
            }

            private void updateSlider()
            {
                nub.X = (float)Current.Value;
                fill.Width = (float)Current.Value;
            }

            private class Nub : CompositeDrawable, IHasCurrentValue<double>
            {
                private readonly BindableWithCurrent<double> current = new();

                public Bindable<double> Current
                {
                    get => current.Current;
                    set => current.Current = value;
                }

                public Action DragInvoked;

                private Sprite sprite;

                [Resolved]
                private TextureStore textures { get; set; }

                [BackgroundDependencyLoader]
                private void load()
                {
                    Origin = Anchor.Centre;
                    Anchor = Anchor.CentreLeft;
                    RelativePositionAxes = Axes.X;
                    Size = new Vector2(130);
                    InternalChild = sprite = new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Texture = textures.Get("settings-slider-idle")
                    };
                }

                protected override bool OnDragStart(DragStartEvent e) => true;

                protected override void OnDrag(DragEvent e)
                {
                    base.OnDrag(e);
                    DragInvoked?.Invoke();
                }

                protected override bool OnMouseDown(MouseDownEvent e)
                {
                    sprite.Texture = textures.Get("settings-slider-hovered");
                    return base.OnMouseDown(e);
                }

                protected override void OnMouseUp(MouseUpEvent e)
                {
                    base.OnMouseUp(e);
                    sprite.Texture = textures.Get("settings-slider-idle");
                }
            }
        }
    }
}
