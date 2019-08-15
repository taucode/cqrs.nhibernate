﻿using NHibernate;
using System;
using System.Data;
using TauCode.Cqrs.Commands;

namespace TauCode.Cqrs.NHibernate
{
    public class TransactionalCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly ICommandHandler<TCommand> CommandHandler;
        private readonly ISession _session;

        public TransactionalCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ISession session)
        {
            this.CommandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _session.FlushMode = FlushMode.Commit;
        }

        public virtual void Execute(TCommand command)
        {
            using (var transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                this.CommandHandler.Execute(command);

                _session.Flush();

                transaction.Commit();
            }
        }
    }
}
