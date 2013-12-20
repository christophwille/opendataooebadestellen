using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Common
{
    public class DownloadClient
    {
        public static async Task<string> GetAsStringAsync(string url)
        {
            var handler = new HttpClientHandler();

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            var client = new HttpClient(handler);

            try
            {
                using (var response = await client.GetAsync(url).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();

                    // Body comes back as application/octetstream - thus single-byte ASCII !!!!
                    var body = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    return AsciiToString(body);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        private static string AsciiToString(byte[] bytes)
        {
            // Modified from http://stackoverflow.com/questions/7750850/encoding-ascii-getstring-in-windows-phone-platform
            return string.Concat(bytes.Select(b => (char)b));
        }

        // NOTE: This fails with an ArgumentException
        //
        //try
        //{
        //    Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
        //    Encoding utf_8 = Encoding.UTF8;

        //    // Convert data to iso-8859-1 bytes
        //    byte[] isoBytes = iso_8859_1.GetBytes(data);
        //    // Convert the bytes to utf-8
        //    byte[] utf8Bytes = Encoding.Convert(iso_8859_1, utf_8, isoBytes);
        //    // Convert the utf-8 bytes back to a string
        //    string dataUtf8 = utf_8.GetString(utf8Bytes, 0, utf8Bytes.Length);
        //}
        //catch (Exception myE)
        //{
        //    Debug.WriteLine(myE);
        //}
    }
}
