
using Calculator.WpfApp.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace Calculator.WpfApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _screenVal;


        public MainViewModel()
        {
            //ScreenVal = "0";
            AddNumberCommand = new RelayCommand(AddNumber); 
            AddOperationCommand = new RelayCommand (AddOperation);
            ClearScreenCommand = new RelayCommand(ClearScreen);
            ResultCommand = new RelayCommand(Result);
        }

        public RelayCommand ResultCommand { get; }

        private void Result(object obj)
        {
            MessageBox.Show("=");
        }

        public RelayCommand ClearScreenCommand { get; }

        private void ClearScreen(object obj)
        {
            MessageBox.Show("clear screen");
        }

        public ICommand AddOperationCommand { get; set; }

        private void AddOperation(object obj)
        {
            MessageBox.Show(obj as string);
        }


        public ICommand AddNumberCommand { get; set; }

        private void AddNumber(object obj)
        {
            MessageBox.Show(obj as string);
        }


        public string ScreenVal
        {
            get { return _screenVal ; }
            set { _screenVal = value; NotifyPropertyChanged(); }
        }
















        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  

        //}
    }
}
