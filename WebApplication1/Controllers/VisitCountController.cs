using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using WebApplication1.Data;
using System.Runtime.InteropServices;

namespace WebApplication1.Controllers
{
    public class VisitCountController : Controller
    {
        public IActionResult Index()
        {
            string connectionString = "Server=localhost;Database=PIPA;Trusted_Connection=True;TrustServerCertificate=True";
            using var connection = new SqlConnection(connectionString);
            // connection.Open();
            int count = ++connection.Query<Count>("select * from storage").ToList()[0].Counter;
            connection.Execute("update storage set counter = counter + 1");
            return View(new VisitCountViewModel { Count =  count });
        }
    }
}