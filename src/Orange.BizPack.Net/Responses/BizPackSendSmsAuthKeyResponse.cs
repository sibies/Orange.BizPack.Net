using System;
using System.Collections.Generic;
using System.Text;

namespace Orange.BizPack.Net.Responses
{
    /// <summary>
    /// Daca metoda reuseste programarea unui mesaj cu succes va intoarce un string de minimum 32 si maximum 60 de caractere ce reprezinta identificatorul unic al mesajului in platforma bizpack.ro
    /// Daca metoda esueaza serviciul web va intoarce un SOAP Fault. Codurile de eroare si mesajele aferente sunt prezentate in tabelul de mai jos
    /// </summary>
    public class BizPackSendSmsAuthKeyResponse
    {
        public BizPackSendSmsAuthKeyResponseStatus Status { get; set; }
    }
}
