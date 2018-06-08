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
using OffArea.Entities;
using OffArea.Tools;

namespace OffArea
{
    [Activity(Label = "نمایش جزییات تیکت", Icon = "@drawable/mainIcon", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]

    public class ShowOrder : Activity
    {
        private Order od;
        ApiRepository api = new ApiRepository();
        TextView txtOrderDate;
        TextView txtPrice;
        TextView txtServiceName;
        TextView txtDescription;
        TextView txtQty;
        TextView txtCode;
        TextView txtRequester;
        TextView txtDiscount;
        ImageView imgShow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowOneOrderLayout);

            try
            {
                //txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
                txtOrderDate = FindViewById<TextView>(Resource.Id.txtOrderDate);
                txtPrice = FindViewById<TextView>(Resource.Id.txtPrice);
                txtServiceName = FindViewById<TextView>(Resource.Id.txtServiceName);
                txtQty = FindViewById<TextView>(Resource.Id.txtQty);
                txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
                txtCode = FindViewById<TextView>(Resource.Id.txtCode);
                txtDiscount = FindViewById<TextView>(Resource.Id.txtDiscount);
                txtRequester = FindViewById<TextView>(Resource.Id.txtRequester);
                imgShow = FindViewById<ImageView>(Resource.Id.imgShow);                
                int OrderID = Intent.GetIntExtra("OrderID", 0);
                od = api.GetOrderByID(OrderID);
                // Create your application here

                txtOrderDate.Text = od.OrderDate.ToShamsi();
                txtPrice.Text = od.Price.ToString("#,0 ریال");
                txtServiceName.Text = od.ServiceName;
                txtDescription.Text = od.Description == null ? null : od.Description;
                txtQty.Text = od.Quantity.ToString() + "عدد ";
                txtDiscount.Text = od.Discount.ToString() + "درصد    ";
                txtCode.Text = od.Code;
                txtRequester.Text = od.Requester;   

                imgShow.SetImageResource(Resource.Drawable.product);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            try
            {
                MenuInflater.Inflate(Resource.Menu.ListViewMenu, menu);
                return base.OnCreateOptionsMenu(menu);
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionScanner:
                    Toast.MakeText(this, "با موفقیت اسکن شد", ToastLength.Long).Show();
                    break;
                case Resource.Id.actionConfirm:
                    Toast.MakeText(this, "با موفقیت تایید شد", ToastLength.Long).Show();
                    api.ConfirmOrder(od.OrderID);                 
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}