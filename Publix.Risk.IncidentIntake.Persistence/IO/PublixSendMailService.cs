using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Persistence.IO
{
    public class PublixSendMailService : IPublixSendMailService
    {
        private IAuthenticationProvider provider = null;


        public PublixSendMailService(IConfiguration config)//, IAuthenticationProvider authProvider)
        {
            //graphEndpoint = config.Graph_API_Endpoint;
            //            provider = authProvider;
        }


        /// <summary>
        ///  Prepares the messages , messageset Request , toRecipient \ ccRecipient \ bccRecipient \ from Address \ To Address
        ///  and calls the send email service to send email 
        /// </summary>
        /// <returns></returns>
        public async Task SendEmail(List<Message> emails)
        {
            foreach (Message msg in emails)
            {
                //check to see if the total number of recipeints is over 500, if so, send them in batches
                int total = msg.BccRecipients.Count() + msg.CcRecipients.Count() + msg.ToRecipients.Count();

                if (total > 500)
                {
                    if (msg.ToRecipients.Count() > 500)
                    {
                        // split these up
                        List<Recipient> allTos = msg.ToRecipients.ToList();

                        foreach (var batch in allTos.ToBatch(500))
                        {
                            Message subMsg = new Message()
                            {
                                ToRecipients = batch,
                                Subject = msg.Subject,
                                Attachments = msg.Attachments,
                                Body = msg.Body,
                                BodyPreview = msg.BodyPreview,
                                AdditionalData = msg.AdditionalData,
                                Categories = msg.Categories,
                                CreatedDateTime = msg.CreatedDateTime,
                                Flag = msg.Flag,
                                From = msg.From,
                                HasAttachments = msg.HasAttachments,
                                Importance = msg.Importance,
                                InternetMessageHeaders = msg.InternetMessageHeaders,
                                Sender = msg.Sender
                            };

                            await SendEmail(subMsg);
                        }
                    }
                    else
                    {
                        // send them as is
                        Message subMsg = new Message()
                        {
                            ToRecipients = msg.ToRecipients,
                            Subject = msg.Subject,
                            Attachments = msg.Attachments,
                            Body = msg.Body,
                            BodyPreview = msg.BodyPreview,
                            AdditionalData = msg.AdditionalData,
                            Categories = msg.Categories,
                            CreatedDateTime = msg.CreatedDateTime,
                            Flag = msg.Flag,
                            From = msg.From,
                            HasAttachments = msg.HasAttachments,
                            Importance = msg.Importance,
                            InternetMessageHeaders = msg.InternetMessageHeaders,
                            Sender = msg.Sender
                        };

                        await SendEmail(subMsg);
                    }
                    if (msg.CcRecipients.Count() > 500)
                    {
                        // split these up
                        List<Recipient> allCCs = msg.CcRecipients.ToList();

                        foreach (var batch in allCCs.ToBatch(500))
                        {
                            Message subMsg = new Message()
                            {
                                CcRecipients = batch,
                                Subject = msg.Subject,
                                Attachments = msg.Attachments,
                                Body = msg.Body,
                                BodyPreview = msg.BodyPreview,
                                AdditionalData = msg.AdditionalData,
                                Categories = msg.Categories,
                                CreatedDateTime = msg.CreatedDateTime,
                                Flag = msg.Flag,
                                From = msg.From,
                                HasAttachments = msg.HasAttachments,
                                Importance = msg.Importance,
                                InternetMessageHeaders = msg.InternetMessageHeaders,
                                Sender = msg.Sender
                            };

                            await SendEmail(subMsg);
                        }
                    }
                    else
                    {
                        // send them as is
                        Message subMsg = new Message()
                        {
                            CcRecipients = msg.CcRecipients,
                            Subject = msg.Subject,
                            Attachments = msg.Attachments,
                            Body = msg.Body,
                            BodyPreview = msg.BodyPreview,
                            AdditionalData = msg.AdditionalData,
                            Categories = msg.Categories,
                            CreatedDateTime = msg.CreatedDateTime,
                            Flag = msg.Flag,
                            From = msg.From,
                            HasAttachments = msg.HasAttachments,
                            Importance = msg.Importance,
                            InternetMessageHeaders = msg.InternetMessageHeaders,
                            Sender = msg.Sender
                        };

                        await SendEmail(subMsg);
                    }
                    if (msg.BccRecipients.Count() > 500)
                    {
                        //split these up
                        List<Recipient> allBCCs = msg.CcRecipients.ToList();

                        foreach (var batch in allBCCs.ToBatch(500))
                        {
                            Message subMsg = new Message()
                            {
                                BccRecipients = batch,
                                Subject = msg.Subject,
                                Attachments = msg.Attachments,
                                Body = msg.Body,
                                BodyPreview = msg.BodyPreview,
                                AdditionalData = msg.AdditionalData,
                                Categories = msg.Categories,
                                CreatedDateTime = msg.CreatedDateTime,
                                Flag = msg.Flag,
                                From = msg.From,
                                HasAttachments = msg.HasAttachments,
                                Importance = msg.Importance,
                                InternetMessageHeaders = msg.InternetMessageHeaders,
                                Sender = msg.Sender
                            };

                            await SendEmail(subMsg);
                        }
                    }
                    else
                    {
                        // send them as is
                        Message subMsg = new Message()
                        {
                            BccRecipients = msg.BccRecipients,
                            Subject = msg.Subject,
                            Attachments = msg.Attachments,
                            Body = msg.Body,
                            BodyPreview = msg.BodyPreview,
                            AdditionalData = msg.AdditionalData,
                            Categories = msg.Categories,
                            CreatedDateTime = msg.CreatedDateTime,
                            Flag = msg.Flag,
                            From = msg.From,
                            HasAttachments = msg.HasAttachments,
                            Importance = msg.Importance,
                            InternetMessageHeaders = msg.InternetMessageHeaders,
                            Sender = msg.Sender
                        };

                        await SendEmail(subMsg);
                    }
                }
                else
                {
                    // send them as is
                    await SendEmail(msg);
                }
            }
        }


        private async Task SendEmail(Message email)
        {
            var client = new GraphServiceClient(provider);

            await Task.Run(() => client.Me.SendMail(email, false));
        }
    }
}
