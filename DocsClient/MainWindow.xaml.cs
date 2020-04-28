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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DocsClient
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Connection Conn;
        private Thread listener;
        public MainWindow()
        {
            InitializeComponent();
            Conn = new Connection();
            Conn.OnDataReceived += (s, a) =>
            {
                ToReceive.Dispatcher.Invoke(() => { ToReceive.Text = ToReceive.Text + a; });
            };
            Conn.OnErrorReceived += (s, a) =>
            {
                MessageBox.Show(a, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            };
            
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (Conn.SocketConnected() == false)
            {
                Conn.addr = IPField.Text;
                Conn.port = PortField.Text;
                if (Conn.Start()!=0) return;
                listener = new Thread(new ThreadStart(Conn.Listen));
                listener.Start();
            }
        }

        private void PortField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToSend_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Conn.SocketConnected())
            {
                Conn.Send(ToSend.Text);
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Conn.StopListening = true;
            if (listener != null) listener.Join();
            Conn.Stop();
        }

        private void IPField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}