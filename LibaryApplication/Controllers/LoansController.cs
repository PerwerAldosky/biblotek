using LibaryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LibaryApplication.Controllers
{
    public class LoansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Book>("books");
            
            List<Book> books = collection.Find(b => true).ToList();


            return View(books);
        }
        
        
        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library_application");
            var collection = database.GetCollection<Loan>("loans ");

            collection.InsertOne(loan);

            return Redirect("/Loans");


        }


    }
}
