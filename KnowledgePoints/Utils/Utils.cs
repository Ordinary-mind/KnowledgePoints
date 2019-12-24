using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Lqn.Knowledge.Utils
{
    public class Utils
    {
        /// <summary>
        /// 获取本日、本周、本月开始时间
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetStartTimeStr(int type)
        {
            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day);
            string startTime = "";
            switch (type)
            {
                case 0:
                    startTime = today.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case 1:
                    if (today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        startTime = today.AddDays(-6).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else startTime = today.AddDays(-(int)today.DayOfWeek + 1).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case 2:
                    startTime = today.AddDays(-(int)today.Day + 1).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                default:
                    startTime = today.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
            }
            return startTime;
        }

        /// <summary>
        /// 获取本日、本周、本月的结束时间
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetEndTimeStr(int type)
        {
            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year,now.Month,now.Day);
            string endTime = "";
            switch (type)
            {
                case 0:
                    endTime = today.ToString("yyyy-MM-dd") + "23:59:59";
                    break;
                case 1:
                    if (today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        endTime = today.ToString("yyyy-MM-dd") + "23:59:59";
                    }
                    endTime = today.AddDays(7 - (int)today.DayOfWeek).ToString("yyyy-MM-dd") + "23:59:59";
                    break;
                case 2:
                    endTime = today.AddDays(1 - today.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + "23:59:59";
                    break;
                default:
                    endTime = today.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
            }
            return endTime;
        }
    }
}
