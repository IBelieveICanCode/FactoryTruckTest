public interface ILoadGoodable 
{
    bool IsVisited { get; }
    void StartLoadGoods(IWaitForGoodable truck);
    void LoadComplete();
}