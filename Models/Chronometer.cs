using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Punch.Models
{
    public class Chronometer
    {
        public Visibility Started { get; set; } = Visibility.Collapsed;
        public Visibility Paused { get; set; } = Visibility.Visible;
        public Visibility Cancelled { get; set; } = Visibility.Collapsed;
        public TimeSpan Time { get; set; }
        public DateTime Start { get; set; }
    }
}
