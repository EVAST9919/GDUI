using System.Collections.Generic;
using osuTK;
using osuTK.Graphics;

namespace GD.Game.Legacy
{
    public static class Dictionaries
    {
        public static readonly List<DefaultLevel> DEFAULT_LEVELS = new()
        {
            new DefaultLevel
            {
                Name = "Stereo Madness",
                StarDiff = 1,
                Orbs = new Vector2(50, 0),
                LegacyDiff = LegacyDiff.Easy,
                Colour = Color4.Blue
            },
            new DefaultLevel
            {
                Name = "Back On Track",
                StarDiff = 2,
                Orbs = new Vector2(75, 0),
                LegacyDiff = LegacyDiff.Easy,
                Colour = new Color4(248, 2, 248, 255)
            },
            new DefaultLevel
            {
                Name = "Polargeist",
                StarDiff = 3,
                Orbs = new Vector2(100, 0),
                LegacyDiff = LegacyDiff.Normal,
                Colour = new Color4(248, 2, 123, 255)
            },
            new DefaultLevel
            {
                Name = "Dry Out",
                StarDiff = 4,
                Orbs = new Vector2(125, 0),
                LegacyDiff = LegacyDiff.Normal,
                Colour = Color4.Red
            },
            new DefaultLevel
            {
                Name = "Base After Base",
                StarDiff = 5,
                Orbs = new Vector2(150, 0),
                LegacyDiff = LegacyDiff.Hard,
                Colour = new Color4(250, 124, 4, 255)
            },
            new DefaultLevel
            {
                Name = "Cant Let Go",
                StarDiff = 6,
                Orbs = new Vector2(175, 0),
                LegacyDiff = LegacyDiff.Hard,
                Colour = new Color4(252, 253, 6, 255)
            },
            new DefaultLevel
            {
                Name = "Jumper",
                StarDiff = 7,
                Orbs = new Vector2(200, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = new Color4(5, 251, 5, 255)
            },
            new DefaultLevel
            {
                Name = "Time Machine",
                StarDiff = 8,
                Orbs = new Vector2(225, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = new Color4(5, 251, 252, 255)
            },
            new DefaultLevel
            {
                Name = "Cycles",
                StarDiff = 9,
                Orbs = new Vector2(250, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = new Color4(2, 124, 248, 255)
            },
            new DefaultLevel
            {
                Name = "xStep",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = Color4.Blue
            },
            new DefaultLevel
            {
                Name = "Clutterfunk",
                StarDiff = 11,
                Orbs = new Vector2(300, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = new Color4(248, 2, 248, 255)
            },
            new DefaultLevel
            {
                Name = "Theory of Everything",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = new Color4(248, 2, 123, 255)
            },
            new DefaultLevel
            {
                Name = "Electroman Adventures",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = Color4.Red
            },
            new DefaultLevel
            {
                Name = "Clubstep",
                StarDiff = 14,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = new Color4(250, 124, 4, 255)
            },
            new DefaultLevel
            {
                Name = "Electrodynamix",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = new Color4(252, 253, 6, 255)
            },
            new DefaultLevel
            {
                Name = "Hexagon Force",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = new Color4(5, 251, 5, 255)
            },
            new DefaultLevel
            {
                Name = "Blast Processing",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = new Color4(5, 251, 252, 255)
            },
            new DefaultLevel
            {
                Name = "Theory of Everything 2",
                StarDiff = 14,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = new Color4(2, 124, 248, 255)
            },
            new DefaultLevel
            {
                Name = "Geometrical Dominator",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = Color4.Blue
            },
            new DefaultLevel
            {
                Name = "Deadlocked",
                StarDiff = 15,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = new Color4(248, 2, 248, 255)
            }
        };
    }
}
