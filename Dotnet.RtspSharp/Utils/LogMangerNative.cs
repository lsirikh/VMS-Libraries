using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.RtspSharp.Utils
{
    public class LogMangerNative
    {
        //파일 저장위치
        string folderPath;

        private static readonly Lazy<LogMangerNative> _instance = new Lazy<LogMangerNative>(() => new LogMangerNative());

        public static LogMangerNative Instance { get { return _instance.Value; } }

        private LogMangerNative()
        {
            Init(Environment.CurrentDirectory);
        }

        public void Init(string location)
        {
            this.folderPath = location + @"\Logs";
        }

        private void CheckDir()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(this.folderPath);

                //폴더 없으면 생성
                if (di.Exists == false)
                {
                    di.Create();
                }
            }
            catch
            {
            }

        }
        private string GetFileSaveDateTime()
        {
            DateTime NowDate = DateTime.Now;

            //return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
            return NowDate.ToString("yyyy-MM-dd HH");
        }

        private string GetContentsDateTime()
        {
            DateTime NowDate = DateTime.Now;

            return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
            //return NowDate.ToString("yyyy-MM-dd HH");
        }

        public void Info(string msg)
        {
            try
            {
                var input = $"{AddLogDateTime($"[Info]{msg}")}";
                Task.WaitAll(ProcessWriteAsync(input));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void Warning(string msg)
        {
            try
            {
                var input = $"{AddLogDateTime($"[Warning]{msg}")}";
                Task.WaitAll(ProcessWriteAsync(input));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void Error(string msg)
        {
            try
            {
                var input = $"{AddLogDateTime($"[Error]{msg}")}";
                Task.WaitAll(ProcessWriteAsync(input));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private string AddLogDateTime(string msg)
        {
            return $"[{GetContentsDateTime()}]{msg}{Environment.NewLine}";
        }

        public async Task ProcessWriteAsync(string text)
        {
            CheckDir();

            //[2021-06-15 12H]logfile.txt
            var fileName = $"[{GetFileSaveDateTime()}H]logfile.txt";
            string path = this.folderPath + @"\" + fileName;

            byte[] encodedText = Encoding.Default.GetBytes(text);

            using (var sourceStream =
                new FileStream(path, FileMode.Append, FileAccess.Write,
                FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                sourceStream.Seek(0, SeekOrigin.End);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            }

        }
    }
}
