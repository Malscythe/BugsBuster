﻿using BugsBuster;
using BugsBuster.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererIOS))]
namespace BugsBuster.iOS
{
    public class CustomEntryRendererIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var customEntry = (CustomEntry)e.NewElement;

                Control.Layer.CornerRadius = customEntry.EntryCornerRadius;
                Control.Layer.BorderColor = customEntry.EntryBorderColor.ToCGColor();

                Control.Layer.BorderWidth = 2;

            }
        }
    }
}