namespace ToDo.Api.Contracts
{
    public class ToDoBoard
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public Task[]? Tasks { get; set; }
    }
}