using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlanLekcji.ClassModel;
using System.Diagnostics;

namespace PlanLekcji.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetClas : ContentPage
    {
        public SetClas()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetClases();
        }
        private async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(ListView.SelectedItem!= null)
            {
                await App.Database.ClearConfigAsync();
                ClasList selected = new ClasList();
                selected = (ClasList)ListView.SelectedItem;
                UserConfig uc = new UserConfig(selected.ClassID);
                await App.Database.CreateUserConfig(uc);
                await Navigation.PushAsync(new MainPage());
            }
                
        }
    }
}