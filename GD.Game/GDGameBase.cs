using System.Linq;
using GD.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Handlers.Mouse;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using GD.Game.Configuration;
using osu.Framework.Graphics.Rendering;

namespace GD.Game
{
    /// <summary>
    /// Set up the relevant resource stores and texture settings.
    /// </summary>
    public abstract partial class GDGameBase : osu.Framework.Game
    {
        private DependencyContainer dependencies;

        private GDConfigManager localConfig;

        [BackgroundDependencyLoader]
        private void load(IRenderer renderer)
        {
            // Load the assets from our Resources project
            Resources.AddStore(new DllResourceStore(GDResources.ResourceAssembly));

            dependencies.Cache(new LargeTextureStore(renderer, Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures"))));

            AddFont(Resources, @"Fonts/Arial");

            // Allows colored atlases
            Fonts.AddTextureSource(new TimedExpiryGlyphStore(Resources, "Fonts/bigFont-uhd"));
            Fonts.AddTextureSource(new TimedExpiryGlyphStore(Resources, "Fonts/goldFont-uhd"));

            dependencies.CacheAs(localConfig);

            Host.Window.Title = "Geometry Dash";

            // Temporary solution until there'll be an easy access to this setting
            var mouseHandler = Host.AvailableInputHandlers.First(h => h is MouseHandler);
            if (mouseHandler != null)
                ((MouseHandler)mouseHandler).UseRelativeMode.Value = false;
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            localConfig ??= new GDConfigManager(host.Storage);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            localConfig?.Dispose();
        }
    }
}
