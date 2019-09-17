using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Interview.Models
{
    //TO DO Create an interface for DI container
    public class DatabaseMock<T> where T : class
    {
        private IList<T> _items;
        private IList<T> Items {
            get
            {
                if(_items == null)
                {
                    _items = GetItemsFromStream();
                }
                return _items;
            }
        }

        public IList<T> GetAll()
        {
            //perform some data logic
            return Items;
        }

        private IList<T> GetItemsFromStream()
        {
            try
            {
                using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/data.json")))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<IList<T>>(json);
                }
            }
            catch (Exception ex)
            {
                //TO DO log
                return new List<T>();
            }
        }

    }
}
