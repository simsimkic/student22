using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class Patient : INotifyPropertyChanged
    {
		private string recordNumber;

		public string RecordNumber
		{
			get { return recordNumber; }
			set { recordNumber = value; }
		}

		private string fullName;

		public  string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}

		private string jmbg;

		public string Jmbg 
		{
			get { return jmbg; }
			set { jmbg = value; }
		}

		private string birthDate;

		public string BirthDate
		{
			get { return birthDate; }
			set { birthDate = value; }
		}

		private string city;

		public  string City
		{
			get { return city; }
			set { city = value; }
		}

		private string address;

		public  string Address
		{
			get { return address; }
			set { address = value; }
		}

		private string phoneNumber;

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		private string cardNumber;

		public string CardNumber
		{
			get { return cardNumber; }
			set { cardNumber = value; }
		}

		private bool hospitalized;

		public bool Hospitalized
		{
			get { return hospitalized; }
			set { hospitalized = value; }
		}

		private string gender;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		private ObservableCollection<Report> reports;
		public ObservableCollection<Report> Reports
		{
			get { return reports; }
			set { reports = value; }
		}

		private DateTime endOfHospitalization;
		public DateTime EndOfHospitalization
		{
			get { return endOfHospitalization; }
			set { endOfHospitalization = value; }
		}
		protected void OnPropertyChanged(string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
