using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TaskTrackerDX.Models
{
  public class TaskEditor : NotifyObject
  { 
    private Task _startState;
    private Task _editedTask;

    public bool Edition => _editMode;
    private bool _editMode;

    public bool HasChanged => _changed;
    private bool _changed;
    private bool _closeTask = false;


    public TaskEditor()
    {
      _editMode = false;
      _changed = false;
    }


    public void StartEdit(Task taskToEdit, bool newTask)
    {
      _startState = taskToEdit;
      _editedTask = (Task)taskToEdit.Clone();

      _startState.PropertyChanged += TaskChanged;

      _editMode = true;
      _changed = newTask;
    }

    public void FinishEdit(bool saveChanges)
    {
      if (saveChanges)
      {
        if (_closeTask && _startState.Status == TaskStatus.Closed)
        {
          _startState.ClosedTimeUtc = DateTime.UtcNow;
          _startState.ClosedTimeVisibility = Visibility.Visible;
        }
      }
      else
      {
        _startState = (Task)_editedTask.Clone();
      }

      _startState = null;
      _editedTask = null;

      _editMode = false;
    }

    private void TaskChanged(object sender, PropertyChangedEventArgs e)
    {
      _changed = true;

      if(e.PropertyName == nameof(Task.Status) && sender is Task task && task.Status == TaskStatus.Closed && task.ClosedTimeUtc.Equals(DateTime.MinValue))
      {
        _closeTask = true;
      }
    }
  }
}
