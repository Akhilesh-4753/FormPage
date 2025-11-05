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
        public IActionResult Register([FromBody] Register bodyData)
        {
            try
            {
                string connectionString = "data source=DESKTOP-NN64K04\\SQLEXPRESS; database=USERS; integrated security=SSPI ;TrustServerCertificate=True"; // Database aayi connection string

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                      connection.Open();

                    string sqls = "INSERT INTO USERS(NAME, PASSWORD, EMAIL) VALUES(@Name, @Password, @Email)";
                    SqlCommand sqlCommand = new SqlCommand(sqls, connection);
                    sqlCommand.Parameters.AddWithValue("@Name", bodyData.Name);
                    sqlCommand.Parameters.AddWithValue("@Password", bodyData.Password);
                    sqlCommand.Parameters.AddWithValue("@Email", bodyData.Email);

                    bool success = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                    if(success)
                    {
                        return Ok("user register successfull");
                    }
                    return BadRequest("failed");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
