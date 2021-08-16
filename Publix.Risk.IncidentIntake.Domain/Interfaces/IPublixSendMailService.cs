using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IPublixSendMailService
    {

        /// <summary>
        ///  Prepares the messages , messageset Request , toRecipient \ ccRecipient \ bccRecipient \ from Address \ To Address
        ///  and calls the send email service to send email 
        /// </summary>
        /// <returns></returns>
        Task SendEmail(List<Message> emailDetails);
    }
}