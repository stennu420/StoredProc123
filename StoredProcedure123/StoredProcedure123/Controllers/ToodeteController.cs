using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Data.SqlClient;

namespace StoredProcedure123.Controllers
{
    public class ToodeteController : Controller
    {
        private readonly IConfiguration _configuration;

        public ToodeteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<ToodeteController> tooted = new List<ToodeteController>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTooted", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tooted toode = new toode
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Kategooria = reader.GetString(2),
                                Hind = reader.GetDecimal(3),
                                Laoseis = reader.GetInt32(4)
                            };
                            tooted.Add(toode);
                        }
                    }
                }
            }

            return View(tooted);
        }
    }
    
}
