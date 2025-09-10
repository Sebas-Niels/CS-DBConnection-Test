using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorCarsDapper.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace WebRazorCarsDapper.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        public List<Car> Cars { get; set; }

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public async Task OnGetAsync()
        {
            var connString = _config.GetConnectionString("DefaultConnection");
            using var connection = new SqlConnection(connString);

            var sql = "SELECT TOP 5 Licenseplate, Make, Model, Color FROM Cars";
            var result = await connection.QueryAsync<Car>(sql);

            Cars = result.AsList();
        }
    }
}
