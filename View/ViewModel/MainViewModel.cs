using PWR_VI_PodPro.Core;

namespace PWR_VI_PodPro.View.ViewModel
{
    class MainViewModel: PropertyChange
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand BrowserViewCommand { get; set; }
        public RelayCommand FilterViewCommand { get; set; }
        public RelayCommand FilterEditViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public BrowserViewModel BrowserVM { get; set; }
        public FilterViewModel FilterVM { get; set; }
        public FilterEditorViewModel FilterEditVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            BrowserVM = new BrowserViewModel();
            FilterVM = new FilterViewModel();
            FilterEditVM = new FilterEditorViewModel();
            SettingsVM = new SettingsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            BrowserViewCommand = new RelayCommand(o =>
            {
                CurrentView = BrowserVM;
            });
            
            FilterViewCommand = new RelayCommand(o =>
            {
                CurrentView = FilterVM;
            });

            FilterEditViewCommand = new RelayCommand(o =>
            {
                CurrentView = FilterEditVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });
        }
    }
}
