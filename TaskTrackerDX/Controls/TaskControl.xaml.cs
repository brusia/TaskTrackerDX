﻿using System;
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
using TaskTrackerDX.ViewModels;

namespace TaskTrackerDX.Controls
{
  /// <summary>
  /// Interaction logic for TaskControl.xaml
  /// </summary>
  public partial class TaskControl : ListBox
  {
    public TaskControl()
    {
      InitializeComponent();
    }

    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      var context = DataContext as MainViewModel;

      context?.TaskEditContext.StartEdit();
    }
  }
}
