using System;
using System.Collections.Generic;
using System.Text;

namespace Orange.BizPack.Net.Responses
{
    public enum BizPackCheckMessageResponseStatus
    {
        /// <summary>
        /// mesajul nu a fost inca prelucrat in vederea trimiterii SMS-ului catre operator.
        /// </summary>
        Nou = 0,
        /// <summary>
        /// mesajul a fot trimis de platforma bizpack.ro si preluat de catre operatorul GSM. 
        /// Operatorul nu a confirmat inca daca respectivul SMS a fost livrat catre client.
        /// </summary>
        LivratLaOperator = 1,
        /// <summary>
        /// SMS-ul a fost livrat cu succes catre client
        /// </summary>
        LivratLaClient = 2,
        /// <summary>
        /// (ex: destinatarul are telefonul inchis). Se va reincerca trasmiterea lui catre destinatar. 
        /// In cazul in care a fost specificata o valabilitate la programarea mesajului nu se va mai incerca transmiterea lui dupa expirarea acesteia. 
        /// Daca nu se va specifica o valabilitate transmiterea lui se va incerca in functie de algoritumul de retry al operatorului / destinataului.
        /// </summary>
        EroareTemporara = 3,
        /// <summary>
        /// mesajul a fost respins de catre operator. 
        /// Numarul introdus este incorect (nu a fost configurat de catre operatori), sau pur si simplu, nu mai exista (a fost dezactivat).
        /// - in cazul in care acel numar aflat candva in status respins, urmeaza sa fie reactivat, este foarte posibil sa fie vorba de alt client. 
        /// (perioada dupa care un numar inactiv se poate reactiva si intra din nou in circuitul comerical depinde de politica fiecarui operator)
        /// </summary>
        Respins = 4,
        /// <summary>
        /// mesajul nu a fost livrat in termenul maxim de reincercari specific fiecarui operator (maxim un interval de 4 zile calendaristice), cel mai probabil clientul se afla in afara retelei, are telefonul inchis sau numarul respectiv nu mai este activ (a fost dezactivat recent).
        /// pentru SMS-urile aflate in status-ul "eroare permanenta" exista posibilatea ca numarul sa nu fie activ, in sensul ca se poate in perioada de "suspedare abonament / cartela pre-paid". 
        /// Aceasta perioada este de maxim 30 - 60 de zile, timp in care utilizatorul isi poate reactiva numarul de telefon.
        /// </summary>
        EroarePermanenta = 5,
        /// <summary>
        /// Asemanator cu <see cref="BizPackCheckMessageResponseStatus.EroarePermanenta2"/>
        /// </summary>
        EroarePermanenta2 = 6,
        /// <summary>
        /// Status-ul de livrare - Verificare portabilitate actioneaza mai mult ca un flag, flow-ul fiind urmatorul:
        ///     - se trimite un mesaj catre bizpack.ro.
        ///     - bizpack.ro receptioneaza mesajul si livreaza catre operator mesajul.
        ///     - mesajul nu este livrat pentru ca numarul este portat. In acest caz mesajul primeste status 14.
        ///     - bizpack.ro va updata reteaua de care apartine numarul de telefon si va retrimite mesajul.
        ///     Mesajul respectiv nu este taxat pentru incercare si in schimb este retrimis automat catre operatorul de telefonie mobila curent, identificat, in urma portabilitatii, cand se va realiza taxarea.
        ///     Astfel, in raportul detaliat pentru un numar la care aveti status-ul "Verificare portabilitate" (netaxabil) se va regasi inca un mesaj avand stats-ul de livrare final (taxabil).
        /// </summary>
        VerificaPortabilitate = 14,
        /// <summary>
        /// sau conexiunea pentru numarul pentru care se incearca trimiterea nu a fost configurat la nivelul contului bizpack.ro
        /// </summary>
        NumarIncorect = 16
    }
}
