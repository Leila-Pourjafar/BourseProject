using Bourse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bourse.BLL
{
    public interface IUserBusiness
    {
        bool ExistUser(int id);
        object GetInfo(int id);
        string GetName();
    }

    public class UserBusiness : IUserBusiness
    {
        private DAL.UnitOfWork unitOfWork;
        public UserBusiness()
        {
            this.unitOfWork = new UnitOfWork();
        }
        public object GetInfo(int id)
        {
            var info = new { Name = "sara", Tel = "09514788888", Id = 12 };
            return info;
        }
        public bool ExistUser(int id)
        {
            var data = unitOfWork.EmployeeRepository.GetByID(id);
            #region ExistUser
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion /ExistUser
        }
        public string GetName()
        {
            string name = "sara";
            return name;
        }
    }
}