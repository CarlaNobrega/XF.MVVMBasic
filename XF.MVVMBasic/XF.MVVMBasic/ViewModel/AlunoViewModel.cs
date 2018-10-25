using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades

        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();
        public Aluno AlunoModel { get; set; }
        public OnSalvar OnSalvarCMD { get; private set; }

        public OnDeletar OnDeletarCMD { get; private set; }

        public ICommand OnNovoCMD { get; set; }

        #endregion

        public AlunoViewModel()
        {
            OnNovoCMD = new Command(OnNovo);
            OnSalvarCMD = new OnSalvar(this);
            OnDeletarCMD = new OnDeletar(this);
        }

        private void OnNovo(object obj)
        {
            App.AlunoVM.AlunoModel = new Aluno();
            App.Current.MainPage.Navigation.PushAsync(new View.NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        public void Adicionar(Aluno paramAluno)
        {
            try
            {
                if (paramAluno == null)
                    throw new Exception("Null");

                Alunos.Add(paramAluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Ocorreu um erro inesperado", "Ok");
            }
        }

        public void Deletar(Aluno paramAluno)
        {
            try
            {
                if (paramAluno == null)
                    throw new Exception("Null");

                Alunos.Remove(paramAluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Ocorreu um erro inesperado", "Ok");
            }
        }
    }

    public class OnSalvar : ICommand
    {
        AlunoViewModel alunoVM;
        public OnSalvar(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;               
        }

        public event EventHandler CanExecuteChanged;

        public void IsHabilitado() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => (parameter != null) && !string.IsNullOrWhiteSpace(((Aluno)parameter).Nome);

        public void Execute(object parameter)
        {
            alunoVM.Adicionar(parameter as Aluno);
        }
    }

    public class OnDeletar : ICommand
    {
        AlunoViewModel alunoVM;
        public OnDeletar(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            alunoVM.Deletar(parameter as Aluno);
        }
    }

}
