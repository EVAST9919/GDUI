using System;
using GD.Game.LegacyAPI;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;

namespace GD.Tests.Visual
{
    public class TestSceneDecryption : TestScene
    {
        public TestSceneDecryption()
        {
            string output;

            try
            {
                output = Crypto.Decrypt(input);
            }
            catch (Exception e)
            {
                output = e.Message;
            }

            Add(new SpriteText
            {
                RelativeSizeAxes = Axes.X,
                AllowMultiline = true,
                Text = output
            });
        }

        private static readonly string input = @"C?xBJJJJJJJJH<Dsy3aE^XcGGXyDqF&q]_G^F:Hr<F{rF`xG`N]]^a[J}AgRrJiO~igFq`Na~iiOxmC22?J;FiT\rlNBlme:ex\MZN>{hd=E}Q=@mJ]YfIY_[aN:2OEIFfJa2FM\9ZNJfBLIr?hJJJJ6";
    }
}
