using ShellExperience.Helper.Collections;
using System.Windows;

namespace ShellExperience.Model
{
    public struct AppSetting
    {
        public ObservableRangeCollection<ExecutableApplication>? ListApplications;
        public Size SizeWindow;
    }
}
