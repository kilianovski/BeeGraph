using System;
using System.Collections.Generic;
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
using BeeGraph.Data;

namespace BeeGraph.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var edgeRepository = IoC.IoC.Container.GetInstance<IEdgeRepository>();
            var nodeRepository = IoC.IoC.Container.GetInstance<INodeRepository>();

            DataContext = new RelationViewModel()
            {
                Nodes = nodeRepository.GetAll(),
                Edges = edgeRepository.GetAll()
            };
        }
    }
}
