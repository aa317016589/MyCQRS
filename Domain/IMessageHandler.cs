﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCQRS.Domain;

namespace MyCQRS.Domain
{
    public interface IMessageHandler
    {
        Task HandleAsync<T>(T message) where T : Event;
    }
}
