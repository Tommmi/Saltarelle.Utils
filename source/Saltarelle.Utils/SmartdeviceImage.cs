using System;
using System.Collections.Generic;
using System.Html;
using System.Text;
using System.Threading.Tasks;
using jQueryApi;

namespace Saltarelle.Utils
{
	public static class SmartDeviceImage
	{
		public static void ParseHtml()
		{
			var images = jQuery.Select("img");
			foreach (ImageElement image in images.GetItems())
			{
				var src = image.Src;
				var isSmartDevice = Window.Instance.InnerWidth <= 1000;
				if (!isSmartDevice)
					ReplaceImageAsync(src, image);
			}
		}

		private static void ReplaceImageAsync(string src, ImageElement img)
		{
			if (src.Length > 4 && src[src.Length - 4] == '.')
			{
				var hdSrc = src.Insert(src.Length - 4, "-hd");
				jQuery.Get(hdSrc).Done(() =>
				{
					img.Src = hdSrc;
				});
			}
		}
	}
}
