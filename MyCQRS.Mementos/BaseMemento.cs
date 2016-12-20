using System;

namespace MyCQRS.Mementos
{
    public class BaseMemento
    {
        public Guid Id { get; protected set; }
        public int Version { get; set; }
    }
}
