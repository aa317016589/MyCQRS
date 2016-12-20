using System;
using MyCQRS.Commands;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class UserHandle :
        ICommandHandler<UserAddCommand>,
        ICommandHandler<UserChangeAccumulatePointCommand>
    {
        private readonly IEventRepository<UserAggregate> _eventRepository;

        public UserHandle(IEventRepository<UserAggregate> eventRepository)
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

            aggregate.ChangeAccumulatePoint(command.ChangeAccumulatePoint);

            _eventRepository.Save(aggregate, aggregate.Version);
        }
    }
}