using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Domain.Helpers;
public class ResponsePackage
{
    #region Constructor

    public ResponsePackage()
    {

    }

    #endregion
    #region Properties

    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    #endregion
}
