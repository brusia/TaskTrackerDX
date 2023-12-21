using DevExpress.Data.Browsing;
using DevExpress.Mvvm.CodeGenerators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Forms;
using TaskTrackerDX.Controls;
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

    public OrderingSettingsViewModel SortContext
    {
      get => _sortContext;
      set { _sortContext = value; OnPropertyChanged(); }
    }
    private OrderingSettingsViewModel _sortContext = new OrderingSettingsViewModel();


    public FilterSettingsViewModel FilterContext
    {
      get => _filterContext;
      set { _filterContext = value; OnPropertyChanged(); }
    }
    private FilterSettingsViewModel _filterContext = new FilterSettingsViewModel();

    private ICollectionView _tasksView;



    public MainViewModel()
    {
      _sortContext.PropertyChanged += _sortContext_PropertyChanged;
      _filterContext.PropertyChanged += _filterContext_PropertyChanged;

      _tasksView = CollectionViewSource.GetDefaultView(_taskEditContext.TaskCollection);
    }

    private void _sortContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(OrderingSettingsViewModel.SortCriteria) || e.PropertyName == nameof(OrderingSettingsViewModel.OrderByDescending))
      {
        _tasksView.SortDescriptions.Clear();
        var propertyName = string.Empty;

        switch (_sortContext.SortCriteria)
        {
          case SortFilterCriteria.CreationDate:
            propertyName = nameof(Task.CreationTimeUtc);
            break;
          case SortFilterCriteria.TaskStatus:
            propertyName = nameof(Task.Status);
            break;
          case SortFilterCriteria.ClosedDate:
            propertyName = nameof(Task.ClosedTimeUtc);
            break;
        }

        _tasksView.SortDescriptions.Add(new SortDescription(propertyName,
          _sortContext.OrderByDescending ? ListSortDirection.Descending : ListSortDirection.Ascending));
      }
    }

    private void _filterContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(FilterSettingsViewModel.FilterCriteria) 
        || e.PropertyName == nameof(FilterSettingsViewModel.FilterOn)
        || e.PropertyName == nameof(FilterSettingsViewModel.FilterCondition)
        || e.PropertyName == nameof(FilterSettingsViewModel.FilterDate))
      {
        if (_filterContext.FilterOn)
        {
          switch (_filterContext.FilterCriteria)
          {
            case SortFilterCriteria.TaskStatus:
              _tasksView.Filter = i => (i as Task).Status == _filterContext.FilterCondition;
              break;
            case SortFilterCriteria.ClosedDate:
              _tasksView.Filter = i => (i as Task).ClosedTimeUtc.Date == _filterContext.FilterDate.Date;
              break;
            case SortFilterCriteria.CreationDate:
              _tasksView.Filter = i => (i as Task).CreationTimeUtc.Date == _filterContext.FilterDate.Date;
              break;
          }
        }
        else
        {
          _tasksView.Filter = null;
        }
      }
    }
  }
}