using Fanorona91G.Models;
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

namespace Fanorona91G
{
    /// <summary>
    /// Interaction logic for MainWindow.x
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Nodo nodo = new Nodo();
            nodo.ChildrenGenerate(1, 3);
            InitializeComponent();
        }
    }
}
