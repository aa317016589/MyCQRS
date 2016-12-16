﻿using System;
using System.Collections.Generic;
using MyCQRS.Domain;
using MyCQRS.Domain.Mementos;

namespace MyCQRS.Domain
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);
        void Save(AggregateRoot aggregate);
        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;
        void SaveMemento(BaseMemento memento);
    }
}