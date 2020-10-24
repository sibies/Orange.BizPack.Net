using System;
using System.Collections.Generic;
using System.Text;

namespace Orange.BizPack.Net.Responses
{
    public enum BizPackSendSmsAuthKeyResponseStatus
    {
        /// <summary>
        /// Internal bizpack error
        /// </summary>
        InternalBizPackError = 536870913,
        /// <summary>
        /// No available account for the calling IP
        /// </summary>
        NoAvailableAccountForTheCallingIp = 268435457,
        /// <summary>
        /// Associated account is disabled
        /// </summary>
        AssociatedAccountIsDisabled = 268435463,
        /// <summary>
        /// Associated account is missconfigured
        /// </summary>
        AssociatedAccountIsMissconfigured = 268435462,
        /// <summary>
        /// Internal bizpack error while creating SMS Sender
        /// </summary>
        InternalBizpackErrorWhileCreatingSmsSender = 268435464,
        /// <summary>
        /// Parameter `phone` has a wrong format or it belongs to a GSM.Network that is not configured for the associated account!
        /// </summary>
        WrongPhone = 268435458,
        /// <summary>
        /// Phone number is black listed
        /// </summary>
        PhoneNumberIsBlackListed = 268435466,
        /// <summary>
        /// Phone number belongs to a GSM Network that is not configured for the associated account
        /// </summary>
        PhoneNumberNotConfigured = 268435520,
        /// <summary>
        /// You’ve exceeded your monthly limit for SMS sending
        /// </summary>
        SmsLimitExceeded = 268435460,
        /// <summary>
        /// You are trying to schedule a SMSmessage outside the configured time interval restrictions
        /// </summary>
        SchedulerOutsideIntervalError = 268435488,
        /// <summary>
        /// Parameter message is empty.
        /// Empty message are not allowed
        /// </summary>
        EmptyMessageError = 268435459,
        /// <summary>
        /// Internal error while scheduling a SMS
        /// </summary>
        SchedulerInternalError = 268435465
    }
}
