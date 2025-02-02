﻿using BookStore.Orders.Domain;
using BookStore.Orders.Infrastructure;
using BookStore.Orders.Interfaces;
using BookStore.Users.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookStore.Orders.Integrations;

internal class AddressCacheUpdatingNewUserAddressHandler :
  INotificationHandler<NewUserAddressAddedIntegrationEvent>
{
  private readonly IOrderAddressCache _addressCache;
  private readonly ILogger<AddressCacheUpdatingNewUserAddressHandler> _logger;

  public AddressCacheUpdatingNewUserAddressHandler(IOrderAddressCache addressCache,
    ILogger<AddressCacheUpdatingNewUserAddressHandler> logger)
  {
    _addressCache = addressCache;
    _logger = logger;
  }

  public async Task Handle(NewUserAddressAddedIntegrationEvent notification, 
    CancellationToken ct)
  {
    var orderAddress = new OrderAddress(notification.Details.AddressId,
      new Address(notification.Details.Street1,
        notification.Details.Street2,
        notification.Details.City,
        notification.Details.State,
        notification.Details.PostalCode,
        notification.Details.Country));

    await _addressCache.StoreAsync(orderAddress);

    _logger.LogInformation("Cache updated with new address {address}", orderAddress);
  }
}

