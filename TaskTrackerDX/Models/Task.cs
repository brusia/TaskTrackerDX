using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerDX.Models

{
  public enum TaskStatus
  {
    InProgress,
    Closed,
    Pause
  }


  public class Task : NotifyObject, ICloneable
  {
    // sets automatically
    public long Id => _id;
    private long _id;

    public string Header
    {
      get => _header;
      set { if (!_header.Equals(value)) { _header = value; OnPropertyChanged(); } }
    }
    private string _header = string.Empty;

    // string is not a better way
    // think about container
    public string Description
    {
      get => _description;
      set { if (_description.Length != value.Length || !_description.Equals(value)) { _description = value; OnPropertyChanged(); } }
    }
    private string _description = string.Empty;

    // sets automatically
    public DateTime CreationTimeUtc => _creationTimeUtc;
    private DateTime _creationTimeUtc;

    // sets automatically
    public string ClosedTimeUtc => _closedTimeUtc == DateTime.MinValue ? string.Empty : _closedTimeUtc.ToString();
    private DateTime _closedTimeUtc;


    // to think: if status is closed, is it allowed to open task again? Likely not.
    public TaskStatus Status
    {
      get => _status;
      set
      {
        if (_status != value)
        {
          _status = value;
          if (_status == TaskStatus.Closed)
          {
            _closedTimeUtc = DateTime.UtcNow;
            OnPropertyChanged(nameof(ClosedTimeUtc));
          }
          OnPropertyChanged();
        }
      }
    }
    private TaskStatus _status = TaskStatus.Pause;


    public Task(long id)
    {
      _id = id;
      _creationTimeUtc = DateTime.UtcNow;
    }

    public object Clone()
    {
      var clone = new Task(_id);

      clone._creationTimeUtc = _creationTimeUtc;
      clone._header = _header;
      clone._description = _description;
      clone._status = _status;
      clone._closedTimeUtc = _closedTimeUtc;

      return clone;
    }
  }
}
