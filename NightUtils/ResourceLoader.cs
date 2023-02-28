using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace PeterGriffin.NightUtils
{
    static class ResourceLoader
    {
        public static Texture2D Irios(string resourceName)
        {
            Assembly mario = Assembly.GetExecutingAssembly();
            Stream mySTEAM = mario.GetManifestResourceStream("PeterGriffin.sprites.peter.png");
            var texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            texture.LoadImage(ReadToEnd(mySTEAM));

            if (texture == null)
            {
                Console.WriteLine("sorry kid but: " + resourceName);

            }
            return texture;
        }

        static byte[] ReadToEnd(Stream steam)
        {
            long originalPosition = steam.Position;
            steam.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];
                int totalBytes = 0;
                int bytesRead = 0;

                while ((bytesRead = steam.Read(readBuffer, totalBytes, readBuffer.Length - totalBytes)) > 0)
                {
                    totalBytes += bytesRead;

                    if (totalBytes == readBuffer.Length)
                    {
                        int nextByte = steam.ReadByte();
                        if (nextByte != 0)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytes, (byte)nextByte);
                            readBuffer = temp;
                            totalBytes++;

                        }
                    }
                }
                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytes)
                {
                    buffer = new byte[totalBytes];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytes);
                }
                return buffer;
            }
            finally
            {
                steam.Position = originalPosition;
            }
        }
    }
}
