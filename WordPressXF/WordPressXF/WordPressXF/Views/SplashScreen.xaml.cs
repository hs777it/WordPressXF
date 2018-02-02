﻿using CommonServiceLocator;
using WordPressXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WordPressXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        private readonly NewsViewModel _viewModel;

        public SplashScreen()
        {
            InitializeComponent();

            _viewModel = ServiceLocator.Current.GetInstance<NewsViewModel>();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            await _viewModel.LoadPostsAsyncCommand.ExecuteAsync();
            Application.Current.MainPage = new NavigationPage(new NewsOverviewPage { BindingContext = _viewModel });
        }
    }
}