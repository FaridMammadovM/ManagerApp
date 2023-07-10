using Dapper;
using DapperExtension;
using ITS.PMT.Domain.Dto.RoleTypePermissionDtos;
using ITS.PMT.Domain.Models.RoleTypePermission;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypePermisssionRepository
{
    public sealed class GroupPermisssionRepository : IGroupPermisssionRepository
    {

        private string _conString;

        public GroupPermisssionRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> Create(RoleTypeAddPermissionDto model)
        {
            RoleTypePermissionModel roleTypePermissionModel = new RoleTypePermissionModel();
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                roleTypePermissionModel.RoleId = model.GroupId;
                foreach (var item in model.PermissionId)
                {
                    roleTypePermissionModel.PermissionId = item;
                    roleTypePermissionModel.InsertedDate = DateTime.UtcNow;
                    id = con.InsertReturnId(roleTypePermissionModel);
                }


                con.Close();
                return id;
            }
        }

        public async Task<int> Delete(RoleTypeDeletePermissionDto role)
        {
            try
            {
                using (var connection = DbHelper.GetConn(_conString))
                {
                    connection.Open();
                    foreach (var item in role.PermissionId)
                    {
                        var affectedRows = await connection.ExecuteAsync("SELECT update_role_type_permission(@p_role_id, @p_permission_id)",
                        new { p_role_id = role.GroupId, p_permission_id = item });
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
