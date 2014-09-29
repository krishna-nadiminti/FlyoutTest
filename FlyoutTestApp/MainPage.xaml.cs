using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FlyoutTestApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ButtonWithPopup.Click += ButtonWithPopup_Click;
        }

        void ButtonWithPopup_Click(object sender, RoutedEventArgs e)
        {
            var control = new SomeFlyoutContent();
            CreateAndShowFlyout(sender, control);
        }

        private static void CreateAndShowFlyout(
            object anchor,
            UIElement view)
        {
            var anchorElement = (FrameworkElement)anchor;
            var flyout = FlyoutBase.GetAttachedFlyout(anchorElement) as Flyout;
            if (flyout != null)
            {
                FlyoutBase.SetAttachedFlyout(anchorElement, null);
            }

            flyout = new Flyout
            {
                Placement = FlyoutPlacementMode.Top,
                Content = view
            };

            flyout.Closed += (sender, o) =>
            {
                flyout.Content = null;
            };

            FlyoutBase.SetAttachedFlyout(anchorElement, flyout);

            FlyoutBase.ShowAttachedFlyout(anchorElement);
        }
    }
}
