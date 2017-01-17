using Xamarin.Forms.CustomAttributes;

namespace Xamarin.Forms.Controls
{
    internal class WebViewCoreGalleryPage : CoreGalleryPage<WebView>
    {
        protected override bool SupportsFocus
        {
            get { return false; }
        }

        protected override void Build(StackLayout stackLayout)
        {
            base.Build(stackLayout);

            var urlWebViewSourceContainer = new ViewContainer<WebView>(Test.WebView.UrlWebViewSource,
                new WebView
                {
                    Source = new UrlWebViewSource { Url = "https://www.google.com/" },
                    HeightRequest = 200
                }
            );

            const string html = "<html><div class=\"test\"><h2>I am raw html</h2></div></html>";
            var htmlWebViewSourceContainer = new ViewContainer<WebView>(Test.WebView.HtmlWebViewSource,
                new WebView
                {
                    Source = new HtmlWebViewSource { Html = html },
                    HeightRequest = 200
                }
            );

            var htmlFileWebSourceContainer = new ViewContainer<WebView>(Test.WebView.LoadHtml,
                new WebView
                {
                    Source = new HtmlWebViewSource
                    {
                        Html = @"<html>
<head>
<link rel=""stylesheet"" href=""default.css"">
</head>
<body>
<h1>Xamarin.Forms</h1>
<p>The CSS and image are loaded from local files!</p>
<img src='WebImages/XamarinLogo.png'/>
<p><a href=""local.html"">next page</a></p>
</body>
</html>"
                    },
                    HeightRequest = 200
                }
            );

            Add(urlWebViewSourceContainer);
            Add(htmlWebViewSourceContainer);
            Add(htmlFileWebSourceContainer);
        }

        protected override void InitializeElement(WebView element)
        {
            element.HeightRequest = 200;

            element.Source = new UrlWebViewSource { Url = "http://xamarin.com/" };
        }
    }
}