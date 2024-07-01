using LibaryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;

namespace LibaryApplication.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");

            List<Book> books = collection.Find(b=> true).ToList();

            return View(books);
        }


        public IActionResult Create()
        
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
   
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");

            collection.InsertOne(book);

            return Redirect("/Books");

            

        }
        

        public IActionResult Show(string Id)
        {
           ObjectId bookId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
           
            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");

            

            Book book = collection.Find(b => b.Id == bookId).FirstOrDefault();

            return View(book);



        }
        public IActionResult Edit(string Id)
        {
            ObjectId bookId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");



            Book book = collection.Find(b => b.Id == bookId).FirstOrDefault();




            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(string Id, Book book)
        {
            ObjectId bookId = new ObjectId(Id);
            
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");

            book.Id = bookId;
           
            collection.ReplaceOne(b => b.Id == bookId, book);

            return Redirect("/Books");
        }
        
        
        
        
        
       
    }


    


}
