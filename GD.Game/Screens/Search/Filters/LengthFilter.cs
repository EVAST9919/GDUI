using osu.Framework.Allocation;

namespace GD.Game.Screens.Search.Filters
{
    public class LengthFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 120;
        }
    }
}
