// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSApplication
{
    [Register ("MovieCell")]
    partial class MovieCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MovieDirector { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView MoviePicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView MovieSynopsis { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MovieTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MovieDirector != null) {
                MovieDirector.Dispose ();
                MovieDirector = null;
            }

            if (MoviePicture != null) {
                MoviePicture.Dispose ();
                MoviePicture = null;
            }

            if (MovieSynopsis != null) {
                MovieSynopsis.Dispose ();
                MovieSynopsis = null;
            }

            if (MovieTitle != null) {
                MovieTitle.Dispose ();
                MovieTitle = null;
            }
        }
    }
}