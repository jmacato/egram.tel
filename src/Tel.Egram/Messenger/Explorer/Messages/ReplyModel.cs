 using CommunityToolkit.Mvvm.ComponentModel;
 using TdLib;
using Tel.Egram.Services.Graphics.Previews;
using Tel.Egram.Services.Messaging.Messages;

namespace Tel.Egram.Model.Messenger.Explorer.Messages
{
    [ObservableObject]
	public partial class ReplyModel
    {
        private string _authorName;
        
        private string _text;
        
        private bool _hasPreview;
        
        private Preview _preview;
        
        private Message _message;
        
        private TdApi.Photo _photoData;
        
        private TdApi.Sticker _stickerData;
        
        private TdApi.Video _videoData;
    }
}