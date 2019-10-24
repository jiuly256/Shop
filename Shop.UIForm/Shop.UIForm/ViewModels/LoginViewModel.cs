
namespace Shop.UIForm.ViewModels
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForm.Views;
    using Xamarin.Forms;

    public class LoginViewModel 
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "jiuly256@gmail.com";
            this.Password = "123456";
        }
        

        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "You must enter ad email",
                   "Accept");
                return;
            }
            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "You must enter a password",
                   "Accept");
                return;
            }

            if(!this.Email.Equals("jiuly256@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Error",
                  "User or password wrong.",
                  "Accept");
            }

         //    await Application.Current.MainPage.DisplayAlert(
         //          "Ok",
         //          "Fuck yeah!!!",
         //          "Accept");

            MainViewModel.GetInstace().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
