using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerDX.Models
{
  public class TaskCollection : ObservableCollection<Task>
  {
    private long _next_task_id = 1;
    public TaskCollection()
    {
    }

    public Task SelectedTask
    {
      get => _selectedTask;
      set { if (_selectedTask != value) { _selectedTask = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedTask))); } }
    }
    private Task _selectedTask = null;

    public void CreateTask()
    {
      var task = new Task(_next_task_id++);
      Add(task);

      SelectedTask = task;
    }

    public void RemoveSelected()
    {
      if (_selectedTask == null) { return; }

      var index = IndexOf(_selectedTask);
      Remove(_selectedTask);
      SelectedTask = null;
    }
  }
}
