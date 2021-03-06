﻿using System;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class PostAddCommandHandler : ICommandHandler<PostAddCommand>
    {
        private readonly IEventRepository<PostAggregate> _eventRepository;

        public PostAddCommandHandler(IEventRepository<PostAggregate> eventRepository)
        {
            _eventRepository = eventRepository;
        }
 

        public void Execute(PostAddCommand command)
        {
            if (command == null)
            {
                return;
            }

            if (_eventRepository == null)
            {
                return;
            }

            var aggregate = new PostAggregate(command.Id, command.PostDetail);

            aggregate.Version = command.Version;

            _eventRepository.Save(aggregate, aggregate.Version);
        }
    }
}