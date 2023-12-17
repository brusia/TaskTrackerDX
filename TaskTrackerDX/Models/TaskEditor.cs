using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerDX.Models
{
  public class TaskEditor
  {
    private Task _startState;
    private Task _currentTask;

    public TaskEditor()
    {
    }

    public void StartEdit(Task taskToEdit)
    {
      _startState = taskToEdit;
      _currentTask = (Task)taskToEdit.Clone();
    }

    public void FinishEdit(bool saveChanges)
    {
      if (!saveChanges)
      {
        _currentTask = (Task)_startState.Clone();
      }

      _startState = null;
      _currentTask = null;
    }
  }
}
