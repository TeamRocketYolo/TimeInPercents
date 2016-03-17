using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace TimeOfDay
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private string _currentTime;
		private double _timeInPercent;

		public MainWindow()
		{
			InitializeComponent();
			DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.IsEnabled = true;
			timer.Tick += (s, e) => UpdateTime();
		}

		public string CurrentTime
		{
			get { return _currentTime; }
			set
			{
				_currentTime = value;
				OnPropertyChanged("CurrentTime");
			}
		}

		public double TimeInPercents
		{
			get { return _timeInPercent; }
			set
			{
				_timeInPercent = value;
				OnPropertyChanged("TimeInPercents");
			}
		}

		private void UpdateTime()
		{
			var time = DateTime.Now.TimeOfDay.TotalSeconds/86400;
			CurrentTime = time.ToString("p3");
			TimeInPercents = time * 100;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}
	}
}
