﻿namespace BookStore.Reporting.ReportEndpoints;

internal interface ITopSellingBooksReportService
{
  TopBooksByMonthReport ReachInSqlQuery(int month, int year);
}
