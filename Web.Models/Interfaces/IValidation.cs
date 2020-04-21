namespace Project.Models.Interfaces
{
    public interface IValidation
    {
         bool isUsedLogin(string login);
         bool GenderCheck(string gender);
    }
}