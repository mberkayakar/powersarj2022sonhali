using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Business.Concrete.DTO;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public interface IUserService: IGenericService<User>
    {

        IEnumerable<User> GetAllUserİnformation(Expression<Func<User, bool>> filter, params Expression<Func<User, object>>[] children );

        void SaveUser(UserSaveDto usermodule);

        User DeleteUserWithUserId(string userid);

        IEnumerable<UserListDto> GetAllUsers(Expression<Func<User, bool>> filter = null);

        User UpdatedUserModel (AddOperationFromUser addoperationfromuser , Expression<Func<User, bool>> filter = null);

        User UpdatedUserModel(UserUpdateDTO userUpdateDTO);



        User UserLogin(UserLoginDto userlogindto);






    }
}
