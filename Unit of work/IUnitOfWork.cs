namespace Twitter.Unit_of_work
{
    public interface IUnitOfWork
    {
        
        Task<int> CompleteAsync();
    }
}
