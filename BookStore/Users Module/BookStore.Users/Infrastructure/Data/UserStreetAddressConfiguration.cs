﻿using BookStore.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Users.Infrastructure.Data;

public class UserStreetAddressConfiguration : IEntityTypeConfiguration<UserStreetAddress>
{
  public void Configure(EntityTypeBuilder<UserStreetAddress> builder)
  {
    builder.ToTable(nameof(UserStreetAddress));
    builder
      .Property(x => x.Id)
      .ValueGeneratedNever();

    builder.ComplexProperty(usa => usa.StreetAddress);
  }
}

