using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Human
    {
        public string HumanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
       
        public Human(string humanId, string firstName, string lastName, int age)
        {
            HumanId = humanId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
    
}
