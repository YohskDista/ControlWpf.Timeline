using System;
using System.Collections.Generic;
using System.Text;

namespace ControlWpf.Timeline
{
    public interface ITimelineBlock
    {
        string Title { get; set; }

        object Value { get; set; }

        DateTime Start { get; set; }

        DateTime Stop { get; set; }
    }
}
