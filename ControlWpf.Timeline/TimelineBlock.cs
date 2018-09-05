using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlWpf.Timeline
{
    public class TimelineBlock : ITimelineBlock, INotifyPropertyChanged
    {
        public string Title
        {
            get => _title;
            set
            {
                if (value == _title)
                    return;

                _title = value;
                RaisePropertyChanged();
            }
        }

        public object Value
        {
            get => _value;
            set
            {
                if (value.Equals(_value))
                    return;

                _value = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Start
        {
            get => _start;
            set
            {
                if (value == _start)
                    return;

                _start = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Stop
        {
            get => _stop;
            set
            {
                if (value == _stop)
                    return;

                _stop = value;
                RaisePropertyChanged();
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (value == _width)
                    return;

                _width = value;
                RaisePropertyChanged();
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value == _height)
                    return;

                _height = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        private object _value;
        private DateTime _start;
        private DateTime _stop;
        private double _height;
        private double _width;

        public TimelineBlock(
            string title,
            object value,
            DateTime start,
            DateTime stop)
            : this(title, value, start, stop, 0, 0)
        {

        }

        public TimelineBlock(ITimelineBlock timelineBlock)
            : this(timelineBlock.Title, timelineBlock.Value, timelineBlock.Start, timelineBlock.Stop, 0, 0)
        {

        }

        internal TimelineBlock(ITimelineBlock timelineBlock, double width, double height)
            : this(timelineBlock.Title, timelineBlock.Value, timelineBlock.Start, timelineBlock.Stop, width, height)
        {

        }

        internal TimelineBlock(
            string title, 
            object value, 
            DateTime start, 
            DateTime stop,
            double width,
            double height)
        {
            Title = title;
            Value = value;
            Start = start;
            Stop = stop;
            Width = width;
            Height = height;
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            return obj is TimelineBlock block &&
                   Title == block.Title &&
                   EqualityComparer<object>.Default.Equals(Value, block.Value) &&
                   Start == block.Start &&
                   Stop == block.Stop &&
                   _title == block._title &&
                   EqualityComparer<object>.Default.Equals(_value, block._value) &&
                   _start == block._start &&
                   _stop == block._stop;
        }

        public override int GetHashCode()
        {
            var hashCode = 1704000642;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + Stop.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_title);
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(_value);
            hashCode = hashCode * -1521134295 + _start.GetHashCode();
            hashCode = hashCode * -1521134295 + _stop.GetHashCode();
            return hashCode;
        }
    }
}
