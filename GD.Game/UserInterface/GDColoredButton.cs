using GD.Game.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.OpenGL.Textures;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace GD.Game.UserInterface
{
    public class GDColoredButton : GDButton
    {
        private Container left;
        private Container right;

        private readonly string text;
        private readonly ButtonColour buttonColour;
        private readonly float textSize;

        public GDColoredButton(string text, ButtonColour buttonColour, float textSize = 85)
        {
            this.text = text;
            this.buttonColour = buttonColour;
            this.textSize = textSize;

            Height = 100;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            AddRange(new Drawable[]
            {
                new GridContainer
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
                            left = new Container
                            {
                                RelativeSizeAxes = Axes.Y,
                                Child = new Sprite
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Texture = textures.Get($"button-{buttonColour.ToString().ToLower()}/left", WrapMode.ClampToBorder, WrapMode.ClampToBorder)
                                }
                            },
                            new Sprite
                            {
                                RelativeSizeAxes = Axes.Both,
                                Texture = textures.Get($"button-{buttonColour.ToString().ToLower()}/middle", WrapMode.ClampToBorder, WrapMode.ClampToBorder)
                            },
                            right = new Container
                            {
                                RelativeSizeAxes = Axes.Y,
                                Child = new Sprite
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Texture = textures.Get($"button-{buttonColour.ToString().ToLower()}/right", WrapMode.ClampToBorder, WrapMode.ClampToBorder)
                                }
                            }
                        }
                    }
                },
                new GDGoldSpriteText(textSize)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = text
                }
            });
        }

        protected override void Update()
        {
            base.Update();
            left.Width = right.Width = DrawHeight * 29 / 110f;
        }
    }

    public enum ButtonColour
    {
        Green,
        Gray
    }
}
