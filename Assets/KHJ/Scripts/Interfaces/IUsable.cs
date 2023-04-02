public interface IUsable
{
    bool IsUsed
    {
        get;
    }

    void Use(Bee player);
}
