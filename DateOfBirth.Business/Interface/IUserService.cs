using DateOfBirthApp.ViewModel.Model;
using DateOfBirthApp.ViewModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DateOfBirthApp.Business.Interface
{
    public interface IUserService
    {
        Task<BaseResponse> Create(UserFormModel model);
        Task<BaseResponse> Update(UserModel model);
        Task<BaseResponse> Delete(Guid id);
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(Guid id);
    }
}
