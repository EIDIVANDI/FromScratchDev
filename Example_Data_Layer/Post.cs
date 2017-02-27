using System;

namespace Example_Data_Layer
{
    public class Post
    {
        public int PostID { get; set; }

        public string PostContent { get; set; }

        public DateTime PostDate { get; set; }

        public User PostOwner { get; set; }

    }
}