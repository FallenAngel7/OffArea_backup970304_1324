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
using System.Net.Http;
using Newtonsoft.Json;



namespace OffAreaApp.Repository
{
    public class ApiRepository
    {
        public static string ApiUrl = "http://192.168.42.202:7574";
        public static string ApiUserAuthentication = @"http://192.168.42.202/api/auth.php?";

        public List<Order> GetAllOrders()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(ApiUrl + "/AllOrders").Result;
                return JsonConvert.DeserializeObject<List<Order>>(result);
            }
        }

        public Order GetOrderByID(int OrderID)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(ApiUrl + "/Order/ " + OrderID).Result;
                return JsonConvert.DeserializeObject<Order>(result);
            }
        }

        public void ConfirmOrder(int OrderID)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(ApiUrl + "/ConfirmOrder/ " + OrderID).Result;                
            }
        }

        public bool IsUserValid(string username, string password)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var username_correct = System.Net.WebUtility.UrlEncode(username);
                    var password_correct = System.Net.WebUtility.UrlEncode(password);
                    var url = ApiUserAuthentication + "username=" + username
                    + "&password=" + password;
                    var result = client.GetStringAsync(url).Result;
                    if (result == "true") return true;
                    else return false;
                }                
                
            }           
        }

    }
}