using System;
using System.Collections.Generic;

namespace AisProjectASP.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public static readonly int START_MESSAGE_SIZE = 15;

        public Message(int id, string title, string body, DateTime date)
        {
            Id = id;
            Title = title;
            Body = body;
            Date = date;
        }

        public static IEnumerable<Message> GetMessagesList()
        {
            for (var i = 1; i <= START_MESSAGE_SIZE; i++)
            {
                yield return new Message(i, "first title" + i, "somebody" + i, DateTime.Now.Add(new TimeSpan(i, 0, 0, 0)));
            }
        }
    }
}