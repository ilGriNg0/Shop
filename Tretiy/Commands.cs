using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tretiy
{
    public class Commands : ICommands
    {
        public void OpenHistoryView() => MainWindowViewModel.Instance.CurrentView = new HistoryViewModel();
       

        public void OpenTodayView() => MainWindowViewModel.Instance.CurrentView = new TodayViewModel();

    }
}
