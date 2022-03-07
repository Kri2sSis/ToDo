namespace ToDo.DataAccesse.MSSQL.Entities
{
    public class ToDoBoard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public Objective[] Objective { get; set; }


        public int UserId { get; set; }

        public User User { get; set; }

    }
}