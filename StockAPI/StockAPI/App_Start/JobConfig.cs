using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Web;
using Hangfire;
using StockAPI.Controllers;

namespace StockAPI.App_Start
{
    public class JobConfig
    {
        public static void SetJob()
        {
            RecurringJob.AddOrUpdate(
                     () => GetStockInfo("1月補盤點資料")
                     , "0 0 8 * *  ?", TimeZoneInfo.Local);
        }
        #region 取得股票資料
        public static void GetStockInfo(string message)
        {
            StockInfoController controller = new StockInfoController();
            controller.GetStockInfo();
        }
        #endregion
    }
}