using System.ComponentModel;
using GD.Game.Graphics;
using osu.Framework.Extensions;
using osu.Framework.Graphics;

namespace GD.Game.UserInterface
{
    public class GDLongButton : GDTexturedButton
    {
        public GDLongButton(LongButtonType type, string text)
            : base($"long-button-{type.GetDescription()}")
        {
            Add(new GDSpriteText(40)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = text
            });
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
