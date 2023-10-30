using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
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

namespace Obratnaya_svyaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string where;
        string type1;
        int price = 200;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            where = "По России";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            where = "За границу";
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string type = ComboBox1.SelectedItem.ToString();
            if (where == "За границу")
            {
                price += 600;
            }
            if(where == "По России")
            {
                price += 100;
            }
            
            if (type == "Письмо")
            {
                price += 100;
            }
            if (type == "Посылка")
            {
                price += 400;
            }
            
            textblock1.Text = "Итого: " + price;
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string name = textBox1.Text;
            string mail = textBox2.Text;
            string name1 = textBox3.Text;
            string mail1 = textBox4.Text;
            StreamWriter writer = new StreamWriter("C:\\PROG121\\Obratnaya svyaz\\MailData.txt", true);
            if(ComboBox1.SelectedIndex == 0)
            {
                 type1 = "Письмо";
            }
            if (ComboBox1.SelectedIndex == 1)
            {
                 type1 = "Посылка";
            }
            writer.WriteLine("Вам отправили письмо!");
            writer.WriteLine("ФИО Отправителя:"+" " + name);
            writer.WriteLine("Адрес Отправителя:" + " " + mail +"\n\n");
            writer.WriteLine("ФИО Получателя:" + " " + name1);
            writer.WriteLine("ФИО Получателя:" + " " + mail1);
            writer.WriteLine("Тип посылки: " + " " + type1);
            writer.WriteLine("Тип почты: " + " " + where);
            writer.WriteLine("итоговая стоимость: " + " " + price);
            writer.Close();
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(mail, name);
            // кому отправляем
            MailAddress to = new MailAddress(mail1);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);

            m.Subject = "Тест";
            // текст письма
            m.Attachments.Add(new Attachment("C:\\PROG121\\Obratnaya svyaz\\MailData.txt"));
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
           SmtpClient client =
           new SmtpClient("smtp.mail.ru", Convert.ToInt32(0x19)) // сервер,порт
            {
                Credentials = new NetworkCredential("npl1u1pc@mail.ru", "dWxZks4tnrEGDq3XWqQh"),
                EnableSsl = true // обязательно!
            };
            
            client.Send(m);


        }
    }
}
