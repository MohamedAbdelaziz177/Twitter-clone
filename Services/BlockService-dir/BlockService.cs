using Twitter.Exceptions;
using Twitter.Model;
using Twitter.Unit_of_work;

namespace Twitter.Services.BlockService_dir
{
    public class BlockService
    {
        private readonly IUnitOfWork unitOfWork;

        public BlockService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task BlockUser(string BlockerId, string BlockedId)
        {
            Block block = new();

            block.BlockerId = BlockerId;
            block.BlockedId = BlockedId;

            await unitOfWork.BlockRepo.InsertAsync(block);
        }

        public async Task UnblockUser(string BlockerId, string BlockedId)
        {
            Block? block = await unitOfWork.BlockRepo.GetByBlockerAndBlocked(BlockerId, BlockedId);

            if (block == null) 
                throw new NotFoundException("You didnt='t block this user");

            await unitOfWork.BlockRepo.DeleteAsync(block.Id);
        }
    }
}
