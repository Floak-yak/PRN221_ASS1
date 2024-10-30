using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class MemberDAO
    {
        private AppDbContext _context;
        private static MemberDAO instance = null;

        public MemberDAO()
        {
            _context = new AppDbContext();
        }

        public static MemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }

        public MemberObject GetMemberByEmail(string email)
        {
            return _context.Members.SingleOrDefault(m => m.Email.Equals(email));
        }

        public MemberObject GetMemberById(int id)
        {
            return _context.Members.SingleOrDefault(m => m.MemberId == id);
        }
        public List<MemberObject> GetMembers()
        {
            return _context.Members.ToList();
        }

        public bool CreateMember(MemberObject member)
        {
            _context.Members.Add(member);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateMember(MemberObject member)
        {
            _context.Members.Update(member);

            return _context.SaveChanges() > 0;
        }

        public bool RemoveMember(int id)
        {
            var member = GetMemberById(id);

            if (member != null)
            {
                _context.Members.Remove(member);
            }
            else
            {
                return false;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
