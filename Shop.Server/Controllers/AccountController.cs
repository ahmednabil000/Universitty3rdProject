using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Shop.Server.Models.DTO;
using System.Data;

namespace Shop.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration	)
        {
			configuration = _configuration;
				
        }
		[HttpPost]
		[Route("register")]

		
		public string register( Registration registration)
		{
			SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
			SqlCommand sqlCommand = new SqlCommand("INSERT INTO Regitration (Name, Email, Password, ConfirmPassword) VALUES ('" + registration.Name + "', '" + registration.Email + "', '" + registration.Password + "' ,'" + registration.ConfirmPassword +"')", sqlConnection);
			sqlConnection.Open();
			int i = sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
            if ( i> 0)		
            {
                return "Success";
            }
			else
			{
				return "Failed";
			}

            return "";
		}
		[HttpPost]
		[Route("login")]

		public string login(LogIn login)
		{
			SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM LogIn WHERE Email = '" + login.Email + "' AND Password = '" + login.Password + "'", sqlConnection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);	
			if (dataTable.Rows.Count == 0)
			{
				return "Failed";
			}
			else
			{
				return "Success";
			}
		}

    }
}
