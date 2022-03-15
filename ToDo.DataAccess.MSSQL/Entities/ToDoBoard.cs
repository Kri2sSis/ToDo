namespace ToDo.DataAccess.MSSQL.Entities
{
    public class ToDoBoard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public Task[]? Tasks { get; set; }


        public User User { get; set; }

    }
}