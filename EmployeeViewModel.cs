using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Model_View_ViewModel_Example
{
	/// <summary>
	/// A UI-friendly representation of an employee
	/// </summary>
	class EmployeeViewModel : ViewModelBase, IDataErrorInfo
	{
		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		#region IDataErrorInfo members

		public string Error
		{
			get { return null; }
		}

		public string this[string propertyName]
		{
			get
			{
				if (propertyName == "FirstName")
				{
					return string.IsNullOrWhiteSpace(this.FirstName) ? "The first name must not be empty" : null;
				}
				else if (propertyName == "LastName")
				{
					return string.IsNullOrWhiteSpace(this.LastName) ? "The last name must not be empty" : null;
				}
				return null;
			}
		}

		#endregion IDataErrorInfo members
	}
}
