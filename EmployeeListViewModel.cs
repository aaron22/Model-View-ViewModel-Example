using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Model_View_ViewModel_Example
{
	class EmployeeListViewModel : ViewModelBase
	{
		public EmployeeListViewModel()
		{
			List<EmployeeViewModel> employees = new List<EmployeeViewModel>{
				new EmployeeViewModel{FirstName="Aaron", LastName="Gray"},
				new EmployeeViewModel{FirstName="Peanut", LastName="Butter"},
				new EmployeeViewModel{FirstName="Some", LastName="Guy"}
			};

			this.Employees = new ObservableCollection<EmployeeViewModel>(employees);

			this.CreateCommands();
		}

		public ObservableCollection<EmployeeViewModel> Employees
		{
			get;
			private set;
		}

		public int SelectedIndex
		{
			get;
			set;
		}

		#region Commands

		private void CreateCommands()
		{
			this.MoveUpCommand = new RelayCommand(param => this.MoveUp(), param => this.MoveUpCanExecute);
			this.MoveDownCommand = new RelayCommand(param => this.MoveDown(), param => this.MoveDownCanExecute);
		}

		public RelayCommand MoveUpCommand
		{
			get;
			private set;
		}

		public RelayCommand MoveDownCommand
		{
			get;
			private set;
		}

		private bool MoveUpCanExecute
		{
			get { return this.SelectedIndex > 0; }
		}

		private bool MoveDownCanExecute
		{
			get { return this.SelectedIndex < this.Employees.Count - 1; }
		}

		private void MoveUp()
		{
			this.Employees.Move(this.SelectedIndex, this.SelectedIndex - 1);
		}

		private void MoveDown()
		{
			this.Employees.Move(this.SelectedIndex, this.SelectedIndex + 1);
		}

		#endregion Commands
	}
}
