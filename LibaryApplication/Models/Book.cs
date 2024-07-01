using MongoDB.Bson;

namespace LibaryApplication.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string author { get; set; }

    }


}

