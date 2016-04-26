using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookReviewSampleService" in both code and config file together.
[ServiceContract]
public interface IBookReviewSampleService
{
    [OperationContract]
    List<string> GetAuthors();

    [OperationContract]
    List<BookLite> GetBooks(string authorName);
}


[DataContract]
public class BookLite
{
    [DataMember] 
    public string Title { set; get; }

    [DataMember] 
    public string ISBN { set; get; }

    [DataMember]
    public string AuthorName { set; get; }
}