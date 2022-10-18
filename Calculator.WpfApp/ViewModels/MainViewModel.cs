
using Calculator.WpfApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace Calculator.WpfApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _screenVal;
        private List<string> _availableOperations = new List<string> { "+", "-", "/", "*" };

        private DataTable _dataTable = new DataTable();
        private bool _isLastSigneAnOperation;


        public MainViewModel()
        {
            //ScreenVal = "0";
            AddNumberCommand = new RelayCommand(AddNumber); 
            AddOperationCommand = new RelayCommand (AddOperation, CanAddOperation);
            ClearScreenCommand = new RelayCommand(ClearScreen);
            ResultCommand = new RelayCommand(Result, CanAddResult);
        }




        private bool CanAddResult(object obj)
        {
            return !_isLastSigneAnOperation;
        }

        private bool CanAddOperation(object obj)
        {
            return !_isLastSigneAnOperation;
        }

        public RelayCommand ResultCommand { get; }

        private void Result(object obj)
        {
           var result = _dataTable.Compute(ScreenVal.Replace(",","."), "");
            ScreenVal = result.ToString();
        }

        public RelayCommand ClearScreenCommand { get; }

        private void ClearScreen(object obj)
        {
            ScreenVal = "0";
            _isLastSigneAnOperation = false;
        }

        public ICommand AddOperationCommand { get; set; }

        private void AddOperation(object obj)
        {
            var operation = obj as string;
            ScreenVal += operation;

            _isLastSigneAnOperation = true;

        }


        public ICommand AddNumberCommand { get; set; }

        private void AddNumber(object obj)
        {
            var number = obj as string;

            if (ScreenVal == "0" && number != "," )
                ScreenVal = string.Empty;
            else if (number == "," && _availableOperations.Contains(ScreenVal.Substring (ScreenVal.Length - 1)))
                number = "0,";

            ScreenVal += number;

            _isLastSigneAnOperation = false;
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
