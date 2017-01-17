﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls
{
    [Preserve(AllMembers = true)]
    [Issue(IssueTracker.Bugzilla, 33561,
        "ListView Pull-to-Refresh ActivityIndicator animation stuck when navigating away and then back again")]
    public class Bugzilla33561 : TestTabbedPage
    {
        protected override void Init()
        {
            Children.Add(new NavigationPage(new ListPage()) { Title = "page 1" });
            Children.Add(new ContentPage() { Title = "page 2" });
            Children.Add(new ContentPage() { Title = "page 3" });
        }

        public class ListPage : ContentPage
        {
            bool _isRefreshing;
            ListView _listView;

            public ListPage()
            {
                var template = new DataTemplate(typeof(TextCell));
                template.SetBinding(TextCell.TextProperty, ".");

                _listView = new ListView()
                {
                    IsPullToRefreshEnabled = true,
                    ItemsSource = Enumerable.Range(0, 10).Select(no => $"FAIL {no}"),
                    ItemTemplate = template,
                    IsRefreshing = true
                };

                _listView.Refreshing += async (object sender, EventArgs e) =>
                {
                    if (_isRefreshing)
                        return;

                    _isRefreshing = true;
                    await Task.Delay(10000);
                    _listView.EndRefresh();
                    _listView.ItemsSource = Enumerable.Range(0, 10).Select(no => $"SUCCESS {no}");
                    _isRefreshing = false;
                };

                Content = _listView;

                Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                {
                    _listView.IsRefreshing = false;
                    return false;
                });
            }
        }
    }
}