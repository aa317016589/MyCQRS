using System;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;

namespace MyCQRS.CommandHandlers
{
    public class PostAddCommandHandler : ICommandHandler<PostAddCommand>
    {
        private readonly IEventRepository<PostAggregate> _repository;

        public PostAddCommandHandler(IEventRepository<PostAggregate> repository)
        {
            _repository = repository;
        }

        public void Execute(PostAddCommand command)
        {
            if (command == null)
            {
                return;
            }

            if (_repository == null)
            {
                return;
            }

            var aggregate = new PostAggregate(command.Id, command.PostDetail);

            aggregate.Version = command.Version;

            _repository.Save(aggregate, aggregate.Version);
        }
    }
}