using osu.Framework.Allocation;

namespace GD.Game.Screens.Search.Filters
{
    public class QuickSearchFilter : SearchFilter
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Height = 390;
        }
    }
}
