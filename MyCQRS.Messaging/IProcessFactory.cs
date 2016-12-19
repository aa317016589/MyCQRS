using System;
using MyCQRS.Domain.Events;
 

namespace MyCQRS.Messaging
{
    public interface IProcessFactory
    {
        IProcess<T> Process<T>() where T : Event;
    }
}