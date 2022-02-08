using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Занятие19WpfApp1.Models;

namespace Занятие19WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }

        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand DlinaOkrCommand { get; }
        private void OnDlinaOkrExecute (object p)
        {
           Number2 = Ariph.DlinaOkr(Number1);
        }

        private bool CanDlinaOkrExecuted(object p)
        {
            if (Number1 != 0 && Number1 > 0)
                return true;
            else
                return
                    false;
        }

        public MainWindowViewModel()
        {
            DlinaOkrCommand = new RelayCommand(OnDlinaOkrExecute, CanDlinaOkrExecuted);
        }
    }

}
