using Dapper;
using DapperExtension;
using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Domain.Models.RoleType;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypeRepository
{
    public sealed class RoleTypeRepository : IRoleTypeRepository
    {

        private string _conString;

        public RoleTypeRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> Create(RoleTypeModel role)
        {

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                role.InsertedDate = DateTime.UtcNow;
                var id = con.InsertReturnId(role);
                con.Close();
                return id;
            }
        }


        public async Task<int> Update(RoleTypeModel role)
        {
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                RoleTypeModel model = con.GetById<RoleTypeModel>(role.Id);
                if (model == null)
                {
                    return 0;
                }
                model.Name = role.Name;
                model.Description = role.Description;
                model.UpdateBy = role.UserId;
                model.UpdatedDate = DateTime.UtcNow;
                id = con.Update(model);
                con.Close();
            }
            return await Task.FromResult(id);
        }

        public async Task<int> Delete(int id)
        {
            using (var connection = DbHelper.GetConn(_conString))
            {
                connection.Open();


                var model = connection.GetById<RoleTypeModel>(id);
                if (model == null) return 0;
                model.IsDeleted = true;
                model.UpdatedDate = DateTime.UtcNow;
                var res = await connection.UpdateAsync(model);
                return res;
            };
        }


        public async Task<RoleTypeModel> GetRoleById(int id)
        {

            string query = $"get_group_byid({id})";
            using (var conn = DbHelper.GetConn(_conString))
            {
                conn.Open();
                List<RoleTypeModel> project = (List<RoleTypeModel>)conn.GetAllPostgreTableValuedFunctionData<RoleTypeModel>(query, new { });
                if (project is null || project.Count == 0)
                {
                    return null;
                }
                RoleTypeModel roleTypeModel = new RoleTypeModel();
                roleTypeModel = project.First();
                conn.Close();

                return roleTypeModel;
            }
        }

        public async Task<List<RoleTypeAllReturnDto>> GetAllRoleName()
        {
            string query = $"get_all_group_name()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<RoleTypeAllReturnDto> res = (List<RoleTypeAllReturnDto>)con.GetAllPostgreTableValuedFunctionData<RoleTypeAllReturnDto>(query, new { }).ToList();

                con.Close();
                return res;
            }
        }

        public async Task<RoleTypePermissionAllReturnDto> GetAllRolePermissionById(int roleTypeId)
        {
            string query = "SELECT * FROM get_permissions_by_role_type_combined(@RoleTypeId)";


            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                var parameters = new { RoleTypeId = roleTypeId };

                using (var multiResult = await con.QueryMultipleAsync(query, parameters))
                {
                    var results = await multiResult.ReadAsync<string>();
                    var roleFalseJson = results.FirstOrDefault();
                    var roleTrueJson = results.Skip(1).FirstOrDefault();
                    var roleFalse = Newtonsoft.Json.JsonConvert.DeserializeObject<RoleTypePermissionAllReturnFalseDto>(roleFalseJson);
                    var roleTrue = Newtonsoft.Json.JsonConvert.DeserializeObject<RoleTypePermissionAllReturnTrueDto>(roleTrueJson);

                    var dto = new RoleTypePermissionAllReturnDto
                    {
                        RoleFalse = roleFalse,
                        RoleTrue = roleTrue
                    };

                    return dto;
                }
            }
        }

        public async Task<RoleTypeUserGetAllDto> GetAllRoleUserById(int roleTypeId)
        {
            string query = "SELECT * FROM get_users_by_role_type_combined(@RoleTypeId)";


            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                var parameters = new { RoleTypeId = roleTypeId };

                using (var multiResult = await con.QueryMultipleAsync(query, parameters))
                {
                    var results = await multiResult.ReadAsync<string>();
                    var roleFalseJson = results.FirstOrDefault();
                    var roleTrueJson = results.Skip(1).FirstOrDefault();
                    var roleFalse = Newtonsoft.Json.JsonConvert.DeserializeObject<RoleTypeUserAllReturnFalseDto>(roleFalseJson);
                    var roleTrue = Newtonsoft.Json.JsonConvert.DeserializeObject<RoleTypeUserAllReturnTrueDto>(roleTrueJson);

                    var dto = new RoleTypeUserGetAllDto
                    {
                        RoleFalse = roleFalse,
                        RoleTrue = roleTrue
                    };

                    return dto;
                }
            }
        }
    }
}
















