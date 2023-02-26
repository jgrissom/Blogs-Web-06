using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
  // this controller depends on the BloggingRepository
  private DataContext _dataContext;
  public HomeController(DataContext db) => _dataContext = db;

  public IActionResult Index() => View(_dataContext.Blogs.OrderBy(b => b.Name));
  public IActionResult AddBlog() => View();
}
