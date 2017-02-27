using System.Collections;

namespace Example_Data_Layer
{
    public class User
    {
        public User()
        {
            Posts = new Hashtable();
        }
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public ICollection Posts { get; set; }
    }
}