using ShellExperience.Helper.Collections;
using System.Windows;

namespace ShellExperience.Model
{
    public class AppSetting
    {
        public ObservableRangeCollection<ExecutableApplication> ListApplications = new ObservableRangeCollection<ExecutableApplication>();
        public Size SizeWindow = new Size();
    }
}
