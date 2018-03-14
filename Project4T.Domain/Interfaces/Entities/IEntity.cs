namespace Project4T.Domain.Interfaces.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }  
}
