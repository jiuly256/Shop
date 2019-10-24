namespace Shop.UIForm.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;
        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstace()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
