using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.ViewModels
{
  public class TaskEditViewModel : NotifyObject
  {
    public TaskCollection TaskCollection { get => _tasks; set { _tasks = value; OnPropertyChanged(); } }
    private TaskCollection _tasks = new TaskCollection();

    private TaskEditor _editor = new TaskEditor();

    public void StartEdit()
    {
      if (_tasks.SelectedTask == null) { return; }

      _editor.StartEdit(_tasks.SelectedTask);
      // show editor control.
    }   
  }
}
