using Foundation;
using System;
using UIKit;
using NetStandardClassLibrary.Models;

namespace iOSApplication
{
    public partial class MovieCell : UITableViewCell
    {
        public MovieCell (IntPtr handle) : base (handle)
        {
        }

		public void UpdateCell(MovieInformation movie)
		{
			MovieTitle.Text = movie.Title;
			MovieDirector.Text = movie.Director;
			MoviePicture.Image = UIImageFromUrl(movie.Picture);
			MovieSynopsis.Text = movie.Synopsis;
		}

		private static UIImage UIImageFromUrl(string uri)
		{
			using (var url = new NSUrl(uri))
			{
				using (var data = NSData.FromUrl(url))
				{
					return UIImage.LoadFromData(data);
				}
			}
		}
    }
}