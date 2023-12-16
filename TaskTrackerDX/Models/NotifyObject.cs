using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerDX.Models
{
  public class NotifyObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    public static event PropertyChangedEventHandler StaticPropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    protected static void OnStaticPropertyChanged([CallerMemberName] string property = "")
    {
      StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(property));
    }
  }
}
