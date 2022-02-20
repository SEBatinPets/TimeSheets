using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
