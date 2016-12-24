using System.Threading.Tasks;
using MyCQRS.Commands;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class PostHandle :
        ICommandHandler<PostAddCommand>,
        ICommandHandler<PostDeleteCommand>,
        ICommandHandler<PostEditCommand>
    {
        private readonly IEventRepository<PostAggregate> _eventRepository;

        public PostHandle(IEventRepository<PostAggregate> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task ExecuteAsYnc(PostEditCommand command)
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

            await _eventRepository.SaveAsync(aggregate, aggregate.Version);
        }

        public async Task ExecuteAsYnc(PostDeleteCommand command)
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

            await _eventRepository.SaveAsync(aggregate, aggregate.Version);
        }

        public async Task ExecuteAsYnc(PostAddCommand command)
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

            await _eventRepository.SaveAsync(aggregate, aggregate.Version);
        }
    }
}