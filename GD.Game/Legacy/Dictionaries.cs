using System.Collections.Generic;
using osuTK;

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
                Colour = LegacyColour.Blue
            },
            new DefaultLevel
            {
                Name = "Back On Track",
                StarDiff = 2,
                Orbs = new Vector2(75, 0),
                LegacyDiff = LegacyDiff.Easy,
                Colour = LegacyColour.Purple
            },
            new DefaultLevel
            {
                Name = "Polargeist",
                StarDiff = 3,
                Orbs = new Vector2(100, 0),
                LegacyDiff = LegacyDiff.Normal,
                Colour = LegacyColour.PurpleRed
            },
            new DefaultLevel
            {
                Name = "Dry Out",
                StarDiff = 4,
                Orbs = new Vector2(125, 0),
                LegacyDiff = LegacyDiff.Normal,
                Colour = LegacyColour.Red
            },
            new DefaultLevel
            {
                Name = "Base After Base",
                StarDiff = 5,
                Orbs = new Vector2(150, 0),
                LegacyDiff = LegacyDiff.Hard,
                Colour = LegacyColour.Orange
            },
            new DefaultLevel
            {
                Name = "Cant Let Go",
                StarDiff = 6,
                Orbs = new Vector2(175, 0),
                LegacyDiff = LegacyDiff.Hard,
                Colour = LegacyColour.Yellow
            },
            new DefaultLevel
            {
                Name = "Jumper",
                StarDiff = 7,
                Orbs = new Vector2(200, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = LegacyColour.Green
            },
            new DefaultLevel
            {
                Name = "Time Machine",
                StarDiff = 8,
                Orbs = new Vector2(225, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = LegacyColour.Cyan
            },
            new DefaultLevel
            {
                Name = "Cycles",
                StarDiff = 9,
                Orbs = new Vector2(250, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = LegacyColour.BlueSky
            },
            new DefaultLevel
            {
                Name = "xStep",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.Blue
            },
            new DefaultLevel
            {
                Name = "Clutterfunk",
                StarDiff = 11,
                Orbs = new Vector2(300, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.Purple
            },
            new DefaultLevel
            {
                Name = "Theory of Everything",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.PurpleRed
            },
            new DefaultLevel
            {
                Name = "Electroman Adventures",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.Red
            },
            new DefaultLevel
            {
                Name = "Clubstep",
                StarDiff = 14,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = LegacyColour.Orange
            },
            new DefaultLevel
            {
                Name = "Electrodynamix",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.Yellow
            },
            new DefaultLevel
            {
                Name = "Hexagon Force",
                StarDiff = 12,
                Orbs = new Vector2(325, 0),
                LegacyDiff = LegacyDiff.Insane,
                Colour = LegacyColour.Green
            },
            new DefaultLevel
            {
                Name = "Blast Processing",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = LegacyColour.Cyan
            },
            new DefaultLevel
            {
                Name = "Theory of Everything 2",
                StarDiff = 14,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = LegacyColour.BlueSky
            },
            new DefaultLevel
            {
                Name = "Geometrical Dominator",
                StarDiff = 10,
                Orbs = new Vector2(275, 0),
                LegacyDiff = LegacyDiff.Harder,
                Colour = LegacyColour.Blue
            },
            new DefaultLevel
            {
                Name = "Deadlocked",
                StarDiff = 15,
                Orbs = new Vector2(500, 0),
                LegacyDiff = LegacyDiff.Demon,
                Colour = LegacyColour.Purple
            }
        };
    }
}
