using Coral.Application.Commons.Repositories;
using Coral.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Infrastructure.Persistent.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Tag> _tags;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
            _tags = context.Tags;
        }

        public async Task<Tag> AddAsync(Tag tag, CancellationToken cancellation)
        {
            if(tag != null)
            {
                await _tags.AddAsync(tag, cancellation);
                await _context.SaveChangesAsync(cancellation);
            }
            var result = await _tags.FirstOrDefaultAsync(t => t.Name.Equals(tag!.Name));
            return result!;
        }

        public Task<bool> DeleteTagAsync(string name, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindAsync(string name, CancellationToken cancellation)
        {
            var response = await _tags.FirstOrDefaultAsync(x => x.Name.Equals(name));
            if (response is not null)
            {
                return true;
            }
            return false;
        }

        public Task<IEnumerable<Tag>> GetTagsAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTagByNameAsync(string name, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> UpdateTagAsync(string name, int categoryId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
