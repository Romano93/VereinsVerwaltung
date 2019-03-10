using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Interfaces
{
    interface IObserver
    {
        void Update(List<IObservable> observables);
        void Subscribe();
        void UnSubscribe();
    }
}
