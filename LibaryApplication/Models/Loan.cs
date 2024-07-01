using MongoDB.Bson;

namespace LibaryApplication.Models
{
    public class Loan
    {

        public ObjectId Id { get; set; }
       
        public string BookId { get; set; }
        public string Name { get; set; }

       
    }
}
