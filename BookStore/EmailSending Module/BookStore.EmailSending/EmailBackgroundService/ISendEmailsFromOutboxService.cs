namespace BookStore.EmailSending.EmailBackgroundService;

internal interface ISendEmailsFromOutboxService
{
  Task CheckForAndSendEmails();
}
