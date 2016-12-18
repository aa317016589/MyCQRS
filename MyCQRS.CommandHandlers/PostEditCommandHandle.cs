using System;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;

namespace MyCQRS.CommandHandlers
{
    public class PostEditCommandHandle : ICommandHandler<PostEditCommand>
    {
        private IEventRepository<PostAggregate> _eventRepository;

        public PostEditCommandHandle(IEventRepository<PostAggregate> eventRepository)
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

            var aggregate = _eventRepository.GetById(command.Id);

            aggregate.PostDetail = command.PostDetail;

            _eventRepository.Save(aggregate, command.Version);
        }
    }
}