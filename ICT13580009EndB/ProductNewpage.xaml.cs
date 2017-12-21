using System;
using System.Collections.Generic;
using ICT13580009EndB.Models;
using Xamarin.Forms;

namespace ICT13580009EndB
{
    public partial class ProductNewpage : ContentPage
    {
        Product product;
        private object nameEntry;

        public ProductNewpage(Product product = null)
        {
            InitializeComponent();

            this.product = product;

            titleLabel.Text = product == null ? "เพิ่มสินค้าใหม่" : "แก้ไข้อมูลสินค้า";


            submitButton.Clicked += SubmitButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            categoryCarPicker.Items.Add("รถเก๋ง");
            categoryCarPicker.Items.Add("รถกระบะ");
            categoryCarPicker.Items.Add("รถตู้");
            categoryCarPicker.Items.Add("รถบรรทุก");
            brandCarPicker.Items.Add("โตโยต้า");
            brandCarPicker.Items.Add("ฮอนด้า");
            brandCarPicker.Items.Add("อีซูซุ");
            brandCarPicker.Items.Add("มิตซูบิชิ");
            colorCarPicker.Items.Add("ดำ");
            colorCarPicker.Items.Add("บลอนด์");
            colorCarPicker.Items.Add("แดง");
            colorCarPicker.Items.Add("น้ำเงิน");
            provincePicker.Items.Add("กรุงเทพ");
            provincePicker.Items.Add("เชียงใหม่");
            provincePicker.Items.Add("เพชรบุรี");
            provincePicker.Items.Add("ภูเก็ต");

           
        }

        async void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                product = new Product();
                product.Category = categoryCarPicker.SelectedItem.ToString();
                product.Brand = brandCarPicker.SelectedItem.ToString();
                product.Gen = productGenEntry.Text;
                product.Years = decimal.Parse(productYearEntry.Text);
                product.Miles = decimal.Parse(productMilesEntry.Text);
                product.Color = colorCarPicker.SelectedItem.ToString();
                product.Deler = productDelerEntry.Text;
                product.Description = productDescriptionEntry.Text;
                product.Price = decimal.Parse(productPriceEntry.Text);
                product.Province = provincePicker.SelectedItem.ToString();
                product.Tel = decimal.Parse(productTelEntry.Text);
                var id = App.DbHelper.AddProduct(product);
                await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");


            }
            else
            {
                product.Category = categoryCarPicker.SelectedItem.ToString();
                product.Brand = brandCarPicker.SelectedItem.ToString();
                product.Gen = productGenEntry.Text;
                product.Years = decimal.Parse(productYearEntry.Text);
                product.Miles = decimal.Parse(productMilesEntry.Text);
                product.Color = colorCarPicker.SelectedItem.ToString();
                product.Deler = productDelerEntry.Text;
                product.Description = productDescriptionEntry.Text;
                product.Price = decimal.Parse(productPriceEntry.Text);
                product.Province = provincePicker.SelectedItem.ToString();
                product.Tel = decimal.Parse(productTelEntry.Text);
                var id = App.DbHelper.AddProduct(product);
                await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย" + id, "ตกลง");
            }

            await Navigation.PopModalAsync();

        }
    }
}