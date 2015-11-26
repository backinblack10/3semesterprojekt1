using System.Linq;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace WCFServiceWebRole1.Models
{
    

    [Table("Brugere")]
    [DataContract]
    public partial class Brugere
    {
        private string _password;
        private string _email;
        private string _brugernavn;
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Brugernavn
        {
            get { return _brugernavn; }
            set { _brugernavn = value; }
        }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Password
        {
            get { return _password; }
            set
            {
                CheckPassword(value);
                _password = value;
            }
        }
        private void CheckPassword(string password)
        {
            if (password == null || password.Length < 4 || password.Length > 20 || !password.Any(char.IsUpper) || !password.Any(char.IsDigit) || password.Contains(Brugernavn))
            {
                //throw new ArgumentException("Password er forkert" + " (" + password + ")");
                throw new ArgumentException();
            }
        }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Email
        {
            get { return _email; }
            set
            {
                CheckEmail(value);
                _email = value;
            }
        }

        private void CheckEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Email er forkert" + " (" + email + ")");
            }
        }

        public Brugere(string brugernavn, string password, string email)
        {
            _brugernavn = brugernavn;
            _password = password;
            _email = email;

        }

        public Brugere()
        {
            
        }
    }
}
