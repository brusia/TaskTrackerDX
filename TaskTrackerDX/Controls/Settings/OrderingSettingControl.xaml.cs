using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskTrackerDX.ViewModels;

namespace TaskTrackerDX.Controls
{
  /// <summary>
  /// Interaction logic for OrderingSettingControl.xaml
  /// </summary>
  public partial class OrderingSettingControl : UserControl
  {
    public OrderingSettingControl()
    {
      InitializeComponent();
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
      var context = DataContext as OrderingSettingsViewModel;
      if (context == null) { return; }

      context.OrderByDescending = !context.OrderByDescending;
    }
  }
}
