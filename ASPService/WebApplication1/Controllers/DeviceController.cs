using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        public static int DevId = 0;
        public DeviceDataContext db = new DeviceDataContext();
        public ActionResult Index()
        {
            IEnumerable<Device> devices = db.Devices;
            Dictionary<int, string> burdens = new Dictionary<int, string>();
            IEnumerable<Burden> burdensOutput = db.Burdens;
            ViewBag.Burdens = new SelectList(db.Burdens, "Id", "Name");
            foreach (Burden obj in burdensOutput)
            {
                burdens.Add(obj.Id, obj.Name);
            }
            List<OutputDevice> output = new List<OutputDevice>();
            foreach (Device obj in devices)
            {
                output.Add(new OutputDevice(obj.Id, obj.Name, burdens[obj.Burden_Id], obj.Burden_Id));
            }
            return View(output);
        }
        [HttpGet]
        public ActionResult EditDevice(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Device device = db.Devices.Find(id);
            if (device != null)
            {
                return View(device);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult EditDevice(Device obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDevice(int id)
        {
            var device = db.Devices.FirstOrDefault(f => f.Id == id);
            db.Entry(device).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateDevice()
        {
            ViewBag.Burdens = new SelectList(db.Burdens, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateDevice(Device obj)
        {
            db.Devices.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ManageValues(int? id)
        {
            DevId = (int)id;
            DeviceValues ret = new DeviceValues();
            if (id == null)
            {
                return HttpNotFound();
            }
            Device device = db.Devices.Find(id);
            ret.device = device;
            ret.value = new List<RealValue>();
            List<string> retValues = new List<string>();

            IEnumerable<RealValue> data = db.RealValues.Where(d => d.Device_Id == id);
            foreach (RealValue obj in data)
            {
                ret.value.Add(obj);
                retValues.Add(obj.Date_Time.ToString() + " Значение: " + obj.Value.ToString());
            }

            ViewBag.Values = new SelectList(retValues);
            ret.CountValues = ret.value.Count;
            if (device != null)
            {
                return View(ret);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult ManageValues(int id)
        {
            IEnumerable<RealValue> devices = db.RealValues.Where(d => d.Device_Id == id);
            foreach(RealValue val in devices)
            {
                db.Entry(val).State = EntityState.Deleted;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
            

        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            int CountOfElements = 0;
            int countOfDays = 0;
            DateTime[] famousDates;
            float[] famousValues;
            string[] famousValuesStr;
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                string fdpath = Server.MapPath("~/Files/" + fileName);
                Excel.Application ObjWorkExcel = new Excel.Application();
                Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(fdpath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                string[,] list = new string[lastCell.Column, lastCell.Row];
                int iLastRow = ObjWorkSheet.Cells[ObjWorkSheet.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row;
                var arrData = (object[,])ObjWorkSheet.Range["A1:Z" + iLastRow].Value;
                CountOfElements = arrData.GetLength(0);
                countOfDays = CountOfElements / 24;
                famousDates = new DateTime[CountOfElements];
                famousValues = new float[CountOfElements];
                famousValuesStr = new string[CountOfElements];
                ObjWorkExcel.Quit();
                ObjWorkSheet = null;
                ObjWorkBook = null;
                ObjWorkExcel = null;
                GC.Collect();
                Process excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
                excelProc.Kill();
                for (int i = 0; i < CountOfElements; i++)
                {
                    famousValues[i] = (float)Convert.ToDouble(arrData[i + 1, 2]);
                }
                for (int i = 0; i < CountOfElements; i++)
                {
                    famousDates[i] = Convert.ToDateTime(arrData[i + 1, 1]);
                }
                for (int i = 0; i < CountOfElements; i++)
                {
                    famousValuesStr[i] = famousValues[i].ToString();
                    famousValuesStr[i] = famousValuesStr[i].Replace(',', '.');
                }
                List<RealValue> values = new List<RealValue>();
                for (int i = 0; i < CountOfElements; i++)
                {
                    values.Add(new RealValue(famousDates[i], famousValues[i], DevId));
                }
                foreach(RealValue val in values)
                {
                    db.RealValues.Add(val);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}