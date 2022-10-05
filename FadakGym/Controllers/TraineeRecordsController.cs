using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FadakGym;


using FadakGym.Models;

namespace FadakGym.Controllers
{
    public class TraineeRecordsController : Controller
    {
        private FadakDbEntities db = new FadakDbEntities();

        // GET: TraineeRecords
        //public ActionResult Index()
        //{
        //    var traineeRecords = db.TraineeRecords.Include(t => t.User);
        //    return View(traineeRecords.ToList());
        //}
        public ActionResult Index(String Searching)
        {
            return View(db.TraineeRecords.Where(x=>x.User.Name.Contains(Searching) || Searching ==null ).ToList());
        }


        // GET: TraineeRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeRecord traineeRecord = db.TraineeRecords.Find(id);
            if (traineeRecord == null)
            {
                return HttpNotFound();
            }
            return View(traineeRecord);
        }

        // GET: TraineeRecords/Create
        public ActionResult Create()
        {   
            ViewBag.UsedID = new SelectList(db.Users.Where(s=>s.RoleID != 1), "UserID", "Name");
            return View();
        }

        // POST: TraineeRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeRecordID,UsedID,Weight,BodyFat,BMI,BodyWater,Protein,Muscle,AssessmentDate")] TraineeRecord traineeRecord)
        {
            if (ModelState.IsValid)
            {
                db.TraineeRecords.Add(traineeRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsedID = new SelectList(db.Users, "UserID", "Name", traineeRecord.UsedID);
            return View(traineeRecord);
        //}
        //[HttpPost]
        //public JsonResult getemp(string ename)
        //{
        //    FadakDbEntities db=new FadakDbEntities();
        //    var emp = (from x in db.Users where x.Name.StartsWith(ename) select new { label = x.Name }).ToList();
        //    return Json(emp);
        }

        // GET: TraineeRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeRecord traineeRecord = db.TraineeRecords.Find(id);
            if (traineeRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsedID = new SelectList(db.Users, "UserID", "Name", traineeRecord.UsedID);
            return View(traineeRecord);
        }

        // POST: TraineeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeRecordID,UsedID,Weight,BodyFat,BMI,BodyWater,Protein,Muscle,AssessmentDate")] TraineeRecord traineeRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsedID = new SelectList(db.Users, "UserID", "Name", traineeRecord.UsedID);
            return View(traineeRecord);
        }

        // GET: TraineeRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeRecord traineeRecord = db.TraineeRecords.Find(id);
            if (traineeRecord == null)
            {
                return HttpNotFound();
            }
            return View(traineeRecord);
        }

        // POST: TraineeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeRecord traineeRecord = db.TraineeRecords.Find(id);
            db.TraineeRecords.Remove(traineeRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
