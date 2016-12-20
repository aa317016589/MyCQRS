using System;
using MyCQRS.Domain.Events;
 

namespace MyCQRS.ProcessManagers
{
    public interface IProcessFactory
    {
        IProcess<T> Process<T>() where T : Event;
    }
}