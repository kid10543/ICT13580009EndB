using System;
using System.Collections.Generic;
using ICT13580009EndB.Models;
using Xamarin.Forms;

namespace ICT13580009EndB
{
    public partial class Mainpage : ContentPage
    {
        public Mainpage()
        {
            InitializeComponent();

            Newbutton.Clicked += Newbutton_Clicked;
        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProducts();
        }

        void Newbutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewpage());
        }

        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewpage(product));
        }

        async void Delete_ClickedAsync(object sender, System.EventArgs e)
        {
            var isOK = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

            if(isOK)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.DbHelper.DeleteProduct(product);

                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
            }
        }
    }
}
