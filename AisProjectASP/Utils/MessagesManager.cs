﻿using AisProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace AisProjectASP.Utils
{
    public class MessagesManager : IMessagesManager
    {
        public static readonly int START_MESSAGE_SIZE = 15;
        private ObjectCache cache = null;
        private string MessageKey { get { return "MessagesData"; } }

        public MessagesManager()
        {
            if (cache == null)
            {
                cache = MemoryCache.Default;
            }
        }

        public void ClearMessages()
        {
            cache.Remove(MessageKey);
        }

        public void CreateMessages()
        {
            cache.Add(MessageKey, GetMessagesList().ToList(),
               new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1) });
        }

        public List<Message> GetMessages()
        {
            return cache.Get(MessageKey) as List<Message>;
        }

        public void SaveMessage(Message msg)
        {
            var messagesList = GetMessages();
            messagesList.Add(msg);
            SetMessages(MessageKey, messagesList);
        }

        public void UpdateMessage(Message msg)
        {
            var messagesList = GetMessages();
            int index = messagesList.FindIndex(i => i.Id == msg.Id);
            messagesList.RemoveAt(index);
            messagesList.Add(msg);
            SetMessages(MessageKey, messagesList);
        }

        public void DeleteMessage(Guid id)
        {
            var messagesList = GetMessages();
            messagesList.RemoveAll(a => a.Id == id);
            SetMessages(MessageKey, messagesList);
        }

        public void SetMessages(string key, object value)
        {
            cache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1) });
        }

        private IEnumerable<Message> GetMessagesList()
        {
            return Enumerable.Range(1, START_MESSAGE_SIZE).Select(e => new Message(Guid.NewGuid(), "First title " + e, "Somebody " + e, DateTime.Now.Add(new TimeSpan(e, 0, 0, 0))));
        }
    }
}