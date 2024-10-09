﻿namespace BookStore.EmailSending.EmailBackgroundService;

internal interface ISendEmail
{
  Task SendEmailAsync(string to, string from, string subject, string body);
}


