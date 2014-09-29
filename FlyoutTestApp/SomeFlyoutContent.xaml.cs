using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FlyoutTestApp
{
    public sealed partial class SomeFlyoutContent : UserControl
    {
        public SomeFlyoutContent()
        {
            InitializeComponent();
            CreateHelperMenu();
        }

        private void CreateHelperMenu()
        {
            var menuFlyout = new MenuFlyout();

            var values = new[] {"Why", "does", "this", "hide", "the", "parent", "flyout?"};

            if (menuFlyout.Items != null)
            {
                foreach (var value in values)
                {

                    var menuItem = new MenuFlyoutItem
                    {
                        Text = value
                    };

                    menuFlyout.Items.Add(menuItem);
                }
            }
            
            FlyoutBase.SetAttachedFlyout(HelperButton, menuFlyout);
            HelperButton.Click += (sender, args) => FlyoutBase.ShowAttachedFlyout(HelperButton);
        }


    }
}
