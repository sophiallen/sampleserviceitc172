using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookReviewSampleService" in code, svc and config file together.
//Note: the service implements the methods that are contracted in the interface. 
public class BookReviewSampleService : IBookReviewSampleService
{
    BookReviewDbEntities dbe = new BookReviewDbEntities();

    public List<string> GetAuthors()
    {
        var auth = from a in dbe.Authors
                   orderby a.AuthorName
                   select new { a.AuthorName };
        List<string> authors = new List<string>();
        foreach(var au in auth)
        {
            authors.Add(au.AuthorName.ToString());
        }

        return authors;
    }

    public List<BookLite> GetBooks(string authorName)
    {
        var bks = from b in dbe.Books
                  from a in b.Authors
                  orderby b.BookTitle
                  where a.AuthorName.Equals(authorName)
                  select new
                  {
                      b.BookTitle,
                      a.AuthorName,
                      b.BookISBN
                  };
        List<BookLite> books = new List<BookLite>();
        foreach(var bk in bks)
        {
            BookLite bl = new BookLite();
            bl.Title = bk.BookTitle;
            bl.AuthorName = bk.AuthorName;
            bl.ISBN = bk.BookISBN;
            books.Add(bl);
        }
        return books;
    }
}
