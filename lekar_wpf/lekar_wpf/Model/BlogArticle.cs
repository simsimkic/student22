using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class BlogArticle : INotifyPropertyChanged
    {
		private string heading;

		public  string Heading
		{
			get { return heading; }
			set { heading = value; }
		}
		private string text;

		public string Text
		{
			get { return text; }
			set { text = value; }
		}
		private string category;

		public string Category
		{
			get { return category; }
			set { category = value; }
		}
		private string date;

		public  string Date
		{
			get { return date; }
			set { date = value; }
		}
		private string author;

		public event PropertyChangedEventHandler PropertyChanged;

		public  string Author
		{
			get { return author; }
			set { author = value; }
		}

		protected void OnPropertyChanged(string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
