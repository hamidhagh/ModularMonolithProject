﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Syntax.Elements.Types;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using BookStore.Orders;
using Xunit.Abstractions;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace RiverBooks.OrderProcessing.Tests;

public class InfrastructureDependencyTests
{
  private readonly ITestOutputHelper _outputHelper;

  public InfrastructureDependencyTests(ITestOutputHelper outputHelper)
  {
    _outputHelper = outputHelper;
  }

  private static readonly Architecture Architecture =
  new ArchLoader()
    .LoadAssemblies(typeof(AssemblyInfo).Assembly)
    .Build();


  [Fact]
  public void DomainTypesShouldNotReferenceInfrastructure()
  {
    var domainTypes = Types().That()
      .ResideInNamespace("BookStore.Orders.Domain.*",
      useRegularExpressions: true)
      .As("OrderProcessing Domain Types");

    var infrastructureTypes = Types().That()
      .ResideInNamespace("BookStore.Orders.Infrastructure.*",
      useRegularExpressions: true)
      .As("OrderProcessing Infrastructure Types");

    var rule = domainTypes.Should().NotDependOnAny(infrastructureTypes);

    // PrintTypes(domainTypes, infrastructureTypes);

    rule.Check(Architecture);
  }

  /// <summary>
  /// Used for debugging purposes
  /// </summary>
  /// <param name="domainTypes"></param>
  /// <param name="infrastructureTypes"></param>
  private void PrintTypes(GivenTypesConjunctionWithDescription domainTypes,
    GivenTypesConjunctionWithDescription infrastructureTypes)
  {
    // Debugging - Inspect classes and their dependencies
    foreach (var domainClass in domainTypes.GetObjects(Architecture))
    {
      _outputHelper.WriteLine($"Domain Type: {domainClass.FullName}");
      foreach (var dependency in domainClass.Dependencies)
      {
        var targetType = dependency.Target;
        if (infrastructureTypes.GetObjects(Architecture).Any(infraClass => infraClass.Equals(targetType)))
        {
          _outputHelper.WriteLine($"  Depends on Infrastructure: {targetType.FullName}");
        }
      }
    }

    foreach (var iType in infrastructureTypes.GetObjects(Architecture))
    {
      _outputHelper.WriteLine($"Infrastructure Types: {iType.FullName}");
    }
  }

}
