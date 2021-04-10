using System;
using System.Collections.Generic;
using System.Text;

namespace HumanTracker
{
    interface ILoginPageViewModel
    {
        string txtUsername { get; set; }
        string txtPassword { get; set; }
    }
}
