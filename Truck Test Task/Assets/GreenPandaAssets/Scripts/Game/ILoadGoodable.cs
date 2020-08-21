public interface ILoadGoodable 
{
    bool IsVisited { get; }
    bool IsLoading { get; }
    void StartLoadGoods();
    void LoadComplete();
}