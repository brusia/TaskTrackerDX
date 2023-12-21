using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskTrackerDX.Models;
using TaskStatus = TaskTrackerDX.Models.TaskStatus;

namespace TaskTrackerDX.ViewModels
{
  public class FilterSettingsViewModel : NotifyObject
  {
    public SortFilterCriteria FilterCriteria
    {
      get => _filterCriteria;
      set { if (_filterCriteria != value)
        {
          _filterCriteria = value;
          if (_filterCriteria == SortFilterCriteria.TaskStatus)
          {
            FilterConditionVisibility = Visibility.Visible;
            FilterDateVisibiility = Visibility.Hidden;
          }
          else
          {
            FilterConditionVisibility = Visibility.Hidden;
            FilterDateVisibiility = Visibility.Visible;
          }
          OnPropertyChanged();
        }
      }
    }
    private SortFilterCriteria _filterCriteria = SortFilterCriteria.CreationDate;

    public DateTime FilterDate
    {
      get => _filterDate;
      set { if ( _filterDate != value) { _filterDate = value; OnPropertyChanged(); } }
    }
    private DateTime _filterDate = DateTime.Today;

    public bool FilterOn
    {
      get => _filterOn;
      set { if (_filterOn != value) { _filterOn = value; OnPropertyChanged(); } }
    }
    private bool _filterOn;

    public TaskStatus FilterCondition
    {
      get => _filterCondition;
      set { if (_filterCondition != value) { _filterCondition = value; OnPropertyChanged(); } }
    }
    private TaskStatus _filterCondition = TaskStatus.InProgress;

    public Visibility FilterConditionVisibility
    { 
      get => _filterConditionVisibility;
      set { if (_filterConditionVisibility != value) { _filterConditionVisibility = value; OnPropertyChanged(); } }
    }
    private Visibility _filterConditionVisibility = Visibility.Visible;

    public Visibility FilterDateVisibiility
    {
      get => _filterDateVisibility;
      set { if (value != _filterDateVisibility) {  _filterDateVisibility = value; OnPropertyChanged();} }
    }
    private Visibility _filterDateVisibility = Visibility.Visible;
  }
}
