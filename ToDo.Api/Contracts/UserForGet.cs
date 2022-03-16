namespace ToDo.Api.Contracts
{
    public class UserForGet
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public ICollection<ToDoBoard> ToDoBoards { get; set; }
    }
}
