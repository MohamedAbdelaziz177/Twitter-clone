using Twitter.Exceptions;
using Twitter.Model;
using Twitter.Unit_of_work;

namespace Twitter.Services.BlockService_dir
{
    public class BlockService : IBlockService
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

            var Blocked = await unitOfWork.UserRepo.GetAsync(u => u.Id == BlockerId);

            if (Blocked == null)
                throw new NotFoundException("The blocked user is not found");

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
