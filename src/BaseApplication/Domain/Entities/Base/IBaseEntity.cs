namespace Domain.Entities.Base
{
    public interface IBaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
