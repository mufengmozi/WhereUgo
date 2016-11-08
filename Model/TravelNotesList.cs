using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Model
{
    public class TravelNotesList
    {
        public Int32 ID { get; set; }
        public string Title { get; set; }
        //概要
        public string OverView { get; set; }
        public string Url { get; set; }
        //信息来源
        public int ConFrom { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
