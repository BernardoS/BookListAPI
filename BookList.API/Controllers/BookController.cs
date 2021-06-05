using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookList.API.Repository;

namespace BookList.API.Controllers
{
    public class BookController : Controller
    {

        private BookListEntities context { get; set; }
        private UnitOfWork unitOfWork { get; set; }

        public BookController()
        {
            context = new BookListEntities();
            unitOfWork = new UnitOfWork(context);
        }

        // GET: All Books
        public ActionResult GetBooks()
        {
            var allBooks = unitOfWork.Books.GetAll();
            return Json(allBooks, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetBook(int id)
        {
            var book = unitOfWork.Books.Get(id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateBook(Book book)
        {
            unitOfWork.Books.Update(book);
            unitOfWork.Complete();
            return Json(unitOfWork.Books.Get(book.Id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            try
            {
                unitOfWork.Books.Add(book);
                unitOfWork.Complete();
                return Json(book, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                var error = "Erro ao adicionar Livro";
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpDelete]
        public ActionResult Remove(int id)
        {
            var book = unitOfWork.Books.Get(id);
            unitOfWork.Books.Remove(book);
            unitOfWork.Complete();
            var result = "Livro com ID:" + id + ", Foi Deletado";
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}