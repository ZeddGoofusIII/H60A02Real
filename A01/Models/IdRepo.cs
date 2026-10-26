using Microsoft.EntityFrameworkCore;


namespace A01.Models
{
    public class IdRepo : IIdRepo
    {
        private readonly AccountContext _context;

        public IdRepo(AccountContext context)
        {
            _context = context;
        }
        public void editRole(Roles role)
        {
           // var account = _context.As
        }
    }
}
