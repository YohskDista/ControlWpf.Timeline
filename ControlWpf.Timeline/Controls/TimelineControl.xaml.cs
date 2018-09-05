using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlWpf.Timeline.Controls
{
    /// <summary>
    /// Interaction logic for TimelineControl.xaml
    /// </summary>
    public partial class TimelineControl : UserControl
    {
        public ObservableCollection<ITimelineBlock> Blocks
        {
            get => (ObservableCollection<ITimelineBlock>)GetValue(BlocksProperty);
            set => SetValue(BlocksProperty, value);
        }

        public ICommand ClickBlockCommand
        {
            get => (ICommand)GetValue(ClickBlockCommandProperty);
            set => SetValue(ClickBlockCommandProperty, value);
        }

        public DateTime DateStart
        {
            get => (DateTime)GetValue(DateStartProperty);
            set => SetValue(DateStartProperty, value);
        }

        public DateTime DateStop
        {
            get => (DateTime)GetValue(DateStopProperty);
            set => SetValue(DateStopProperty, value);
        }

        public Brush BorderBrushBlock
        {
            get => (Brush)GetValue(BorderBrushBlockProperty);
            set => SetValue(BorderBrushBlockProperty, value);
        }

        public static DependencyProperty BorderBrushBlockProperty =
            DependencyProperty.Register(nameof(BorderBrushBlock),
                typeof(Brush),
                typeof(TimelineControl),
                new PropertyMetadata(Brushes.Black));

        public static DependencyProperty DateStartProperty =
            DependencyProperty.Register(nameof(DateStart),
                typeof(DateTime),
                typeof(TimelineControl),
                new PropertyMetadata(null));

        public static DependencyProperty DateStopProperty =
            DependencyProperty.Register(nameof(DateStop),
                typeof(DateTime),
                typeof(TimelineControl),
                new PropertyMetadata(null));

        public static DependencyProperty ClickBlockCommandProperty =
            DependencyProperty.Register(nameof(ClickBlockCommand),
                typeof(ICommand),
                typeof(TimelineControl),
                new PropertyMetadata(null));

        public static DependencyProperty BlocksProperty =
            DependencyProperty.Register(nameof(Blocks),
                typeof(ObservableCollection<ITimelineBlock>),
                typeof(TimelineControl),
                new FrameworkPropertyMetadata(
                    new ObservableCollection<ITimelineBlock>()));

        public TimelineControl()
        {
            InitializeComponent();
        }
    }
}
