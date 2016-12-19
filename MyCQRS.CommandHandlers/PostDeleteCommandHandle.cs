using System;
using MyCQRS.Commands;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class PostDeleteCommandHandle : ICommandHandler<PostDeleteCommand>
    {
        private readonly IEventRepository<PostAggregate> _eventRepository;

        public PostDeleteCommandHandle(IEventRepository<PostAggregate> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Execute(PostDeleteCommand command)
        {
            if (command == null)
            {
                return;
            }

            if (_eventRepository == null)
            {
                return;
            }

            var aggregate = _eventRepository.GetById(command.Id);

            aggregate.Delete();

            _eventRepository.Save(aggregate, aggregate.Version);
        }
    }
}