using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{        
       public ObservableCollection<Aluno> Alunos { get; set; }

        public MainPage (ObservableCollection<Aluno> aluno)
		{
			InitializeComponent ();
            Alunos = aluno;
		}

        private void Cadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovoAlunoView(Alunos) { BindingContext = Alunos });
        }

        private void Visualizar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlunoView(Alunos) { BindingContext = Alunos });
        }
    }
}