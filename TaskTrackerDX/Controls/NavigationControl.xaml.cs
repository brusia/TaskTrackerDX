using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskTrackerDX.Models;
using TaskTrackerDX.ViewModels;

namespace TaskTrackerDX.Controls
{
  /// <summary>
  /// Interaction logic for NavigationControl.xaml
  /// </summary>
  public partial class NavigationControl : UserControl
  {
    private TaskEditViewModel _context;

    public NavigationControl()
    {
      InitializeComponent();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
      if (_context == null) { InitContext(); }

      _context?.CreateTask();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
      if (_context == null) { InitContext(); }

      _context?.StartEdit();
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
      if (_context == null) { InitContext(); }

      //check if it is edition mode (then not remove).

      if (_context?.TaskCollection.SelectedTask != null && _context.AskQuestion("Do you want to delete selected item?"))
      {
        _context?.RemoveTask();
      }
    }

    private void InitContext()
    {
      if (DataContext != null && DataContext is TaskEditViewModel viewModel)
      {
        _context = viewModel;
      }
    }
  }
}
