using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PWR_VI_PodPro.Core
{
    class PropertyChange: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
