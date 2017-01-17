﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls
{
    [Preserve(AllMembers = true)]
    [Issue(IssueTracker.Github, 2783, "MemoryLeak in FrameRenderer", PlatformAffected.Android,
        NavigationBehavior.PushModalAsync)]
    public class Issue2783 : ContentPage
    {
        public Issue2783()
        {
            var frPatientInfo = new Frame
            {
                OutlineColor = Color.Black,
                BackgroundColor = Color.White,
                HasShadow = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5,
                Content = new AbsoluteLayout
                {
                    BackgroundColor = Color.Red,
                    HeightRequest = 1000,
                    WidthRequest = 2000,
                }
            };

            Content = frPatientInfo;
        }
    }
}