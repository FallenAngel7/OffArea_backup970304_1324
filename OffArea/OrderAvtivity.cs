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
using OffAreaApp.Repository;
using OffArea.Adapters;

namespace OffArea
{
    [Activity(Label = "لیست تیکت های جاری", Icon = "@drawable/mainIcon")]
    public class OrderAvtivity : Activity
    {
        ApiRepository Od = new ApiRepository();
        private ListView lstOrders;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderLayout);
            lstOrders = FindViewById<ListView>(Resource.Id.lstOrders);
            var q = Od.GetAllOrders().Where(w=>!w.IsConfirm).ToList();
            lstOrders.Adapter = new OrderAdapter(this, q);
            // Create your application here

            lstOrders.ItemClick += LstOrders_ItemClick;
        }

        protected override void OnStart()
        {
            SetContentView(Resource.Layout.OrderLayout);
            lstOrders = FindViewById<ListView>(Resource.Id.lstOrders);
            var q = Od.GetAllOrders().Where(w => !w.IsConfirm).ToList();
            lstOrders.Adapter = new OrderAdapter(this, q);
            // Create your application here

            lstOrders.ItemClick += LstOrders_ItemClick;
            base.OnStart();
        }
        private void LstOrders_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int OrderID = (int)e.Id;
            var intent = new Intent(this, typeof(ShowOrder));
            intent.PutExtra("OrderID", OrderID);
            StartActivity(intent);
        }
    }
}