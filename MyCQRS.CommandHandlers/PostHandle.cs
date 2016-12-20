using System;
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

        public void Execute(PostEditCommand command)
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