﻿using System;
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
	public partial class AlunoView : ContentPage
	{       

        public ObservableCollection<Aluno> Alunos { get; set; }
        public AlunoView(ObservableCollection<Aluno> alunos)
        {           
            Alunos = alunos;
            BindingContext = Alunos;
            InitializeComponent();

        }

    }
}