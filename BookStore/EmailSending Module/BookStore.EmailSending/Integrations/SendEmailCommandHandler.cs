﻿using Ardalis.Result;
using BookStore.EmailSending.Contracts;
using BookStore.EmailSending.EmailBackgroundService;

namespace BookStore.EmailSending.Integrations;
internal class SendEmailCommandHandler //:  IRequestHandler<SendEmailCommand, Result<Guid>>
{
  private readonly ISendEmail _emailSender;

  public SendEmailCommandHandler(ISendEmail emailSender)
  {
    _emailSender = emailSender;
  }

  public async Task<Result<Guid>> HandleAsync(SendEmailCommand request, 
    CancellationToken ct)
  {
    await _emailSender.SendEmailAsync(request.To,
      request.From,
      request.Subject,
      request.Body);

    return Guid.Empty;
  }
}
