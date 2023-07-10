using Dapper;
using DapperExtension;
using ITS.PMT.Domain.Dto.UserPermissionDtos;
using ITS.PMT.Domain.Models.UserPermission;

namespace ITS.PMT.Infrastructure.Repositories.UserPermissionRepository
{
    public sealed class UserPermissionRepository : IUserPermissionRepository
    {

        private string _conString;

        public UserPermissionRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> Create(UserPermissionDto model)
        {
            UserPermissionModel userPermissionModel = new UserPermissionModel();
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                userPermissionModel.EmployeeId = model.UserId;
                foreach (var item in model.PermissionId)
                {
                    userPermissionModel.PermissionId = item;
                    userPermissionModel.InsertedDate = DateTime.UtcNow;
                    id = con.InsertReturnId(userPermissionModel);
                }


                con.Close();
                return id;
            }
        }


        public async Task<int> Delete(UserDeletePermissionDto role)
        {
            try
            {
                using (var connection = DbHelper.GetConn(_conString))
                {
                    connection.Open();
                    foreach (var item in role.PermissionId)
                    {
                        var affectedRows = await connection.ExecuteAsync("SELECT update_user_permission(@p_user_id, @p_permission_id)",
                        new { p_user_id = role.UserId, p_permission_id = item });
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
