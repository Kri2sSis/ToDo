namespace ToDo.DataAccess.MSSQL.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }


        public int ToDoBoardId { get; set; }

        public ToDoBoard ToDoBoard { get; set; }


    }
}