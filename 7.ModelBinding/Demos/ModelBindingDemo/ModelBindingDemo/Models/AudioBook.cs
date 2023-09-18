namespace ModelBindingDemo.Models
{
    public class AudioBook
    {
        public int? AudioBookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Object - Book ID: {this.AudioBookId}, Author: {Author}";
        }
    }
}
