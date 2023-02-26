using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
  // this controller depends on the BloggingRepository
  private DataContext _dataContext;
  public HomeController(DataContext db) => _dataContext = db;

  public IActionResult Index() => View(_dataContext.Blogs.OrderBy(b => b.Name));
  public IActionResult AddBlog() => View();
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult AddBlog(Blog model)
  {
    if (ModelState.IsValid)
    {
      if (_dataContext.Blogs.Any(b => b.Name == model.Name))
      {
        ModelState.AddModelError("", "Name must be unique");
      }
      else
      {
        _dataContext.AddBlog(model);
        return RedirectToAction("Index");
      }
    }
    return View();
  }
  public IActionResult DeleteBlog(int id)
  {
    _dataContext.DeleteBlog(_dataContext.Blogs.FirstOrDefault(b => b.BlogId == id));
    return RedirectToAction("Index");
  }
}
