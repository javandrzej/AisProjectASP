using AisProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace AisProjectASP.Utils
{
    public class CacheHelper : ICacheHelper
    {
        private ObjectCache cache = null;
        private string MessageKey { get { return "MessagesData"; } }

        public CacheHelper()
        {
            cache = MemoryCache.Default;
        }

        public void ClearMessages()
        {
            cache.Remove(MessageKey);
        }

        public void CreateMessages()
        {
            cache.Add(MessageKey, Message.GetMessagesList(),
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
        }

        public void UpdateMessage(Message msg)
        {
            var messagesList = GetMessages();
            int index = messagesList.FindIndex(i => i.Id == msg.Id);
            messagesList.RemoveAt(index);
            messagesList.Add(msg);
        }

        public void DeleteMessage(int id)
        {
            var messagesList = GetMessages();
            messagesList.RemoveAll(a => a.Id == id);
            SetMessages(MessageKey, messagesList);
        }

        public void SetMessages(string key, object value)
        {
            cache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1) });
        }
    }
}