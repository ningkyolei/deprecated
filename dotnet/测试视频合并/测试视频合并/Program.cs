using System.IO;
using Splicer.Renderer;
using Splicer.Timeline;
using Splicer.WindowsMedia;

namespace 测试视频合并
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string aPath = @"d:\Users\lyn\Desktop\media\1.avi";
            const string bPath = @"d:\Users\lyn\Desktop\media\2.avi";
            const string aOutputPath = @"d:\Users\lyn\Desktop\3.avi";

            #region 方法一，视频质量有点差

            //using (ITimeline aTimeline = new DefaultTimeline())
            //{
            //    aTimeline.AddAudioGroup().AddTrack();
            //    var aVideoGroup = aTimeline.AddVideoGroup(32, 800, 600);
            //    var aFirstClip = aVideoGroup.AddTrack().AddVideo(aPath);
            //    aVideoGroup.AddTrack().AddVideo(bPath, aFirstClip.Duration);

            //    //用这种方式会产生很大的文件
            //    //using (var aRenderer = new AviFileRenderer(aTimeline, aOutputVideoPath))
            //    //{
            //    //    aRenderer.Render();
            //    //}

            //    using (var aRenderer = new WindowsMediaRenderer(aTimeline, aOutputPath, WindowsMediaProfiles.HighQualityVideo))
            //    {
            //        aRenderer.Render();
            //    }
            //}

            #endregion

            #region 方法二，推荐使用

            var aOutputFileStream = new FileStream(aOutputPath, FileMode.Create);
            var aWriter = new BinaryWriter(aOutputFileStream);

            var aFileStream = new FileStream(aPath, FileMode.Open);
            var aReader = new BinaryReader(aFileStream);

            aWriter.Write(aReader.ReadBytes((int) aFileStream.Length));
            aReader.Close();
            aFileStream.Close();

            var bFileStream = new FileStream(bPath, FileMode.Open);
            var bReader = new BinaryReader(bFileStream);

            aWriter.Write(bReader.ReadBytes((int) bFileStream.Length));
            bReader.Close();
            bFileStream.Close();

            aWriter.Close();
            aOutputFileStream.Close();

            #endregion

        }
    }
}