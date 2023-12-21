using DevExpress.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.ViewModels
{
  public enum SortFilterCriteria
  {
    TaskStatus,
    CreationDate,
    ClosedDate
  }
  public class OrderingSettingsViewModel : NotifyObject
  {
    public SortFilterCriteria SortCriteria
    {
      get => _sortCriteria;
      set { if (_sortCriteria != value) { _sortCriteria = value; OnPropertyChanged(); } }
    }
    private SortFilterCriteria _sortCriteria = SortFilterCriteria.CreationDate;

    public bool OrderByDescending
    {
      get => _sortingOn;
      set { if (_sortingOn != value) { _sortingOn = value; OnPropertyChanged(); OnPropertyChanged(nameof(Image)); } }
    }
    private bool _sortingOn;

    public BitmapImage Image
    {
      get => _sortingOn ? _imageDescending : _imageAscending;
      set { }
    }
    private BitmapImage _imageDescending = new BitmapImage(new Uri("pack://application:,,,/DevExpress.Images.v23.2;component/GrayScaleImages/Data/SortDesc_32x32.png", UriKind.Absolute));
    private BitmapImage _imageAscending = new BitmapImage(new Uri("pack://application:,,,/DevExpress.Images.v23.2;component/GrayScaleImages/Data/SortAsc_32x32.png", UriKind.Absolute));

  }
}
