namespace AppTemplate.Database.Core
{
    public interface IDeactivatable
    {
        bool IsActive { get; set; }
    }
}