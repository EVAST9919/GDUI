using System.ComponentModel;
using GD.Game.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace GD.Game.UserInterface
{
    public class GDLongButton : GDTexturedButton
    {
        private readonly string iconName;
        private readonly string text;
        private readonly float textSize;

        public GDLongButton(LongButtonType type, string text, string iconName = "", float textSize = 40)
            : base($"long-button-{type.GetDescription()}")
        {
            this.text = text;
            this.iconName = iconName;
            this.textSize = textSize;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            if (string.IsNullOrEmpty(iconName))
            {
                Add(new GDSpriteText(textSize)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = text
                });
            }
            else
            {
                Add(new FillFlowContainer
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(10),
                    Children = new Drawable[]
                    {
                        new GDSpriteText(textSize)
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = text
                        },
                        new GDSprite($"icons/{iconName}")
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        }
                    }
                });
            }
        }
    }

    public enum LongButtonType
    {
        [Description("1")]
        Short,
        [Description("2")]
        ShortBlue,
        [Description("3")]
        Long,
        [Description("4")]
        Medium
    }
}
