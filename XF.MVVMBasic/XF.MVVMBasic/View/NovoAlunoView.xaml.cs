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
	public partial class NovoAlunoView : ContentPage
	{
        public ObservableCollection<Aluno> Alunos { get; set; }
        public NovoAlunoView (ObservableCollection<Aluno> alunos)
		{
            Alunos = alunos;
            InitializeComponent();
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno() { Id = Guid.NewGuid(), Nome = txtNomeAluno.Text, Email = txtEmailAluno.Text, RM = txtRMAluno.Text };
             
            Alunos.Add(aluno);

            String msg = "O aluno " + txtNomeAluno.Text + " foi salvo com sucesso!";
            Clear();


            DisplayAlert("Salvar Aluno", msg, "Ok");
            
        }

        public void Clear()
        {
            txtNomeAluno.Text = "";
            txtEmailAluno.Text = "";
            txtRMAluno.Text = "";
        }
    }
}