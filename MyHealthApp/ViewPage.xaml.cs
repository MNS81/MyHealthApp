using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPage : ContentPage
    {
        public ViewPage()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            StreamReader f = new StreamReader(path);
            while (!f.EndOfStream)
                list.Add(f.ReadLine());
            f.Close();
            outText.Text = string.Join(Environment.NewLine, list);
        }
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyHealth.txt");

        private async void clearButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Внимание!", "Вы действительно хотите удалить все данные из журнала?", "Да", "Нет");
            if (result)
            {
                StreamWriter f = new StreamWriter(path, false);
                f.Close();
                outText.Text = "Данные очищены!";
                await Task.Delay(2000);
                outText.Text = "";
            }
            else
                return;
        }
    }
}