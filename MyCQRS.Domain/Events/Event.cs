﻿using System;

namespace MyCQRS.Domain
{
    [Serializable]
    public class Event
    {
        public int Version;
        public Guid AggregateId { get; set; }
        public Guid Id { get; private set; }
    }
}