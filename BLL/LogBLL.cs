using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogBLL
    {
        private static LogBLL _Instance;
        public static LogBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LogBLL();
                return _Instance;
            }
            private set { }
        }

        public DataTable GetAll()
        {
            return DAL.LogDAL.Instance.GetAll();
        }

        public void WriteLog(string action, string user)
        {
            DAL.LogDAL.Instance.Insert(action, user);
        }
    }
}
