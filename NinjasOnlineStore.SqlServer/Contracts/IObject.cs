namespace NinjasOnlineStore.SqlServer.Contracts
{
    public interface IObject
    {
        int Id { get; set; }
        decimal Price { get; set; }
        int SizeId { get; set; }
        int ColorId { get; set; }
        int BrandId { get; set; }
        int KindId { get; set; }
        int ModelId { get; set; }
    }
}
