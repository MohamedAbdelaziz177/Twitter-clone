namespace Twitter.Services.BlockService_dir
{
    public interface IBlockService
    {
        Task BlockUser(string BlockerId, string BlockedId);

        Task UnblockUser(string BlockerId, string BlockedId);
    }
}
