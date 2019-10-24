namespace Shop.UIForm.Infrastructure
{
    using Shop.UIForm.ViewModels;

    public class IntanceLocator
    {

        public MainViewModel Main { get; set; }

        public IntanceLocator()
        {
            this.Main = new MainViewModel();
        }

    }
}

