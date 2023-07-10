using Dapper;
using DapperExtension;
using ITS.PMT.Domain.Dto.Employee;

namespace ITS.PMT.Infrastructure.Repositories.EmployeeRepository
{
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private string _conString;

        public EmployeeRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<List<GetAllEmployeeDto>> GetAllEmployee()
        {
            string query = $"getallemployee()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllEmployeeDto> res = (List<GetAllEmployeeDto>)con.GetAllPostgreTableValuedFunctionData<GetAllEmployeeDto>(query, new { }).OrderBy(x => x.Id).ToList(); ;

                con.Close();
                return res;
            }
        }


        public async Task<EmployeePermissionGetAllDto> GetAllUserPermissionById(int roleTypeId)
        {
            string query = "SELECT * FROM get_permissions_by_user_combined(@RoleTypeId)";


            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                var parameters = new { RoleTypeId = roleTypeId };

                using (var multiResult = await con.QueryMultipleAsync(query, parameters))
                {
                    var results = await multiResult.ReadAsync<string>();
                    var roleFalseJson = results.FirstOrDefault();
                    var roleTrueJson = results.Skip(1).FirstOrDefault();
                    var roleFalse = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPermissionAllReturnFalseDto>(roleFalseJson);
                    var roleTrue = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPermissionAllReturnTrueDto>(roleTrueJson);

                    var dto = new EmployeePermissionGetAllDto
                    {
                        RoleFalse = roleFalse,
                        RoleTrue = roleTrue
                    };

                    return dto;
                }
            }
        }

        public async Task<GetAllPermissionByUserDto> GetAllPermissionByUserByFin(string fin)
        {
            string query = "SELECT * FROM get_employee_permissions_byfinnumber(@fin)";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                var parameters = new { fin = fin };

                var result = await con.QuerySingleOrDefaultAsync<string>(query, parameters);

                if (result != null)
                {
                    var dto = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAllPermissionByUserDto>(result);

                    return dto;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
