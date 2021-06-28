using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DBWindowService.Model;
namespace DBWindowService
{
    public partial class DBWIndowService : ServiceBase
    {
        public DBWIndowService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            WindowServiceDemoEntities db = new WindowServiceDemoEntities();
            LogsTable log = new LogsTable();
            log.CreatedDate = DateTime.Now;
            log.Notes = "New Log Added Success!!!!!";
            log.UpdatedDate = DateTime.Now;
            db.LogsTables.Add(log);
            db.SaveChanges();
            WriteToFile(log.Notes);
        }
        private void WriteToFile(string text)
        {
            string path = "C:\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }
        protected override void OnStop()
        {
        }
    }
}
