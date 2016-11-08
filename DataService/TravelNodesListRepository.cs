using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Model;

namespace Crawler.DataService
{
    public class TravelNodesListRepository //: IRepository<Commodity>
    {
        private Logger logger = new Logger(typeof(TravelNodesListRepository));

        public void Save(List<TravelNotesList> TravelNotesListList)
        {
            SqlHelper.InsertList<TravelNotesList>(TravelNotesListList, "Category");
            new Action<List<TravelNotesList>>(SaveList).BeginInvoke(TravelNotesListList, null, null);
        }

        /// <summary>
        /// 根据Level获取类别列表
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public List<TravelNotesList> QueryListByLevel(int level)
        {
            string sql = string.Format("SELECT * FROM category WHERE categorylevel={0};", level);
            return SqlHelper.QueryList<TravelNotesList>(sql);
        }


        /// <summary>
        /// 存文本记录的
        /// </summary>
        /// <param name="TravelNotesListList"></param>
        public void SaveList(List<TravelNotesList> TravelNotesListList)
        {
            StreamWriter sw = null;
            try
            {
                string recordFileName = string.Format("{0}_TravelNotesList.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));
                string totolPath = Path.Combine(ObjectFactory.DataPath, recordFileName);
                if (!Directory.Exists(Path.GetDirectoryName(totolPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(totolPath));
                    sw = File.CreateText(totolPath);
                }
                else
                {
                    sw = File.AppendText(totolPath);
                }

                sw.WriteLine(JsonConvert.SerializeObject(TravelNotesListList));
            }
            catch (Exception e)
            {
                logger.Error("CategoryRepository.SaveList出现异常", e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
