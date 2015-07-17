using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public static class MassMsgUtil
    {
        private static MediaId UploadMedia(MediaType type, string path)
        {
            var mediaId = WeUtil.UploadFile(type, path);
            return mediaId;
        }

        public static long SendImageMessage(int groupId, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadMedia(MediaType.Image, path);
            var msg = new GroupImageMassMessage(groupId, mediaId.Id);
            return msg.Send();
        }

        public static long SendImageMessage(IEnumerable<string> users, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadMedia(MediaType.Image, path);
            var msg = new UserImageMassMessage(users, mediaId.Id);
            return msg.Send();
        }

        private static MediaId UploadVideo(string title, string description, string path)
        {
            var mediaId = UploadMedia(MediaType.Video, path);
            var videoMedia = new VideoServiceMediaType
            {
                MediaId = mediaId.Id,
                Title = title,
                Description = description
            };
            string url = WeUtil.GetUrl(WeConst.VIDEO_MASS_URL);
            mediaId = WeUtil.PostToUri(url, videoMedia.WriteJson(), new MediaId());
            return mediaId;
        }

        public static MediaId InternalUploadVideo(string title, string description, string media)
        {
            var videoMedia = new VideoServiceMediaType
            {
                MediaId = media,
                Title = title,
                Description = description
            };
            string url = WeUtil.GetUrl(WeConst.VIDEO_MASS_URL);
            var mediaId = WeUtil.PostToUri(url, videoMedia.WriteJson(), new MediaId());
            return mediaId;
        }

        public static long SendVideoMessage(int groupId, string title,
            string description, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadVideo(title, description, path);
            var msg = new GroupVideoMassMessage(groupId, title, description, mediaId.Id);
            return msg.Send();
        }

        public static long SendVideoMessage(IEnumerable<string> users, string title,
            string description, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadVideo(title, description, path);
            var msg = new UserVideoMassMessage(users, title, description, mediaId.Id);
            return msg.Send();
        }

        public static long SendVoiceMessage(int groupId, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadMedia(MediaType.Voice, path);
            var msg = new GroupVoiceMassMessage(groupId, mediaId.Id);
            return msg.Send();
        }

        public static long SendVoiceMessage(IEnumerable<string> users, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            var mediaId = UploadMedia(MediaType.Voice, path);
            var msg = new UserVoiceMassMessage(users, mediaId.Id);
            return msg.Send();
        }

        public static long SendTextMessage(int groupId, string text)
        {
            TkDebug.AssertArgumentNullOrEmpty(text, "text", null);

            var msg = new GroupTextMassMessage(groupId, text);
            return msg.Send();
        }

        public static long SendTextMessage(IEnumerable<string> users, string text)
        {
            TkDebug.AssertArgumentNullOrEmpty(text, "text", null);

            var msg = new UserTextMassMessage(users, text);
            return msg.Send();
        }
    }
}
