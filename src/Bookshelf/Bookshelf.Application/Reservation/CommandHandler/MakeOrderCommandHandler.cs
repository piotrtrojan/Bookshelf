using AutoMapper;
using Bookshelf.Application.Reservation.Command;
using Bookshelf.Contract.Base;
using Bookshelf.Utils.Config;

namespace Bookshelf.Application.Reservation.CommandHandler
{
    public class MakeOrderCommandHandler : ICommandHandler<MakeOrderCommand>
    {
        private readonly string _connectionString;
        private readonly IMapper mapper;
        
        public MakeOrderCommandHandler(
            GlobalConfig globalConfig,
            IMapper mapper)
        {
            _connectionString = globalConfig.CommandConnectionString;
            this.mapper = mapper;
        }
        public CommandResult Handle(MakeOrderCommand command)
        {
            return CommandResult.Fail("Not implemented yet.");
        }
    }
}
