using GD.Game.Graphics;
using GD.Game.UserInterface;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Screens.Profile
{
    public class ProfileScreen : GDMenuScreen
    {
        protected override BackButtonColour BackButtonColour => BackButtonColour.Pink;

        protected override Color4 BackgroundColour => new(170, 170, 170, 255);

        protected override Drawable CreateContent() => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Children = new Drawable[]
            {
                new GDSprite("select-corner", FlipOrientation.Vertical)
                {
                    Origin = Anchor.BottomLeft
                },
                new GroundLine
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(1380, 5),
                    Y = -170,
                },
                new GDTexturedButton("shards")
                {
                    Position = new Vector2(100, 270)
                },
                new Container
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    RelativeSizeAxes = Axes.X,
                    Height = 240,
                    Masking = true,
                    EdgeEffect = new EdgeEffectParameters
                    {
                        Hollow = true,
                        Radius = 5,
                        Type = EdgeEffectType.Shadow,
                        Colour = Color4.Black
                    },
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = ColourInfo.GradientVertical(Color4.Black, Color4.Black.Opacity(0.6f))
                        }
                    }
                }
            }
        };
    }
}
