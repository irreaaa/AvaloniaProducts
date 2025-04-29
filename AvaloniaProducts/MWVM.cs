using Avalonia.Media.Imaging;
using System.Threading.Tasks;

namespace AvaloniaProducts
{
    public class MWVM
    {
        public Bitmap? ImageFromBinding { get; } = ImageHelper.LoadFromResources(new ("avares://AvaloniaProducts/LoadingImages/Assets/hp.jpg"));
        public Task<Bitmap?> ImageFromWebsite { get; } = ImageHelper.LoadFromWeb(new("https://upload.wikimedia.org/wikipedia/commons/4/41/NewtonsPrincipia.jpg"));
    }
}
