using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
namespace DataAccess
{
    public class MemberDAO
    {
        private MemberDAO() { }
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public bool CheckLogin(string userName, string password)
        {
            bool result = false;
            FStoreContext DbContext = new FStoreContext();
            var member = DbContext.Members
                    .Where(b => b.Email == userName)
                    .FirstOrDefault();
            if (member == null)
            {
                throw new Exception("User name does not existed!");
            }
            else
            {
                if (member.Password != password)
                {
                    throw new Exception("Password does not correct!");
                }
                else { result = true; }
            }
            return result;
        }
        public Member GetAdminAccount()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            return new Member
            {
                Email = config["AccountAdmin:UserName"],
                Password = config["AccountAdmin:Password"],
            };
        }
        public bool IsAdmin(string userName, string password)
        {
            bool result = false;
            Member c = GetAdminAccount();
            if (c.Email.Equals(userName) && c.Password.Equals(password))
            {
                result = true;
            }

            return result;
        }
        public List<Member> GetMembers()
        {
            List<Member> list = new List<Member>();
            try
            {
                FStoreContext DbContext = new FStoreContext();
                list = DbContext.Members.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Get list members unsuccessfully");
            }
            return list;
        }

        public void AddNewMember(Member mem)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.Members.Add(mem);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add a new members unsuccessfully ");
            }
        }

        public void DeleteMember(int memberID)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                Member? mem = DbContext.Members.
                    SingleOrDefault(mem => mem.MemberId == memberID);
                DbContext.Members.Remove(mem);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Delete a member unsuccessfully");
            }
        }

        public void UpdateMember(Member mem)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.Entry<Member>(mem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update a member unsuccessfully");
            }
        }
        public Member? GetMemberByEmail(string email)
        {

            FStoreContext DbContext = new FStoreContext();
            Member? member = DbContext.Members
                    .Where(b => b.Email == email)
                    .FirstOrDefault();

            return member;
        }
        public Member? GetMemberByID(int id)
        {

            FStoreContext DbContext = new FStoreContext();
            Member? member = DbContext.Members
                    .Where(b => b.MemberId == id)
                    .FirstOrDefault();

            return member;
        }
    }
}
