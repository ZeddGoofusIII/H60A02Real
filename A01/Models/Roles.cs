namespace A01.Models
{
    public class Roles
    {
        public enum Types
        {
            Clerk = 1,
            Manager = 2,
            Customer = 3
        }
        public string Code { get; set; }

        public Types NewRole { get; set; }
    }
}
