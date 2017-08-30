using System;
using NetStandardClassLibrary.MovieHtmlParser;
using UIKit;

namespace iOSApplication
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

		    var htmlParser = new MovieHtmlParser();
		    var movies = await htmlParser.RetrieveMoviesOfTheWeek();

            var tableViewSource = new MovieTableViewSource
            {
                Movies = movies
            };
            MoviesTableView.Source = tableViewSource;
            MoviesTableView.ReloadData();
        }
	}
}
