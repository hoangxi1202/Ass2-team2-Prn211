using System;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool CheckLogin(string userName, string password) => MemberDAO.Instance.CheckLogin(userName, password);

        public void DeleteMember(int memberID) => MemberDAO.Instance.DeleteMember(memberID);

        public Member? GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);

        public Member? GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();

        public void InsertMember(Member member) => MemberDAO.Instance.AddNewMember(member);

        public bool IsAdmin(string userName, string password) => MemberDAO.Instance.IsAdmin(userName, password);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
