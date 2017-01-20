using AisProjectASP.Models;
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
        void DeleteMessage(int id);
        void SetMessages(string key, object value);
    }
}
