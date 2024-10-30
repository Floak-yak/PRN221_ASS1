using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public bool Create(MemberObject member)
        {
            return MemberDAO.Instance.CreateMember(member);
        }

        public bool Delete(int id)
        {
            return MemberDAO.Instance.RemoveMember(id);
        }

        public List<MemberObject> GetAllMembers()
        {
            return MemberDAO.Instance.GetMembers();
        }

        public MemberObject GetMemberByEmail(string email)
        {
            var member = MemberDAO.Instance.GetMemberByEmail(email);
            return member;
        }

        public MemberObject GetMemberById(int id)
        {
            return MemberDAO.Instance.GetMemberById(id);
        }

        public bool Update(MemberObject member)
        {
            return MemberDAO.Instance.UpdateMember(member);
        }
    }
}
