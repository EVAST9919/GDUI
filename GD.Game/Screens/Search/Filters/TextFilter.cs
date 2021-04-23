using osu.Framework.Allocation;

namespace GD.Game.Screens.Search.Filters
{
    public class TextFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 135;
        }
    }
}
