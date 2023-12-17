using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using TaskTrackerDX.Models;

namespace TaskTrackerDX.Converters
{
  public class EnumBindingSourceExtension : MarkupExtension
  {
    public Type EnumType { get; private set; }

    public EnumBindingSourceExtension(Type enumType)
    {
      if (enumType == null || !enumType.IsEnum)
      { throw new Exception("EnumType must not be null and of type Enum."); }
      
      EnumType = enumType;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return Enum.GetValues(EnumType);
    }
  }
}