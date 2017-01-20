using System;

namespace AisProjectASP.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public Message()
        {

        }

        public Message(Guid id, string title, string body, DateTime date)
        {
            Id = id;
            Title = title;
            Body = body;
            Date = date;
        }

    }
}