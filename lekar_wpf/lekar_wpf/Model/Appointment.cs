using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class Appointment : INotifyPropertyChanged
    {
		protected void OnPropertyChanged(string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private Doctor doctor;

		public Doctor Doctor
		{
			get { return  doctor; }
			set {  doctor = value; }
		}

		private Patient patient;

		public  Patient Patient
		{
			get { return patient; }
			set { patient = value; }
		}

		private string room;

		public string Room
		{
			get { return room; }
			set { room = value; }
		}

		private DateTime startPoint;

		public  DateTime StartPoint
		{
			get { return startPoint; }
			set { startPoint = value; }
		}

		private DateTime endPoint;

		public DateTime EndPoint
		{
			get { return endPoint; }
			set { endPoint = value; }
		}

		private string type;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private string inter;
		public string Inter
		{ 
			get { return inter; }
			set { inter = value; }
		}


	}
}
