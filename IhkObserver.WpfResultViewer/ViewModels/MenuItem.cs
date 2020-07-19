using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    public class MenuItem : HamburgerMenuIconItem
    {
        public static readonly DependencyProperty NavigationDestinationProperty = DependencyProperty.Register(
            nameof(NavigationDestination), typeof(Uri), typeof(MenuItem), new PropertyMetadata(default(Uri)));

        public Uri NavigationDestination
        {
            get => (Uri)this.GetValue(NavigationDestinationProperty);
            set => this.SetValue(NavigationDestinationProperty, value);
        }

        public static readonly DependencyProperty NavigationTypeProperty = DependencyProperty.Register(
            nameof(NavigationType), typeof(Type), typeof(MenuItem), new PropertyMetadata(default(Type)));

        public Type NavigationType
        {
            get => (Type)this.GetValue(NavigationTypeProperty);
            set => this.SetValue(NavigationTypeProperty, value);
        }

        public bool IsNavigation => this.NavigationDestination != null;
    }
}
