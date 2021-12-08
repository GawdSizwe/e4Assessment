using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Model
{
    public class Users
    {
        public int ID { get; set; }
        public string Names { get; set; }
        public string Surname { get; set; }
        public string CellNo { get; set; }
        public Users (int _id, string _names, string _surname, string _cellNo)
        {
            ID = _id;
            Names = _names;
            Surname = _surname;
            CellNo = _cellNo;
        }
    }
}
