using Bookshelf.Contract.Base;
using Bookshelf.Model.Enum;

namespace Bookshelf.Application.Reservation.Command
{
    public class MakeOrderCommand : ICommand
    {
        public int PieceId { get; set; }
        public int UserId { get; set; }
    }
}
