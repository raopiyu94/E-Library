using eLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLibrary.Controllers
{
    public class ValuesController : ApiController
    {
        public List<Book> Post(Book obj)
        {      
            if (ModelState.IsValid)
            {
                Dal.Dal Dal = new Dal.Dal();
                Dal.Books.Add(obj);
                Dal.SaveChanges(); 
            }

            Dal.Dal dal = new Dal.Dal(); 
            List<Book> booksList = dal.Books.ToList<Book>(); 

            return booksList;
        }

        
        public List<Book> Get() // All the record
        {

            var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();

            string bookGenre = allUrlKeyValues.
                            SingleOrDefault(x => x.Key == "bookGenre").Value;
            string bookName = allUrlKeyValues.
                            SingleOrDefault(x => x.Key == "bookName").Value;

            Dal.Dal dal = new Dal.Dal();
            List<Book> booksList = new List<Book>();
            
            if (bookName != null)
            {
                
                booksList = (from t in dal.Books
                                 where t.bookName == bookName
                                 select t).ToList<Book>();
            }
            else if (bookGenre != null)
            {
                booksList = (from t in dal.Books
                                 where t.bookGenre == bookGenre
                                 select t).ToList<Book>();
            }
            else
            {
                booksList = dal.Books.ToList<Book>();
            }

            return booksList;
        }


        
        public List<Book> Put(Book obj) 
        {
            Dal.Dal dal = new Dal.Dal();
            Book custupdate = (from temp in dal.Books
                                   where temp.bookGenre == obj.bookGenre
                                   select temp).ToList<Book>()[0];
            
            custupdate.bookCost = obj.bookCost;
            custupdate.bookName = obj.bookName;
            List<Book> booksList = dal.Books.ToList<Book>();

            return booksList;
        }
        
        public List<Book> Delete(Book obj)
        {
            // Select the record
            Dal.Dal Dal = new Dal.Dal();
            Book custdelete = (from temp in Dal.Books
                                   where temp.bookGenre == obj.bookGenre
                                   select temp).ToList<Book>()[0];
            // Remove
            Dal.Books.Remove(custdelete);
            Dal.SaveChanges();
            List<Book> booksList = Dal.Books.ToList<Book>();

            return booksList;
        }
    }
}
