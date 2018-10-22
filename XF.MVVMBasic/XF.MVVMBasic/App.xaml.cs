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
        public App()
        {
            ObservableCollection<Aluno> alunos = new ObservableCollection<Aluno>();

            InitializeComponent();
            MainPage = new
           NavigationPage(new View.MainPage(alunos));
        }        
    }
}
