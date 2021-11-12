using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        GenericRepository<User> user = new GenericRepository<User>();
        GenericRepository<Post> post = new GenericRepository<Post>();
        public List<User> GetData() => user.List();
        public List<Post> GetPost() => post.List();

        public void UserCheck(User p)
        {
            Context c = new Context();
            var userinfo = c.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if(userinfo.Email != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Email, false);
                //return RedirectToAction("Index", "Home");
            }
            else
            {
                //"Kullanıcı adı veya parola hatalı";
            }
        }
        public void AddUser(User p)
        {
            if (p.Password == "")
            {
                //Hata mesajı
            }
            else
            {
                user.Insert(p);
            }
        }
        public void CreatePost(Post p)
        {
            post.Insert(p);
        }

        
    }
}
