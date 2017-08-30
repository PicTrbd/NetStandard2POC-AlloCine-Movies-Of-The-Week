using System;
using System.Collections.Generic;
using Foundation;
using NetStandardClassLibrary.Models;
using UIKit;

namespace iOSApplication
{
	public class MovieTableViewSource : UITableViewSource
	{
		private readonly string _cellIdentifier = "MovieCell";

		public List<MovieInformation> Movies = new List<MovieInformation>();


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (MovieCell)tableView.DequeueReusableCell(_cellIdentifier, indexPath);

			cell?.UpdateCell(Movies[indexPath.Row]);
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Movies.Count;
		}
	}
}
