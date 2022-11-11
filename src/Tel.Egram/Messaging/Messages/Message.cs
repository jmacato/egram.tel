using TdLib;

namespace Tel.Egram.Services.Messaging.Messages
{
    public class Message
    {
        private Message _replyMessage;
        
        private TdApi.Message _messageData;
        
        private TdApi.Chat _chatData;
        
        private TdApi.User _userData;
    }
}