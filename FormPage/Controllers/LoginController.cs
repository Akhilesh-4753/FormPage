using FormPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FormPage.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Register bodyData) // Register is a type like object. if we type object we cant map the body data
        {
            try
            {
                string connectionString = "Server=localhost\\SQLEXPRESS02;Database=USERS_DB; integrated security=SSPI ;TrustServerCertificate=True;"; // Database aayi connection string

                using (SqlConnection connection = new SqlConnection(connectionString)) // FOR connect to database
                {
                    connection.Open(); // just open the connection

                    string sqls = "INSERT INTO USERS(USERNAME, PASSWORD, EMAIL) VALUES(@Name, @Password, @Email)"; // must add @ and add any name
                    SqlCommand sqlCommand = new SqlCommand(sqls, connection); // sqls, connection pass cheythale query execute cheyyullu so we need sql command ( tools -> nuget -> manage sql solution -> then browser -> microsoft sql client
                    sqlCommand.Parameters.AddWithValue("@Name", bodyData.Name);
                    sqlCommand.Parameters.AddWithValue("@Password", bodyData.Password);
                    sqlCommand.Parameters.AddWithValue("@Email", bodyData.Email);

                    bool success = Convert.ToBoolean(sqlCommand.ExecuteNonQuery()); // for execute above query
                    if (success)
                    {
                        return Ok("user register successfull");
                    }
                    return BadRequest("failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login1")]
        public IActionResult Login([FromBody] Login bodyData) 
        {
            try
            {
                string connectionString = "Server=localhost\\SQLEXPRESS02;Database=USERS_DB; integrated security=SSPI ;TrustServerCertificate=True;"; 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); 

                    string sqls = "SELECT COUNT(*) FROM USERS WHERE PASSWORD = @Password AND EMAIL = @Email";
                    SqlCommand sqlCommand = new SqlCommand(sqls, connection); 
                    sqlCommand.Parameters.AddWithValue("@Password", bodyData.Password);
                    sqlCommand.Parameters.AddWithValue("@Email", bodyData.Email);

                    bool success = Convert.ToBoolean(sqlCommand.ExecuteScalar()); // FOR single value execute
                    if (success)
                    {
                        return Ok("user Login successfull");
                    }
                    return BadRequest("failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
