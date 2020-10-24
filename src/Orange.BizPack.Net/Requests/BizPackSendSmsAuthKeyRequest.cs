namespace Orange.BizPack.Net.Requests
{
    public class BizPackSendSmsAuthKeyRequest
    {
        /// <summary>
        /// Acest parametru este obligatoriu. 
        /// Numele de utilizator folosit pentru autentificarea in bizpack.ro
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Acest parametru este obligatoriu. 
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
        /// Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        /// Acest parametru este obligatoriu.
        /// Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        /// Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Mesajul ce se doreste a fi trimis prin SMS. 
        /// Acest parametru este obligatoriu.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data si ora la care doriti sa fie trimis mesajul. 
        /// Acest parametru este optional.
        /// Formatul corect este formatul XML pentru campuri de tip data si ora
        /// YYYY-MM-DDTHH:MM:SS.mmmZ.
        /// Este acceptat si formatul YYYY-MM-DD HH:MM:SS.
        /// In cazul in care acest parametru nu este transmis sau este transmis intr-un format gresit este folosita data si ora curenta de pe server-ul bizpack.ro
        /// </summary>
        public string ScheduleDate { get; set; }
        /// <summary>
        /// Valabilitatea mesajului exprimata in minute. 
        /// Acest parametru este optional. 
        /// In cazul in care acest parametru este transmis si diferit de zero reprezinta cate minute de la data si ora pentru care a fost programat mesajul acesta este valabil.
        /// Daca mesajul nu poate fi transmis in intervalul de valabilitate specificat acesta nu va mai fi transmis si nu va mai contorizat in contul dvs.
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
