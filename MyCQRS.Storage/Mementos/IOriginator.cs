using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCQRS.Domain.Mementos;

namespace MyCQRS.Storage.Mementos
{
    public interface IOriginator
    {
        BaseMemento GetMemento();
        void SetMemento(BaseMemento memento);
    }
}
