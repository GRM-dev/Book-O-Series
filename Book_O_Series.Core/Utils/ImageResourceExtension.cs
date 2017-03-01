using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_O_Series.Core.Utils
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        private static ImageSource _defaultEmptyImage;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            var imageSource = ImageSource.FromResource(Source, assembly);
            return imageSource;
        }

        public static ImageSource GetEmbeddedImage(string img)
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            var imageSource = ImageSource.FromResource(img, assembly);
            return imageSource;
        }

        public static async Task<ImageSource> GetImageFromUri(string pathToImg)
        {
            Uri imgUri;
            if (!Uri.TryCreate(pathToImg, UriKind.RelativeOrAbsolute, out imgUri))
            {
                return DefaultEmptyImage;
            }
            var cm = BosCore.Current;
            //try
            //{
            //    if (!cm.FileHandler.Exists(imgUri) || cm.FileHandler.IsEmpty(imgUri))
            //    {
            //        var s = false;
            //        using (var fs = cm.FileHandler.GetFileStream(pathToImg))
            //        {
            //            if (await cm.Web.GetImage(pathToImg, fs).ConfigureAwait(false))
            //            {
            //                s = true;
            //            }
            //        }
            //        if (!s)
            //        {
            //            Debug.WriteLine("Image File " + pathToImg + " not found! ");
            //            cm.FileHandler.RemoveFile(imgUri);
            //            return DefaultEmptyImage;
            //        }
            //    }
            //    Uri rUri;
            //    if (!Uri.TryCreate(new Uri(cm.FileHandler.RootAppPath() + "\\"), imgUri, out rUri))
            //    {
            //        Debug.WriteLine("Image File " + pathToImg + " not found! ");
            //        return DefaultEmptyImage;
            //    }
            //    var imageSource = ImageSource.FromFile(FileHelper.GetAboslutePath(rUri));
            //    return imageSource;
            //    //TODO: FileHelper
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine("Image File " + pathToImg + " not found! " + e);
            //    cm.FileHandler.RemoveFile(imgUri);
            //}
            return DefaultEmptyImage;
        }

        public static ImageSource GetImageFromFile(string pathToImg)
        {
            Uri imgUri;
            var imageSource = Uri.TryCreate(pathToImg, UriKind.Absolute, out imgUri)
                ? ImageSource.FromFile(pathToImg) : _defaultEmptyImage;
            return imageSource;
        }

        public string Source { get; set; }

        public static ImageSource DefaultEmptyImage =>
            _defaultEmptyImage ??
            (_defaultEmptyImage = GetEmbeddedImage("AiRTech.Core.Resources.no-image.png"));
    }

    [ContentProperty("Icon")]
    public class IconResourceExtension : IMarkupExtension
    {

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var imageSource = ImageResourceExtension.GetEmbeddedImage(Icon);
            return imageSource;
        }

        public string Icon { get; set; }
    }
}
