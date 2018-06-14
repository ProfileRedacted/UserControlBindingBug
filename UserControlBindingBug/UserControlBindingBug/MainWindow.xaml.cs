using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UserControlBindingBug {

    public partial class MainWindow : Window {

        public ObservableCollection<PacketModel> Packets { get; } = new ObservableCollection<PacketModel>(new List<PacketModel> {
            new PacketModel {
                Name = "test1",
                Flags = new [] {
                    "foo",
                    "bar"
                }
            },
            new PacketModel {
                Name = "test2",
                Flags = new [] {
                    "foobar"
                }
            }
        });

        public MainWindow() {
            InitializeComponent();
            DataContext = this;
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            if (e.Column.Header is string header && header == "Flags") {
                e.Column = new DataGridTemplateColumn {
                    Header = e.Column.Header,
                    CellTemplate = Application.Current.FindResource("FlagCellTemplate") as DataTemplate
                };
            }
        }
    }

}
