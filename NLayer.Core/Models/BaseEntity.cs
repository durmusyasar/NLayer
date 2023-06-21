namespace NLayer.Core.Models
{
    /// <summary>
    /// Yeni bir nesne örneği oluşturulamasın diye abstract tanımlandı.
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
