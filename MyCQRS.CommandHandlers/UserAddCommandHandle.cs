using System;
using MyCQRS.Commands;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class UserAddCommandHandle : ICommandHandler<UserAddCommand>
    {
        private readonly IEventRepository<UserAggregate> _eventRepository;

        public UserAddCommandHandle(IEventRepository<UserAggregate> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Execute(UserAddCommand command)
        {
            if (command == null)
            {
                return;
            }

            if (_eventRepository == null)
            {
                return;
            }

            var aggregate = new UserAggregate(command.Id, command.UserName);

            aggregate.Version = command.Version;

            _eventRepository.Save(aggregate, aggregate.Version);
        }
    }
}