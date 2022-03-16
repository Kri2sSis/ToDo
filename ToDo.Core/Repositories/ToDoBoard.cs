using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Repositories
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
