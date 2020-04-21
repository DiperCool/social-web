using System.Linq;
using Project.Models.Db;
using Web.Models.Entity;
using Web.Models.Interfaces;

namespace Web.Infrastructure.validation
{
    public class Validation : IValidation
    {
        private Context _context;
        public Validation(Context context)
        {
            _context=context;
        }
        public bool isUsedLogin(string login)
        {
            User user= _context.Users.FirstOrDefault(x=>x.Login==login);
            if(user==null) return false;
            return true;
        }

        public bool GenderCheck(string genderType){
            return genderType=="Мужик"||genderType=="Женщина"
            ||genderType=="custom"
            ||genderType=="Предпочитаю не указывать";
        }
    }
}