using Interview.Models.Operations;
using Interview.Services.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interview.Controllers
{
    public class OperationsController : Controller
    {
        //TO DO apply Dependency Injection
        private readonly OperationsService _operationsService = new OperationsService();

        public ActionResult GetAll()
        {
            var items = _operationsService.GetAll();

            //most probably convert DTO items into some view model class and return back

            string serializedObject = SerializeWithEnumAsStrins(items);

            return Json(serializedObject, JsonRequestBehavior.AllowGet);
        }

        [Route("operations/getsingular/{applicationId}")]
        public ActionResult GetSingular(int? applicationId)
        {
            Operation item = null;

            if (applicationId.HasValue)
            {
                item = _operationsService.GetSingular(applicationId.Value);
            }

            //most probably convert DTO items into some view model class and return back

            if (item == null)
            {
                return HttpNotFound();
            }

            string serializedObject = SerializeWithEnumAsStrins(item);

            return Json(serializedObject, JsonRequestBehavior.AllowGet);
        }

        private static string SerializeWithEnumAsStrins(object items)
        {
            var setting = new Newtonsoft.Json.JsonSerializerSettings();
            setting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(items, setting);
            return serializedObject;
        }
    }
}
