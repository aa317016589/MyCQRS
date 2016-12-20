using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace MyCQRS.Mementos
{
    public interface IOriginator
    {
        BaseMemento GetMemento();
        void SetMemento(BaseMemento memento);
    }
}
