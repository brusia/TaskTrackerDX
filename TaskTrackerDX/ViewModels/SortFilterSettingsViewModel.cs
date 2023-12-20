using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.ViewModels
{
  public enum SortFilterCriteria
  {
    Id,
    TaskStatus,
    CreationDate,
    ClosedDate
  }
  public class SortFilterSettingsViewModel : NotifyObject
  {
    public SortFilterCriteria SortCriteria
    {
      get => _sortCriteria;
      set { if (_sortCriteria != value) { _sortCriteria = value; OnPropertyChanged(); } }
    }
    private SortFilterCriteria _sortCriteria = SortFilterCriteria.Id;

    public SortFilterCriteria FilterCriteria
    {
      get => _filterCriteria;
      set { if (_filterCriteria != value) { _filterCriteria = value; OnPropertyChanged(); } }
    }
    private SortFilterCriteria _filterCriteria = SortFilterCriteria.Id;

    public bool FilterOn
    {
      get => _filterOn;
      set { if (_filterOn != value) { _filterOn = value;  OnPropertyChanged(); } }
    }
    private bool _filterOn;

    public bool SortingOn
    {
      get => _sortingOn;
      set { if (_sortingOn != value) { _sortingOn = value; OnPropertyChanged(); } }
    }
    private bool _sortingOn;
  }
}
