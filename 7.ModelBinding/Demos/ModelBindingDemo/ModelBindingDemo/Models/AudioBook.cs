using Microsoft.AspNetCore.Mvc;

namespace ModelBindingDemo.Models
{
    public class AudioBook
    {
        //WE CAN ALSO ONLY APPLY FROMQUERY AND FROMROUTE TO A SPECIFIC PROPERTY IN THE CLASS.
        //[FromRoute]
        public int? AudioBookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Object - Book ID: {this.AudioBookId}, Author: {Author}";
        }
    }
}
