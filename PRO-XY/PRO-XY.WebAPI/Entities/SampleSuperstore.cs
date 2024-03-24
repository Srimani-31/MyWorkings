using System;
using System.Collections.Generic;

#nullable disable

namespace PRO_XY.WebAPI.Entities
{
  #region
  //public partial class SampleSuperstore
  //  {
  //      public short Row_ID { get; set; }
  //      public string Order_ID { get; set; }
  //      public DateTime? Order_Date { get; set; }
  //      public DateTime? Ship_Date { get; set; }
  //      public string Ship_Mode { get; set; }
  //      public string Customer_ID { get; set; }
  //      public string Customer_Name { get; set; }
  //      public string Segment { get; set; }
  //      public string Country_Region { get; set; }
  //      public string City { get; set; }
  //      public string State { get; set; }
  //      public int? Postal_Code { get; set; }
  //      public string Region { get; set; }
  //      public string Product_ID { get; set; }
  //      public string Category { get; set; }
  //      public string Sub_Category { get; set; }
  //      public string Product_Name { get; set; }
  //      public double? Sales { get; set; }
  //      public byte? Quantity { get; set; }
  //      public double? Discount { get; set; }
  //      public double? Profit { get; set; }
  //  }
  #endregion

  public partial class SampleSuperstore
  {
    public short RowId { get; set; }
    public string OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public string ShipMode { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Segment { get; set; }
    public string CountryRegion { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int? PostalCode { get; set; }
    public string Region { get; set; }
    public string ProductId { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    public string ProductName { get; set; }
    public double? Sales { get; set; }
    public byte? Quantity { get; set; }
    public double? Discount { get; set; }
    public double? Profit { get; set; }
  }
}
