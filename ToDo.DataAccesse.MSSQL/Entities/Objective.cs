namespace ToDo.DataAccesse.MSSQL.Entities
{
    public class Objective
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