using System;

namespace Orange.BizPack.Net
{
    public class BizPackConfiguration
    {
        public BizPackConfiguration()
        {
            Sender = string.Empty;
            ScheduleDate = DateTime.UtcNow;
            Validity = 0;
            CallbackUrl = string.Empty;
        }
        /// <summary>
        /// Acest parametru este obligatoriu. 
        /// Numele de utilizator folosit pentru autentificarea in bizpack.ro
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Acest parametru este optional. 
        /// Parola folosita pentru autentificarea in bizpack.ro
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Acest parametru este optional. 
        /// Se va folosi cheia oferita de catre serviciul operational bizpack.ro
        /// </summary>
        public string AuthKey { get; set; }
        /// <summary>
        /// Expeditorul mesajului. 
        /// Acest parametru este optional. 
        /// Lungimea expeditorului nu poate depasi 11 caractere.
        /// Setarea unui expeditor nu garanteaza folosirea lui la trasmiterea unui mesaj.
        /// Expeditorul trebuie sa fie in lista accepata si configurata de catre un reprezentant Orange/bizpack.ro.
        /// De asemena nu se pot folosi expeditori alfanumerici pentru toti operatorii.
        /// In cazul in care acest parametru nu este transmis sau este transmis gresit se va folosi expeditorul implicit. 
        /// Expeditoul implicit este nr.scurt al conexiunii folosite pentru trimiterea SMS-ului
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Data si ora la care doriti sa fie trimis mesajul. 
        /// Acest parametru este optional.
        /// Formatul corect este formatul XML pentru campuri de tip data si ora
        /// YYYY-MM-DDTHH:MM:SS.mmmZ.
        /// Este acceptat si formatul YYYY-MM-DD HH:MM:SS.
        /// In cazul in care acest parametru nu este transmis sau este transmis intr-un format gresit este folosita data si ora curenta de pe server-ul bizpack.ro
        /// </summary>
        public DateTime ScheduleDate { get; set; }
        /// <summary>
        /// Default: 0
        /// </summary>
        public int Validity { get; set; }
        /// <summary>
        /// Acest parametru este optional. 
        /// Reprezinta URL-ul la care se doreste transmiterea rapoartelor de livrare a SMS-ului in cazul in care acesta este programat cu success.
        /// URL-ul definit de catre dumneavaostra trebuie sa fie public si vizibil din exterior 
        /// * pentru fiecare linie din URL(SMS request) trebuie asociat intern, de catre dumneavoastra, un identificator unic(ex: messageID-ul returnat de catre noi) pentru diferentierea SMS-urilor
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
