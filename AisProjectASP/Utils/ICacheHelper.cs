using System.Collections.Generic;

namespace AisProjectASP.Utils
{
    interface ICacheHelper
    {
        List<Message> GetMessages();
        void SaveMessage(Message msg);
        void ClearMessages();
        void CreateMessages();
    }
}
