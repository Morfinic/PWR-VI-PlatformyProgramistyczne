using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PWR_VI_PodPro.Core
{
    class PropertyChange: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Funkcja służąca do aktualizacji wartości zmiennej
        /// </summary>
        /// <param name="name">Nazwa zmienianej wartości</param>
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
