using System.Collections;

namespace Example_Data_Layer
{
    public class Blog
    {
        public Blog()
        {
            BlogPosts = new Hashtable();
        }
        public int BlogID { get; set; }

        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }

        public ICollection BlogPosts { get; set; }

        public User BlogOwner { get; set; }
    }
}