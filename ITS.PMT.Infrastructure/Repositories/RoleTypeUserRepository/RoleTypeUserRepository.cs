using Dapper;
using DapperExtension;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Domain.Models.RoleTypeUserModel;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypeUserRepository
{
    public sealed class RoleTypeUserRepository : IRoleTypeUserRepository
    {

        private string _conString;

        public RoleTypeUserRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> Create(RoleTypeUserDto model)
        {
            RoleTypeUserModel roleTypeUserModel = new RoleTypeUserModel();
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                roleTypeUserModel.RoleId = model.GroupId;
                foreach (var item in model.UserId)
                {
                    roleTypeUserModel.Employee_id = item;
                    roleTypeUserModel.InsertedDate = DateTime.UtcNow;
                    id = con.InsertReturnId(roleTypeUserModel);
                }


                con.Close();
                return id;
            }
        }


        public async Task<int> Delete(RoleTypeDeleteUserDto role)
        {
            try
            {
                using (var connection = DbHelper.GetConn(_conString))
                {
                    connection.Open();
                    foreach (var item in role.UserId)
                    {
                        var affectedRows = await connection.ExecuteAsync("SELECT update_role_type_user(@p_role_id, @p_user_id)",
                        new { p_role_id = role.GroupId, p_user_id = item });
                    }

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
