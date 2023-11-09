using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicSotre_Client.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        TcpClient tcpClient;
        Socket socketLogin;
        NetworkStream networkStream;
        StreamReader streamReader;
        StreamWriter streamWriter;

        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ConnectToServer();
            CloseConnect();
        }

        // Lắng nghe phẩn hồi từ server
        public void ListenServer()
        {

        }

        public void ConnectToServer()
        {
            var ip = "127.0.0.1";
            var ipAddress = IPAddress.Parse(ip);
            int port = 12345;
            var ipEndpoint = new IPEndPoint(ipAddress, port);

            // Chuyển đổi SecureString thành chuỗi (string)
            SecureString securePassword = txtPassword.SecurePassword;            
            string password = new NetworkCredential(string.Empty, securePassword).Password;
            string user = txtEmail.Text + "*" + password;

            socketLogin = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socketLogin.Connect(ipEndpoint);
            networkStream = new NetworkStream(socketLogin);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);

            streamWriter.WriteLine(user);
            streamWriter.Flush();

            string? respose = streamReader.ReadLine();
            if (respose != null)
            {
                if (respose.Equals("success"))
                {
                    // Thành công thì chuyển sang form List Album
                    MessageBox.Show(respose);
                }
                else
                {
                    // Show message when wrong username or password
                    MessageBox.Show(respose);
                }
            }            
            return;
        }

        public void CloseConnect()
        {
            socketLogin.Close();
            streamReader.Close();
            streamWriter.Close();            
            networkStream.Close();
        }
    }
}
