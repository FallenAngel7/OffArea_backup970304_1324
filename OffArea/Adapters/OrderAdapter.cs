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
using OffArea.Entities;
using OffArea.Tools;

namespace OffArea.Adapters
{
    public class OrderAdapter : BaseAdapter<Order>
    {
        private Activity _context;
        private List<Order> _list;
        public OrderAdapter(Activity context, List<Order> list)
        {
            _context = context;
            _list = list;
        }

        public override Order this[int position] => _list[position];

        public override int Count => _list.Count;

        public override long GetItemId(int position)
        {
            return _list[position].OrderID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if(view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.OrderDetails, null);
            }
            Order od = _list[position];
            view.FindViewById<TextView>(Resource.Id.txtServiceName).Text = od.ServiceName;
            view.FindViewById<TextView>(Resource.Id.txtQty).Text = od.Quantity.ToString();
            view.FindViewById<TextView>(Resource.Id.txtPrice).Text = od.Price.ToString("#,0 ریال");
            view.FindViewById<TextView>(Resource.Id.txtOrderDate).Text = od.OrderDate.ToShamsi();
            view.FindViewById<ImageView>(Resource.Id.imgOrder).SetImageResource(Resource.Drawable.product);
            
            return view;
        }
    }
}