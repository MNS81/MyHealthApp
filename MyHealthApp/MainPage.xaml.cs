using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHealthApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            StreamWriter s = new StreamWriter(path, true);
            s.Close();
        }
        string upPress;
        string lowPress;
        string hRate;
        string hState;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyHealth.txt");
        List<string> list = new List<string>();

        private async void writeData_Clicked(object sender, EventArgs e)
        {
            upPress = !string.IsNullOrEmpty(upPressureInput.Text) ? upPressureInput.Text : "!";
            lowPress = !string.IsNullOrEmpty(lowPressureInput.Text) ? lowPressureInput.Text : "!";
            hRate = !string.IsNullOrEmpty(heartRateInput.Text) ? heartRateInput.Text : "!";
            hState = !string.IsNullOrEmpty(healthState.Text) ? healthState.Text : "OK!";
            if (upPress == "!" || lowPress == "!" || hRate == "!")
                outMessage.Text = "Проверьте введённые данные!";
            else
            {
                StreamWriter f = new StreamWriter(path, true);
                f.WriteLine($"{DateTime.Now.ToString().Split()[0]}  {upPress}, {lowPress}, {hRate} -> {hState}");
                f.Close();
                outMessage.Text = "Данные записаны!";
            }
            ResetValues();
            await Task.Delay(2000);
            outMessage.Text = "";
            return;
        }

        private void ResetValues()
        {
            upPressureInput.Text = string.Empty;
            lowPressureInput.Text = string.Empty;
            heartRateInput.Text = string.Empty;
            healthState.Text = string.Empty;
            upPress = string.Empty;
            lowPress = string.Empty;
            hRate = string.Empty;
            hState = string.Empty;
        }

        private async void viewData_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewPage());
        }
    }
}