﻿using osu.Framework.Testing;
using osu.Framework.Graphics;
using GD.Game.UserInterface;

namespace GD.Tests.Visual
{
    public class TestSceneTexturedButton : TestScene
    {
        public TestSceneTexturedButton()
        {
            Add(new TexturedGDButton("play")
            {
                Anchor = Anchor.Centre,
                ClickAction = () => { }
            });
        }
    }
}
