using Coral.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Repositories
{
    public interface ITagRepository
    {
        Task<Tag> AddAsync(Tag tag, CancellationToken cancellation);
        Task<bool> FindAsync(string name, CancellationToken cancellation);
        Task<IEnumerable<Tag>> GetTagsAsync(CancellationToken cancellation);
        Task<Tag> GetTagByNameAsync(string name, CancellationToken cancellation);

        Task<bool> DeleteTagAsync(string name, CancellationToken cancellation);
        Task<Tag> UpdateTagAsync(string name, int tagId, CancellationToken cancellation);
    }
}
