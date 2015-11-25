using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SendGrid;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF GetCount Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private const int Port = 7000;
        private static UdpClient _client;
        private static IPEndPoint _ipAddress;
        private static int _lastTemp;
        private static Thread _t;
        private static Task _ta;

        public Service1()
        {
            if (_client == null)
            {
                _client = new UdpClient(Port) {EnableBroadcast = true};
            }
            if (_ipAddress == null)
            {
                _ipAddress = new IPEndPoint(IPAddress.Any, Port);
            }

            if (_ta == null)
            {
                _ta = Task.Run((() => TempLoop()));
            }
        }

        public int GetEntries()
        {
            using (DataContext dataContext = new DataContext())
            {
                return dataContext.Bevaegelser.Count();
            }
        }

        public Bevaegelser SletHistorik(int id)
        {
            using (DataContext dataContext = new DataContext())
            {
                Bevaegelser b = dataContext.Bevaegelser.FirstOrDefault(bevaegelse => bevaegelse.Id == id);
                if (b != null)
                {
                    dataContext.Bevaegelser.Remove(b);
                    dataContext.SaveChanges();
                    return b;
                }
                return null;
            }
        }


        public Brugere OpretBruger(string brugernavn, string password, string email)
        {
            bool indeholderIkkeBrugernavn = false;
            bool indeholderSnabelA = false;

            using (DataContext dataContext = new DataContext())
            {
                Brugere exBruger = FindBruger(brugernavn);

                #region Betingelser

                if (!password.Contains(brugernavn))
                {
                    indeholderIkkeBrugernavn = true;
                }
                if (email.Contains("@"))
                {
                    indeholderSnabelA = true;
                }

                #endregion

                if (exBruger == null && PasswordTjekker(password) && indeholderIkkeBrugernavn && indeholderSnabelA)
                {
                    Brugere b = new Brugere() {Brugernavn = brugernavn, Password = password, Email = email};
                    dataContext.Brugere.Add(b);
                    dataContext.SaveChanges();
                    return b;
                }
                return null;
            }
        }

        public Brugere OpdaterPassword(string brugernavn, string password)
        {
            using (DataContext dataContext = new DataContext())
            {
                Brugere b = FindBruger(brugernavn);
                if (b != null && PasswordTjekker(password) && !password.Contains(b.Brugernavn))
                {
                    b.Password = password;
                    dataContext.Brugere.AddOrUpdate(b);
                    dataContext.SaveChanges();
                    return b;
                }
                return null;
            }
        }

        public Brugere OpdaterEmail(string brugernavn, string email)
        {
            using (DataContext dataContext = new DataContext())
            {
                Brugere b = FindBruger(brugernavn);
                if (b != null && email.Contains("@"))
                {
                    b.Email = email;
                    dataContext.Brugere.AddOrUpdate(b);
                    dataContext.SaveChanges();
                    return b;
                }
                return null;
            }
        }

        public string Login(string brugernavn, string password)
        {
            throw new NotImplementedException();
        }

        public IList<Bevaegelser> HentData()
        {
            throw new NotImplementedException();
        }

        public IList<decimal> HentTemperatur()
        {
            throw new NotImplementedException();
        }

        public IList<DateTime> HentTidspunkt()
        {
            throw new NotImplementedException();
        }

        public string GlemtPassword(string brugernavn)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Genfinder brugernavn ud fra email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GlemtBrugernavn(string email)
        {
            Brugere b = FindBruger(null, 0, email);
            if (!email.Contains("@"))
            {
                return "Email er ikke gyldig (Skal indeholde @)";
            }
            if (b != null)
            {
                SendEmail(b.Email, "Brugernavn genfindelse", "Dit brugernavn er: ", b.Brugernavn);
                return "Brugernavn er sendt til " + email;
            }
            return "Email eksisterer ikke i databasen";
        }

        /// <summary>
        /// Sender email med de pågældende parametre
        /// </summary>
        /// <param name="modtager"></param> 
        /// <param name="emne"></param>
        /// <param name="besked"></param>
        /// <param name="uniktIndhold">Så som nyt password eller lign.</param>
        private void SendEmail(string modtager, string emne, string besked, string uniktIndhold)
        {
            // Emailoprettelse
            var email = new SendGridMessage();
            email.From = new MailAddress("P&P", "Protect and Prevent");
            email.AddTo(@"User <" + modtager + ">");
            email.Subject = emne;
            email.Text = besked + "\r\n" + uniktIndhold;

            // Emailforsendelse
            var username = "azure_263e6d64e115fae67eef2e8d59dd4bbd@azure.com";
            var pswd = "WB0uAl6moFYfCtc";
            var credentials = new NetworkCredential(username, pswd);
            var transportWeb = new Web(credentials);
            transportWeb.DeliverAsync(email);
        }

        private Brugere FindBruger(string brugernavn = null, int id = 0, string email = null)
        {
            using (DataContext dataContext = new DataContext())
            {
                if (email != null)
                {
                    Brugere b = dataContext.Brugere.FirstOrDefault(bruger => bruger.Email == email);
                    return b;
                }
                if (brugernavn != null)
                {
                    Brugere b = dataContext.Brugere.FirstOrDefault(bruger => bruger.Brugernavn == brugernavn);
                    return b;
                }
                Brugere br = dataContext.Brugere.FirstOrDefault(bruger => bruger.Id == id);
                return br;
            }
        }

        private bool PasswordTjekker(string password)
        {
            bool laengde = false;
            bool indeholderTal = false;
            bool indeholderStortBogstav = false;

            if (password.Length > 3 && password.Length < 21)
            {
                laengde = true;
            }
            if (password.Contains('1') || password.Contains("2") || password.Contains("3") ||
                password.Contains('4') || password.Contains("5") || password.Contains("6") ||
                password.Contains('7') || password.Contains("8") || password.Contains("9"))
            {
                indeholderTal = true;
            }
            if (password.Contains("A") || password.Contains("B") || password.Contains("C") ||
                password.Contains("D") || password.Contains("E") || password.Contains("F") ||
                password.Contains("G") || password.Contains("G") || password.Contains("I") ||
                password.Contains("J") || password.Contains("K") || password.Contains("L") ||
                password.Contains("M") || password.Contains("N") || password.Contains("O") ||
                password.Contains("P") || password.Contains("Q") || password.Contains("R") ||
                password.Contains("S") || password.Contains("T") || password.Contains("U") ||
                password.Contains("V") || password.Contains("W") || password.Contains("X") ||
                password.Contains("Y") || password.Contains("Z") || password.Contains("Æ") ||
                password.Contains("Ø") || password.Contains("Å"))
            {
                indeholderStortBogstav = true;
            }
            if (laengde && indeholderTal && indeholderStortBogstav)
            {
                return true;
            }
            return false;
        }

        private void TempLoop()
        {
            while (true)
            {
                //string testmessage = "RoomSensor Broadcasting\r\n" +
                //                     "Location: Teachers room\r\n" +
                //                     "Platform: Linux - 3.12.28 + -armv6l - with - debian - 7.6\r\n" +
                //                     "Machine: armv6l\r\n" +
                //                     "Potentiometer(8bit): 134\r\n" +
                //                     "Light Sensor(8bit): 159\r\n" +
                //                     "Temperature(8bit): 215\r\n" +
                //                     "Movement last detected: 2015 - 10 - 29 09:27:19.001053\r\n";
                byte[] bytes = _client.Receive(ref _ipAddress);
                Task.Run(() => DoIt(bytes, ref _lastTemp));
                //Thread.Sleep(1000);
            }
        }

        private static void DoIt(byte[] bytes, ref int lastTemp)
        {
            string resp = Encoding.ASCII.GetString(bytes);
            string cut = resp.Split('\r')[6];
            string cut2 = cut.Split(':')[1];
            string cut3 = cut2.Split(' ')[1];
            string cut4 = cut3[0].ToString() + cut3[1].ToString() + "," + cut3[2].ToString();
            int temp = int.Parse(cut3);
            //if (lastTemp != temp)
            //{
            using (DataContext dataContext = new DataContext())
            {
                DateTime tidspunkt = DateTime.Now;
                dataContext.Bevaegelser.Add(new Bevaegelser() {Temperatur = temp, Tidspunkt = tidspunkt});
                dataContext.SaveChanges();
            }
            lastTemp = temp;
            //}
        }
    }
}
