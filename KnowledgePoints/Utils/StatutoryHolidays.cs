using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Com.Lqn.Knowledge.Utils
{
    /// <summary>
    /// 国家法定节假日
    /// </summary>
    class StatutoryHolidays
    {
        /// <summary>
        /// 获取指定开始时间，往后days天的节假日
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static string GetHolidaySql(string startTime,int days)
        {
            DateTime dateTime = Convert.ToDateTime(startTime);
            List<string> list = new List<string>();
            StringBuilder builder = new StringBuilder();
            int id = 30;
            for (var i = 0; i < 366; i++)
            {
                string date = dateTime.AddDays(i).ToString("yyyy-MM-dd");
                string result = HttpHelper.HttpGet($"http://timor.tech/api/holiday/info/{date}");
                if (!string.IsNullOrEmpty(result))
                {
                    HolidayDto dto = JsonConvert.DeserializeObject<HolidayDto>(result);
                    if (dto.Holiday != null)
                    {
                        int type = dto.Holiday.Holiday ? 1 : 2;
                        string sql = $"INSERT INTO statutoryholidays(Id,`Name`,Type,Date,CreationTime) VALUES({id},'{dto.Holiday.Name}',{type},'{date}','2019-12-31');\r\n";
                        builder.Append(sql);
                        id++;
                    }
                }
                Thread.Sleep(500);
            }
            string finalStr = builder.ToString();
            return finalStr;
        }
    }

    public class HolidayDto
    {
        public int Code { get; set; }
        public AHoliday Holiday { get; set; }
    }

    public class AHoliday
    {
        public bool Holiday { get; set; }
        public string Name { get; set; }
        public int Wage { get; set; }
        public bool After { get; set; }
        public string Target { get; set; }
    }
}
