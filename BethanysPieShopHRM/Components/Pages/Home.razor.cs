using BethanysPieShopHRM.Components.Widgets;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class Home
    {
        public List<Type> Widgets { get; set; } =
        [
            typeof(EmployeeCountWidget),
            typeof(InboxWidget)
        ];
    }
}