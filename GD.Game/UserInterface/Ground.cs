using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osuTK;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Colour;
using osuTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics.OpenGL.Textures;

namespace GD.Game.UserInterface
{
    public class Ground : CompositeDrawable
    {
        private Color4 spriteColour;

        public Color4 SpriteColour
        {
            get => spriteColour;
            set => spriteColour = sprites.Colour = value;
        }

        private readonly GDBackgrop sprites;
        private readonly bool playing;

        public Ground(int index, bool playing)
        {
            this.playing = playing;

            RelativeSizeAxes = Axes.Both;
            InternalChildren = new Drawable[]
            {
                sprites = new GDBackgrop(() => new GroundSprite(index), 512),
                new GridContainer
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 304,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    RowDimensions = new[]
                    {
                        new Dimension()
                    },
                    ColumnDimensions = new[]
                    {
                        new Dimension(GridSizeMode.Relative, size: 0.2f),
                        new Dimension(),
                        new Dimension(GridSizeMode.Relative, size: 0.2f)
                    },
                    Content = new[]
                    {
                        new Drawable[]
                        {
                            new Box
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = ColourInfo.GradientHorizontal(Color4.Black.Opacity(0.5f), Color4.Black.Opacity(0))
                            },
                            Empty(),
                            new Box
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = ColourInfo.GradientHorizontal(Color4.Black.Opacity(0), Color4.Black.Opacity(0.5f))
                            }
                        }
                    }
                },
                new GroundLine
                {
                    RelativeSizeAxes = Axes.X,
                    Width = 0.7f,
                    Height = 4,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Y = -300
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (playing)
                sprites.Start();
        }

        private class GroundSprite : Sprite
        {
            private readonly int index;

            public GroundSprite(int index)
            {
                this.index = index;
            }

            [BackgroundDependencyLoader]
            private void load(TextureStore textures)
            {
                Anchor = Anchor.BottomLeft;
                Origin = Anchor.BottomLeft;
                Y = 512 - 304;
                Size = new Vector2(512);
                Texture = textures.Get($"grounds/{index}", WrapMode.ClampToBorder, WrapMode.ClampToBorder);
            }
        }
    }
}
