using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF.MVVMBasic
{
    public partial class App : Application
    {
        #region ViewModels
        public static AlunoViewModel AlunoVM { get; set; }
        #endregion

        public App()
        {
            InitializarVMs();

            InitializeComponent();
            MainPage = new NavigationPage(new View.AlunoView() { BindingContext = App.AlunoVM });
        }

        private void InitializarVMs()
        {
            if (AlunoVM == null) AlunoVM = new AlunoViewModel();
        }
    }
}
