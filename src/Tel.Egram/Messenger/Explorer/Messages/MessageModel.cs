using Tel.Egram.Model.Messenger.Explorer.Items;
using Tel.Egram.Services.Graphics.Avatars;
using Tel.Egram.Services.Messaging.Messages;

namespace Tel.Egram.Model.Messenger.Explorer.Messages
{
    public abstract class MessageModel : ItemModel
    {
        private string _authorName;

        private string _time;
        
        private Avatar _avatar;
        
        private Message _message;
        
        private bool _hasReply;
        
        private ReplyModel _reply;
    }
}
