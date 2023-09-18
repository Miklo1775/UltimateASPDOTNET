namespace ModelBindingDemo.Models
{
    public class Book
    {
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Object - Book ID: {this.BookId}, Author: {Author}";
        }
    }
}
