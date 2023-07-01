using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Management;
using System.Web.Mvc;
using System.Xml.Linq;
using Hangfire;
using Newtonsoft.Json;

namespace StockAPI.Controllers
{
    public class StockInfoController : Controller
    {
        public class StockJson
        {
            public string 發言日期 { get; set; }
            public string 出表日期 { get; set; }
            public string 公司代號 { get; set; }
            public string 公司名稱 { get; set; }
            [JsonProperty("主旨 ")] // 指定 JSON 屬性名稱
            public string 主旨 { get; set; }
            public string 符合條款 { get; set; }
            public string 事實發生日 { get; set; }
            public string 說明 { get; set; }
        }
        // GET: StockInfo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStockInfo()
        {
            try
            {
                String APIUrl = "https://openapi.twse.com.tw/v1/opendata/t187ap04_L";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(APIUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonContent = response.Content.ReadAsStringAsync().Result;
                        List<StockJson> jsonObject = JsonConvert.DeserializeObject<List<StockJson>>(jsonContent);
                        String tempstr = ConfigurationManager.AppSettings["StockAry"];
                        Array StockAry = tempstr.TrimStart('[').TrimEnd(']').Split(',');
                        String rs = "";
                        jsonObject.ForEach(x =>
                        {
                            foreach (String Scode in StockAry)
                            {
                                if(x.公司代號 == Scode)
                                {
                                    rs += x.公司代號 + "\r\n" + x.主旨 + "\r\n" + x.說明 + "\r\n" + x.發言日期;
                                }
                            }
                        });
                        return Json(rs);
                    }
                    else
                    {
                        // 處理請求失敗的情況
                        return Json((int)response.StatusCode);
                    }
                }
                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}