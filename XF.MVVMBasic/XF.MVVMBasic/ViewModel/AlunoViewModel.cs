using System;
using System.Collections.Generic;
using System.Text;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades

        public List<Aluno> Alunos { get; set; }
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        #endregion
        
        public AlunoViewModel()
        {
             new AlunoViewModel();
        }
        public static AlunoViewModel GetAlunos()
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel();

            for (int i = 0; i < 10; i++)
            {
                var aluno = new Aluno()
                {
                    Id = Guid.NewGuid(),
                    RM = "542621",
                    Nome = "Anderson Silva",
                    Email = "anderson@ufc.com"
                };

                alunoViewModel.Alunos.Add(aluno);
            }

            return alunoViewModel;
        }
    }
}
