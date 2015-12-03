﻿using System.Collections.Generic;
using System.ServiceModel;
using WCFServiceWebRole1.Models;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Bevaegelser SletHistorik(int id);

        [OperationContract]
        string OpretBruger(string brugernavn, string password, string email);

        [OperationContract]
        string OpdaterPassword(string brugernavn, string password);

        [OperationContract]
        string OpdaterEmail(string brugernavn, string email);

        [OperationContract]
        string Login(string brugernavn, string password); //string -> Brugere så vi kan gemme email

        [OperationContract]
        List<Bevaegelser> HentBevaegelser();
            
        [OperationContract]
        int HentTemperatur(int startInterval, int slutInterval);

        [OperationContract]
        int HentTidspunkt(int aarstal, int maaned, int slutdag);

        [OperationContract]
        string GlemtPassword(string brugernavn);

        [OperationContract]
        string GlemtBrugernavn(string email);
    }
}