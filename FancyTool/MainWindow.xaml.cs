using System.Collections.Generic;
using System.Windows;
using BaseAutomationFramework.Tests.Encompass;


namespace EncompassAutomationTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FieldValues();
        }

        private void BtnKill_Click(object sender, RoutedEventArgs e)
        {
            //QuickAttachToProcess(Processes.Encompass);
            //TestedApplication.Kill();
        }
    }
}
