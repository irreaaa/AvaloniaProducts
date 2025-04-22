using Avalonia.Controls.Notifications;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts
{
    public static class ImageHelper
    {
        public static Bitmap LoadFromResources(Uri resourceUri)
        {
            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        public static async Task<Bitmap?> LoadFromWeb(Uri webUri)
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(webUri);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                return new Bitmap(new MemoryStream(data));

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while downloading image '{webUri}' : {ex.Message}");
                return null;
            }
        }
    }
}
