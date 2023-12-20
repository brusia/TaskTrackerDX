using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskTrackerDX.Models;
using Task = TaskTrackerDX.Models.Task;

namespace TaskTrackerDX.ViewModels
{
  public class TaskEditViewModel : NotifyObject
  {
    private const string SAVE_CHANGES_QUESTION = "Do you want to save your changes?";
    private const string CREATE_NEW_QUESTION = "Do you want to add this task?";

    public TaskCollection TaskCollection { get => _tasks; set { _tasks = value; OnPropertyChanged(); } }
    private TaskCollection _tasks = new TaskCollection();

    private TaskEditor _editor = new TaskEditor();

    public Visibility Visibility 
    {
      get => _taskEditControlVisibility;
      set { if (value != _taskEditControlVisibility) { _taskEditControlVisibility = value; OnPropertyChanged(); } } 
    }
    private Visibility _taskEditControlVisibility = Visibility.Hidden;

    public Visibility CollectionVisibility
    {
      get => _visibility;
      set { if (value != _visibility) { _visibility = value; OnPropertyChanged(); } }
    }
    private Visibility _visibility = Visibility.Visible;


    private bool _newTaskCreation = false;

    public void CreateTask()
    {
      if (_editor.Edition)
      {
        MessageBoxInfo("You have already editing the task. To create a new one, you need to finish with current.");
        return;
      }
      
      _tasks.CreateTask();

      _newTaskCreation = true;
      StartEdit();
    }

    public void StartEdit()
    {
      if (_tasks.SelectedTask == null) { return; }

      _editor.StartEdit(_tasks.SelectedTask, _newTaskCreation);
      Visibility = Visibility.Visible;
      CollectionVisibility = Visibility.Hidden;
    }

    public void FinishEditing(bool remove = false)
    {
      if (_tasks.SelectedTask == null) { return; }

      if (_newTaskCreation)
      {
        var saveChanges = AskQuestion(CREATE_NEW_QUESTION);
        _editor.FinishEdit(saveChanges);
        if (!saveChanges)
        {
          RemoveTask();
        }

        _newTaskCreation = false;
      }
      else
      {
        _editor.FinishEdit(remove ? true : _editor.HasChanged ? AskQuestion(SAVE_CHANGES_QUESTION) : true);
      }

      Visibility = Visibility.Collapsed;
      CollectionVisibility = Visibility.Visible;
    }

    public void RemoveTask()
    {
      if (_tasks.SelectedTask == null) { MessageBoxInfo("To remove task, you need to select it first."); }

      TaskCollection.RemoveSelected();

      if (_editor.Edition)
      {
        Visibility = Visibility.Collapsed;
        CollectionVisibility = Visibility.Visible;
      }
    }

    public bool AskQuestion(string questionMessage)
    {
      MessageBoxResult result = DXMessageBox.Show(questionMessage, "Task Tracker DX", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
      if (result == MessageBoxResult.Yes)
      {
        return true;
      }
      return false;
    }

    public void MessageBoxInfo(string message)
    {
      DXMessageBox.Show(message, "Task Tracker DX", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
