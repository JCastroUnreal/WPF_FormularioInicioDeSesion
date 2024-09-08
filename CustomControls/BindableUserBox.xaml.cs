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

namespace WPF_FormularioInicioDeSesion.CustomControls
{
    /// <summary>
    /// Lógica de interacción para BindableUserBox.xaml
    /// </summary>
    public partial class BindableUserBox : UserControl
    {
        public BindableUserBox()
        {
            InitializeComponent();
        }

        public string Text { get; set; }
    }
}
