using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
