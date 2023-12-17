using DevExpress.Data.Browsing;
using DevExpress.Mvvm.CodeGenerators;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.ViewModels
{
  public partial class MainViewModel : NotifyObject
  {
    //[GenerateProperty]
    //string _Status;
    //[GenerateProperty]
    //string _UserName;

    //[GenerateCommand]
    //void Login() => Status = "User: " + UserName;
    //bool CanLogin() => !string.IsNullOrEmpty(UserName);

    public TaskEditViewModel TaskEditContext { get => _taskEditContext; set { _taskEditContext = value; OnPropertyChanged(); } }
    private TaskEditViewModel _taskEditContext = new TaskEditViewModel();

    public MainViewModel()
    {
    }
  }
}
