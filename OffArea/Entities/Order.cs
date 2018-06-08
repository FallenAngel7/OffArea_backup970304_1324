using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OffArea.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string ServiceName { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public bool IsConfirm { get; set; }
        public string Requester { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}