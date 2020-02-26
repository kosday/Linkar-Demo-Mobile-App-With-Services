﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LinkarViewFiles.Models;
using LinkarViewFiles.ViewModels;

namespace LinkarViewFiles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetailPage : ContentPage
    {
        CustomerDetailViewModel viewModel;

        public CustomerDetailPage(CustomerDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CustomerDetailPage()
        {
            InitializeComponent();

            //var customer = new Customer
            //{
            //    Text = "Item 1",
            //    Description = "This is an customer description."
            //};

            viewModel = new CustomerDetailViewModel();//customer);
            BindingContext = viewModel;
        }
    }
}