using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlanLekcji.ClassModel;
using System.Diagnostics;
using PlanLekcji.Views;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlanLekcji
{
    public partial class MainPage : ContentPage
    { 
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<ClasList> lista = new List<ClasList>();
            List<UserConfig> configlista = new List<UserConfig>();

            lista = await App.Database.GetClases();
            configlista = await App.Database.GetUserConfig();
            if(lista.Count != 29)
            {
                await App.Database.ClearClassListAsync();
                CreateIDDB();
            }
            if(configlista.Count()!=1)
            {
                await App.Database.ClearConfigAsync();
                CreateConfigDB();
            }
            else
            {
                
                WebView.Source = "https://zstio.edu.pl/plan/u/podzgodz/plan.php?kl="+configlista[0].DeafultClass;
                WebView.On<Android>().EnableZoomControls(true);
                WebView.On<Android>().DisplayZoomControls(true);
            }
                

        }

        public async void CreateIDDB()
        {
            List<ClasList> tmplista = new List<ClasList>();
            tmplista.Add(new ClasList("1P A BR", "48EF9EE1C067ACE4"));
            tmplista.Add(new ClasList("1P B BR", "706EDC099226559F"));
            tmplista.Add(new ClasList("1P TETM TECH", "EF2EC8CB0F7981D5"));
            tmplista.Add(new ClasList("1P TI TECH", "5DF7BDA460250324"));
            tmplista.Add(new ClasList("1P TITR TECH", "2C8F7E2DAFACE1FE"));
            tmplista.Add(new ClasList("1P TMt TECH", "6C8ADB7B0EDE0823"));
            tmplista.Add(new ClasList("1P TP TECH", "168B18ADF02C1E04"));
            tmplista.Add(new ClasList("1P TSa TECH", "52520E9A8CAE501D"));
            tmplista.Add(new ClasList("1P TSb TECH", "2DE909C1FF05698F"));
            tmplista.Add(new ClasList("2P A BR", "78852D0AA14DF1E9"));
            tmplista.Add(new ClasList("2P B BR", "7AD2CB8581C4C097"));
            tmplista.Add(new ClasList("2P TAKTR TECH", "F10299943BE0912E"));
            tmplista.Add(new ClasList("2P TE TECH", "5DB3769290D3E631"));
            tmplista.Add(new ClasList("2P TI TECH", "15E8B9A191F68F47"));
            tmplista.Add(new ClasList("2P TMt TECH", "58FBAFD21E84ABA9"));
            tmplista.Add(new ClasList("2P TP TECH", "AB6CE2A64FE7D216"));
            tmplista.Add(new ClasList("2P TS TECH", "E77DAE8EBEDC9084"));
            tmplista.Add(new ClasList("3P A BR", "081C0A3D658682E7"));
            tmplista.Add(new ClasList("3P TETR TECH", "5EE7571B6D7CA3BE"));
            tmplista.Add(new ClasList("3P TI TECH", "7F31257093705A87"));
            tmplista.Add(new ClasList("3P TMt TECH", "6EF2760D8ADE1F5F"));
            tmplista.Add(new ClasList("3P TP TECH", "7DB68AB489AD0E3B"));
            tmplista.Add(new ClasList("3P TSTAK TECH", "0B9C622DE9BE7E1C"));
            tmplista.Add(new ClasList("4P TI TECH", "76A0F8473266E7D3"));
            tmplista.Add(new ClasList("4P TITR TECH", "19F447300F87F18F"));
            tmplista.Add(new ClasList("4P TMt TECH", "EBA40F41E4E2B92B"));
            tmplista.Add(new ClasList("4P TMTE TECH", "33AE763B1C7E212F"));
            tmplista.Add(new ClasList("4P TP TECH", "692854823D72310E"));
            tmplista.Add(new ClasList("4P TS TECH", "9B6DA88335B534CA"));

            foreach (var item in tmplista)
            {
                await App.Database.InsertToDb(item);
            }
        }
        public async void CreateConfigDB()
        {
            await Navigation.PushAsync(new SetClas());
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SetClas());
        }
    }
}
