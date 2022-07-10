using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberID);
        Member GetMemberByID(int memberID);
        Member GetMemberByEmail(string email);
        bool CheckLogin(string userName, string password);
        bool IsAdmin(string userName, string password);
    }
}
