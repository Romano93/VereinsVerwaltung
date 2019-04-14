using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.ConfigWindow;

namespace VV.Interfaces
{
    interface IObserver
    {
        void Subscribe();
        void UnSubscribe();
        void Update();
    }
}
