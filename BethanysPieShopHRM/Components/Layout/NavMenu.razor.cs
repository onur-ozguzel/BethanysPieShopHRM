using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BethanysPieShopHRM.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string? currentUrl;

        protected override void OnInitialized()
        {
            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = NavigationManager.ToBaseRelativePath(e.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}