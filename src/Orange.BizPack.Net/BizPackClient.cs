using BizPackService;
using Orange.BizPack.Net.Responses;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Orange.BizPack.Net
{
    public class BizPackClient:IDisposable
    {
        private readonly string _sessionId;
        private readonly SMSServicePortClient _smsClient;
        private readonly BizPackConfiguration _configuration;

        /// <summary>
        /// Folosit pentru <see cref="Ping"/>
        /// </summary>
        static BizPackClient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="authKey"></param>
        public BizPackClient(string username, string authKey)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrEmpty(authKey))
                throw new ArgumentNullException(nameof(authKey));

            _configuration = new BizPackConfiguration
            {
                Username = username,
                AuthKey = authKey
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public BizPackClient(BizPackConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.Username))
                throw new ArgumentNullException(nameof(configuration.Username));

            _configuration = configuration;
            _smsClient = new SMSServicePortClient();
            _sessionId = _smsClient.openSession(_configuration.Username, _configuration.Password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Ping()
        {
            var smsClient = new SMSServicePortClient();
            var ip = smsClient.showIp();
            return !string.IsNullOrEmpty(ip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<string> IpAsync()
        {
            var smsClient = new SMSServicePortClient();
            var ip = await smsClient.showIpAsync();
            return ip.@return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Ip()
        {
            var smsClient = new SMSServicePortClient();
            var ip = smsClient.showIp();
            return ip;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public async Task<string> SendSmsAuthKeyAsync(
            string number, 
            string message
            )
        {
            if (string.IsNullOrEmpty(_configuration.AuthKey))
                throw new ArgumentNullException(nameof(_configuration.AuthKey));

            if (string.IsNullOrEmpty(_configuration.Username))
                throw new ArgumentNullException(nameof(_configuration.Username));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            using (var smsClient = new SMSServicePortClient())
            {
                try
                {
                    var response = await smsClient.sendSmsAuthKeyAsync(
                                      _configuration.Username,
                                      _configuration.AuthKey,
                                      _configuration.Sender,
                                      number,
                                      message,
                                      _configuration.ScheduleDate,
                                      _configuration.Validity,
                                      _configuration.CallbackUrl
                        );

                    return response.id;
                }
                catch (FaultException<object> ex)
                {

                    throw;
                }
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public string SendSmsAuthKey(
            string number, 
            string message
            )
        {
            if (string.IsNullOrEmpty(_configuration.AuthKey))
                throw new ArgumentNullException(nameof(_configuration.AuthKey));

            if (string.IsNullOrEmpty(_configuration.Username))
                throw new ArgumentNullException(nameof(_configuration.Username));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            using (var smsClient = new SMSServicePortClient())
            {
                var response = smsClient.sendSmsAuthKey(
                                _configuration.Username,
                                 _configuration.AuthKey,
                                _configuration.Sender,
                                number,
                                message,
                                _configuration.ScheduleDate,
                                _configuration.Validity,
                                _configuration.CallbackUrl
                               );
                return response;
            }
        }

        /// <summary>
        ///  Se foloseste la trimiterea SMS-urilor de tip bulk intr-o bucla de tip for sau foreach
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public async Task<string> SendSessionSmsAsync(
            string number,
            string message
            )
        {
            if (string.IsNullOrEmpty(_sessionId))
                throw new ArgumentNullException(nameof(_sessionId));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number)); 
            
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var response = await _smsClient.sendSessionAsync(
                                _sessionId,
                                number,
                                message,
                                _configuration.ScheduleDate,
                                _configuration.Sender,
                                _configuration.Validity
                );
            return response.id;
        }

        /// <summary>
        /// Se foloseste la trimiterea SMS-urilor de tip bulk intr-o bucla de tip for sau foreach
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public string SendSessionSms(
            string number,
            string message
            )
        {
            if (string.IsNullOrEmpty(_sessionId))
                throw new ArgumentNullException(nameof(_sessionId));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var response = _smsClient.sendSession(
                                _sessionId,
                                number,
                                message,
                                _configuration.ScheduleDate,
                                _configuration.Sender,
                                _configuration.Validity
                );
            return response;
        }

        /// <summary>
        ///  Se foloseste la trimiterea SMS-urilor de tip bulk intr-o bucla de tip for sau foreach
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public async Task<string> SendSessionSmsFlashAsync(
            string number,
            string message
            )
        {
            if (string.IsNullOrEmpty(_sessionId))
                throw new ArgumentNullException(nameof(_sessionId));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var response = await _smsClient.sendSessionSmsFlashAsync(
                                _sessionId,
                                number,
                                message,
                                _configuration.ScheduleDate,
                                _configuration.Sender,
                                _configuration.Validity
                );
            return response.@return;
        }

        /// <summary>
        /// Se foloseste la trimiterea SMS-urilor de tip bulk intr-o bucla de tip for sau foreach
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <returns></returns>
        public string SendSessionSmsFlash(
            string number,
            string message
            )
        {
            if (string.IsNullOrEmpty(_sessionId))
                throw new ArgumentNullException(nameof(_sessionId));

            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            var response = _smsClient.sendSessionSmsFlash(
                                _sessionId,
                                number,
                                message,
                                _configuration.ScheduleDate,
                                _configuration.Sender,
                                _configuration.Validity
                );
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">
        ///     Numarul de telefon mobil catre care se doreste trimiterea SMS-ului. 
        ///     Acest parametru este obligatoriu.
        ///     Formatul corect al numarului de telefon este 07PPXXXXXX, 407PPXXXXXX sau 7PPXXXXXX pentru numerele nationale.
        ///     Pentru cele internationale trebuie trimis numarul in format international fara sa fie prefixat cu + sau 00
        /// </param>
        /// <param name="message">
        ///     Mesajul ce se doreste a fi trimis prin SMS.
        /// </param>
        /// <param name="isUnicode">
        ///     Este mesaj cu diacritice
        /// </param>
        /// <returns></returns>
        public string SendSms(string number, string message, bool isUnicode = true)
        {
            var smsClient = new SMSServicePortClient();
            var response = smsClient.SendSms(
                 _configuration.Username,
                _configuration.Password,
                _configuration.Sender,
                number,
                message,
                isUnicode,
                _configuration.ScheduleDate,
                _configuration.CallbackUrl
                );
            return response;
        }

        /// <summary>
        /// Metoda este folosita pentru a urmari stadiul de livrare al unui SMS programat
        /// </summary>
        /// <param name="messageId"> 
        /// identificatorul unic al mesajului rezultat din apelul cu succes al uneia dintre metodele send sau sendWapPush
        /// </param>
        /// <returns></returns>
        public async Task<BizPackCheckMessageResponseStatus> CheckStatus(string messageId)
        {
            if (string.IsNullOrEmpty(messageId))
                throw new ArgumentNullException(nameof(messageId));

            using (var smsClient = new SMSServicePortClient())
            {
                var response = await smsClient.checkStatusAsync(messageId);
                if (int.TryParse(response.status, out var status))
                {
                    return (BizPackCheckMessageResponseStatus)status;
                }

                return BizPackCheckMessageResponseStatus.Respins;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _smsClient.closeSession(_sessionId);
            _smsClient.Close();
        }
    }
}
