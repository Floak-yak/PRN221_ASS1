using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public interface IMemberRepository
    {
        MemberObject GetMemberByEmail(string email);
        List<MemberObject> GetAllMembers();
        MemberObject GetMemberById(int id);
        bool Delete(int id);
        bool Create(MemberObject member);
        bool Update(MemberObject member);
    }
}
