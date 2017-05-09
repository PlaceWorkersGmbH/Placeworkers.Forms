using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
///copied from https://theconfuzedsourcecode.wordpress.com/2016/12/12/an-awesome-image-helper-to-convert-xamarin-forms-imagesource-to-ios-uiimage-or-android-bitmap/
namespace Placeworkers.Forms
{
	public class IosImageHelper
	{
		private static IImageSourceHandler GetHandler(ImageSource source)
		{
			IImageSourceHandler returnValue = null;
			if (source is UriImageSource)
			{
				returnValue = new ImageLoaderSourceHandler();
			}
			else if (source is FileImageSource)
			{
				returnValue = new FileImageSourceHandler();
			}
			else if (source is StreamImageSource)
			{
				returnValue = new StreamImagesourceHandler();
			}
			return returnValue;
		}

		/// <summary>
		/// For converting Xamarin Forms ImageSource object to Native Image type
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static async Task<UIImage> GetUIImageFromImageSourceAsync(ImageSource source)
		{
			var handler = GetHandler(source);
			return await handler.LoadImageAsync(source);
		}

	}
}
