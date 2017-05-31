using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Areas.FoodArea.Controllers
{
    public class FoodController : Controller
    {
        private FoodArea.Models.FoodEntities db = new Models.FoodEntities();
        // GET: FoodArea/Food
        public ActionResult Index(int ? page)
        {
            return View(db.Food.ToList().ToPagedList(page ?? 1, 3));
        }

        public ActionResult GetImage(int id = 1)
        {
            FoodArea.Models.Food food = db.Food.Find(id);
            byte[] img = food.BytesImage;
            return File(img, "image/jpeg");
        }

        public ActionResult Create()
        {
            ViewBag.datas = db.FoodCategory.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodArea.Models.Food food,HttpPostedFileBase Foodpicture)
        {
            if(Foodpicture != null)
            {
                string strPath = Request.PhysicalApplicationPath + Foodpicture.FileName;
                Foodpicture.SaveAs(strPath);

                var imgSize = Foodpicture.ContentLength;
                byte[] imgByte = new byte[imgSize];
                Foodpicture.InputStream.Read(imgByte, 0, imgSize);

                food.Foodpicture = Foodpicture.FileName;
                food.BytesImage = imgByte;

                db.Food.Add(food);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.message = "請選擇圖片";
            ViewBag.datas = db.FoodCategory.ToList();
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            db.Food.Remove(db.Food.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id = 0)
        {
            ViewBag.datas = db.FoodCategory.ToList();
            return View(db.Food.Find(id));
        }
        [HttpPost]
        public ActionResult Update(FoodArea.Models.Food food,HttpPostedFileBase Foodpicture)
        {
            if(Foodpicture != null)
            {
                string strPath = Request.PhysicalApplicationPath + @"Foodpicture\" + Foodpicture.FileName;
                Foodpicture.SaveAs(strPath);

                var imgSize = Foodpicture.ContentLength;
                byte[] imgByte = new byte[imgSize];
                Foodpicture.InputStream.Read(imgByte, 0, imgSize);

                food.Foodpicture = Foodpicture.FileName;
                food.BytesImage = imgByte;
            }
            db.Entry(food).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.datas = db.FoodCategory.ToList();
            return RedirectToAction("Index");
        }
    }
}