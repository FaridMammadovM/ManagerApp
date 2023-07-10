using DapperExtension;
using ITS.PMT.Domain.Dto.ProtocolDtos;
using ITS.PMT.Domain.Models.Protocol;

namespace ITS.PMT.Infrastructure.Repositories.ProtocolRepository
{
    public sealed class ProtocolRepository : IProtocolRepository
    {
        private string _conString;
        public ProtocolRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> CreateProtocol(ProtocolModel protocolModel)
        {
            var query = $"addcomenttoprotocol({protocolModel.MeetingId},{protocolModel.EmployeeId},{protocolModel.ProjectId},'{protocolModel.Description}',{protocolModel.IsDeleted = 0},'{protocolModel.InsertUser}','{protocolModel.InsertDate = DateTime.Now}')";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                int res = con.GetFirstOrDefaultPostgreFunctionData<int>(query);
                con.Close();
                return await Task.FromResult(res);
            }
        }

        public async Task<int> DeletePratocol(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var protocolModel = con.GetById<ProtocolModel>(id);
                if (protocolModel == null) return 0;
                protocolModel.IsDeleted = 1;
                var update = con.Update(protocolModel);
                con.Close();
                return update;

            }

        }

        public async Task<List<GetProtocolsByIdDto>> GetProtocolById(int id)
        {
            string query = $"GetProtocolById({id})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetProtocolsByIdDto> res = (List<GetProtocolsByIdDto>)con.GetAllPostgreTableValuedFunctionData<GetProtocolsByIdDto>(query, new { });
                con.Close();
                return res;
            }
        }

        public async Task<List<GetProtocolsByMeetingIdDto>> GetProtocolsByMeetingId(int meetingId)
        {
            string query = $"GetProtocolsByMeetingId({meetingId})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetProtocolsByMeetingIdDto> res = (List<GetProtocolsByMeetingIdDto>)con.GetAllPostgreTableValuedFunctionData<GetProtocolsByMeetingIdDto>(query, new { });
                con.Close();
                return res;
            }
        }

        public async Task<int> UpdateProtocol(ProtocolModel protocolModel)
        {
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                ProtocolModel model = con.GetById<ProtocolModel>(protocolModel.Id);
                if (model == null) return 0;
                model.MeetingId = protocolModel.MeetingId;
                model.EmployeeId = protocolModel.EmployeeId;
                model.ProjectId = protocolModel.ProjectId;
                model.Description = protocolModel.Description;
                model.UpdateUser = protocolModel.UpdateUser;
                model.UpdateDate = DateTime.Now;
                id = con.Update(model);
                con.Close();
                return await Task.FromResult(id);
            }


        }

    }
}
