﻿using DevExpress.Data.Browsing;
using DevExpress.Mvvm.CodeGenerators;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.ViewModels
{
  public partial class MainViewModel : NotifyObject
  {
    public TaskEditViewModel TaskEditContext
    { 
      get => _taskEditContext;
      set { _taskEditContext = value; OnPropertyChanged(); }
    }
    private TaskEditViewModel _taskEditContext = new TaskEditViewModel();

    public SortFilterSettingsViewModel SortFilterContext 
    {
      get => _sortFilterContext;
      set { _sortFilterContext = value;OnPropertyChanged(); }
    }
    private SortFilterSettingsViewModel _sortFilterContext;

    public MainViewModel()
    {
    }
  }
}
