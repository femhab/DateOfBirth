using AutoMapper;
using DateOfBirthApp.Business.Interface;
using DateOfBirthApp.Data.AppContext;
using DateOfBirthApp.Data.Entity;
using DateOfBirthApp.Data.Enum;
using DateOfBirthApp.ViewModel.Model;
using DateOfBirthApp.ViewModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateOfBirthApp.Business.Service
{
    public class UserService: IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Create(UserFormModel model)
        {
            //if (model != null);.....want to ask this question
                try
            {
                var dataUser = _context.Users.Count(x => x.FirstName.ToLower() == model.FirstName.ToLower());
                if (dataUser == 0)
                {
                    User user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Title = _mapper.Map<Title>(model.Title),
                        CreatedDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        CreatedBy = model.FirstName + " " + model.LastName,
                        PhoneNumber = model.PhoneNumber
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return new BaseResponse() { Status = true, Message = "Created Successfully" };
                }

                return new BaseResponse() { Status = false, Message = "Operation Failed" };
            }
            catch(Exception ex)
            {
                return new BaseResponse() { Status = false, Message = "General Error" };
            }

        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
                return new BaseResponse() { Status = true, Message = "Deleted Successfully" };
            }
            return new BaseResponse() { Status = false, Message = "Operation Failed" };
        }

        public Task<List<UserModel>> GetAll()
        {
            var users = _context.Set<User>().ToList();

            var userModel = _mapper.Map<List<UserModel>>(users);

            return Task.FromResult<List<UserModel>> (userModel);
        }

        public Task<UserModel> GetById(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);

                var userModel = _mapper.Map<UserModel>(user);

                return Task.FromResult<UserModel>(userModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseResponse> Update(UserModel model)
        {
            var data = _context.Users.FirstOrDefault(x => x.Id == model.Id);

            if(data != null)
            {
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.DateOfBirth = model.DateOfBirth;
                data.PhoneNumber = model.PhoneNumber;
                data.Title = _mapper.Map<Title>(model.Title);
                data.UpdatedBy = model.FirstName + " " + model.LastName;
                data.UpdatedDate = DateTime.Now;

                _context.Users.Update(data);

                await _context.SaveChangesAsync();

                return new BaseResponse() { Status = true, Message = "Updated Successfully" };
            }
            return new BaseResponse() { Status = false, Message = "Operation Failed" };
        }
    }
}
