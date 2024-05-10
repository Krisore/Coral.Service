using Coral.Application.Commons.Repositories;
using Coral.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteTagAsync(string name, CancellationToken cancellation)
        {
            var category = await _tags.FirstOrDefaultAsync(x => x.Name.Equals(name));
            if (category is null) return false;
            _tags.Remove(category);
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<IEnumerable<Tag>> GetTagsAsync(CancellationToken cancellation) => 
            await _tags.Select(x =>
                   new Tag()
                   {
                       Id = x.Id,
                       Name = x.Name

                   }).ToListAsync();
        public async Task<Tag> GetTagByNameAsync(string name, CancellationToken cancellation)
        {
            var tag = await _tags.Select(x => new Tag()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description

            }).FirstOrDefaultAsync(x => x.Name.Equals(name));
            if(tag is null|| string.IsNullOrEmpty(tag.Name)) return new Tag();
            return tag;
        }

        public async Task<Tag> UpdateTagAsync(Tag tag, CancellationToken cancellation)
        {
            var tagToUpdate = await _tags.FirstOrDefaultAsync(x => x.Id.Equals(tag.Id));
            if(tagToUpdate != null)
            {
                tagToUpdate.Name = tag.Name.ToUpper();
                tagToUpdate.Description = string.IsNullOrEmpty(tag.Description)? tagToUpdate.Description : tag.Description;
                _tags.Update(tagToUpdate);
                await _context.SaveChangesAsync();
            }
            return tagToUpdate!;
        }
    }
}
