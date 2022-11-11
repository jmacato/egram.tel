using System.Collections.Generic;

namespace Tel.Egram.Services.Messaging.Chats
{
    public class Aggregate
    {
        private long _id;
        
        public IList<Chat> Chats { get; }

        public Aggregate(long id, IList<Chat> chats)
        {
            Id = id;
            Chats = chats;
        }

        public Aggregate(IList<Chat> chats)
            : this(0, chats)
        {
        }
    }
}