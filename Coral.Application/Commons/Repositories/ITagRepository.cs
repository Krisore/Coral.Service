﻿using Coral.Application.Common.Repositories;
using Coral.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coral.Application.Commons.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<bool> FindAsync(string name, CancellationToken cancellation);
        Task<IEnumerable<Tag>> GetTagsAsync(CancellationToken cancellation);
        Task<Tag> GetTagByNameAsync(string name, CancellationToken cancellation);

        Task<bool> DeleteTagAsync(string name, CancellationToken cancellation);
        Task<Tag> UpdateTagAsync(Tag tag, CancellationToken cancellation);
    }
}
