using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Placeworkers.Forms
{
	public class AndroidImageHelper
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
		/// <param name="context"></param>
		/// <returns></returns>
		public static async Task<Bitmap> GetBitmapFromImageSourceAsync(ImageSource source, Context context)
		{
			return await GetHandler(source).LoadImageAsync(source, context);
		}
	}
}
