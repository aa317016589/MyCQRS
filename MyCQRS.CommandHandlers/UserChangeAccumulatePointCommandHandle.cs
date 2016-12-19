using System;
using MyCQRS.Commands;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class UserChangeAccumulatePointCommandHandle : ICommandHandler<UserChangeAccumulatePointCommand>
    {
        private readonly IEventRepository<UserAggregate> _eventRepository;

        public UserChangeAccumulatePointCommandHandle(IEventRepository<UserAggregate> eventRepository)
        {
            _eventRepository = eventRepository;
        }


        public void Execute(UserChangeAccumulatePointCommand command)
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

            aggregate.

            aggregate.Version = command.Version;

            _eventRepository.Save(aggregate, aggregate.Version);
        }
    }
}