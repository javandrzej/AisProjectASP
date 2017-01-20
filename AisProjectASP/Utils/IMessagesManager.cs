using AisProjectASP.Models;
using System;
using System.Collections.Generic;

namespace AisProjectASP.Utils
{
    public interface IMessagesManager
    {
        List<Message> GetMessages();
        void SaveMessage(Message msg);
        void ClearMessages();
        void CreateMessages();
        void UpdateMessage(Message msg);
        void DeleteMessage(Guid id);
        void SetMessages(string key, object value);
    }
}
