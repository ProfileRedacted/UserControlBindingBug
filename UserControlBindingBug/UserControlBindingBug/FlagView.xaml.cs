using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public partial class FlagView : UserControl, INotifyPropertyChanged {

        public static readonly DependencyProperty FlagStringProperty = DependencyProperty.Register(
            name: "FlagString",
            propertyType: typeof(string),
            ownerType: typeof(FlagView),
            typeMetadata: new PropertyMetadata(
                defaultValue: string.Empty,
                propertyChangedCallback: OnFlagStringChanged
            )
        );

        public string FlagString {
            set => SetValue(FlagStringProperty, value);
            get => (string) GetValue(FlagStringProperty);
        }

        public FlagView() {
            InitializeComponent();
            DataContext = this;
        }

        private static void OnFlagStringChanged(DependencyObject source, DependencyPropertyChangedEventArgs e) =>
            ((FlagView)source).NotifyPropertyChanged(e.Property.Name);

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

    }

}
