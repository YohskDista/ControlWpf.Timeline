using ControlWpf.Timeline;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimelineControl.Sample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ITimelineBlock> _blocks;

        public ObservableCollection<ITimelineBlock> Blocks
        {
            get => _blocks;
            set
            {
                if (_blocks == value)
                    return;

                _blocks = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Blocks = new ObservableCollection<ITimelineBlock>
            {
                new TimelineBlock("Test 1", 1, new DateTime(2018, 7, 1, 0, 0, 0), new DateTime(2018, 7, 1, 1, 0, 0)),
                new TimelineBlock("Test 2", 2, new DateTime(2018, 7, 1, 1, 0, 0), new DateTime(2018, 7, 1, 5, 0, 0)),
                new TimelineBlock("Test 3", 3, new DateTime(2018, 7, 1, 5, 0, 0), new DateTime(2018, 7, 1, 13, 0, 0))
            };
        }
        
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
