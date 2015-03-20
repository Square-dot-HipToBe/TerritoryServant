using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using TerritoryServant.ViewModels;

namespace TerritoryServant.Controls
{
    public sealed partial class TerritoryCardControl : UserControl
    {
        private TerritoryCardDetailVm ViewModel { get { return (TerritoryCardDetailVm) DataContext; } }
        public TerritoryCardControl()
        {
            this.InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key != VirtualKey.Enter || e.KeyStatus.RepeatCount > 0) return;
            ViewModel.AddServiceGroup((sender as TextBox).Text);
            (sender as TextBox).Text = string.Empty;
        }
    }
}
