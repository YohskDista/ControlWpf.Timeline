using ControlWpf.Timeline;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfExtension.Timeline.Converters
{
    public class TimelineBlockWithSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var blocks = (ObservableCollection<ITimelineBlock>)values[0];
            double width = (double)values[1];
            double height = (double)values[2];

            var blocksOrdered = blocks
                .OrderBy(block => block.Start);

            var startTimeline = blocksOrdered.FirstOrDefault().Start;
            var stopTimeline = blocksOrdered.LastOrDefault().Stop;

            var timeSeconds = (stopTimeline - startTimeline).TotalSeconds;

            var blockWithSize = blocksOrdered
                .Select(block =>
                {
                    var widthBlock = (int)((block.Stop - block.Start).TotalSeconds * (width / timeSeconds));
                    return new TimelineBlock(block, widthBlock, height);
                });

            return blockWithSize;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
