using System.Threading.Tasks;
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

        public async Task ExecuteAsYnc(UserAddCommand command)
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

           await _eventRepository.SaveAsync(aggregate, aggregate.Version);
        }

        public async Task ExecuteAsYnc(UserChangeAccumulatePointCommand command)
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

           await _eventRepository.SaveAsync(aggregate, aggregate.Version);
        }
    }
}