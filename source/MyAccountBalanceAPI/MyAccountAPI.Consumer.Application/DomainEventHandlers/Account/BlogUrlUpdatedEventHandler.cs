using MyAccountAPI.Domain.Exceptions;
using MyAccountAPI.Domain.Model.Blogs;
using MyAccountAPI.Domain.Model.Blogs.Events;
using MediatR;
using System;

namespace MyAccountAPI.Consumer.Application.DomainEventHandlers.Blogs
{
    public class BlogUrlUpdatedEventHandler : IRequestHandler<BlogUrlUpdatedDomainEvent>
    {
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;
        private readonly IBlogWriteOnlyRepository blogWriteOnlyRepository;

        public BlogUrlUpdatedEventHandler(
            IBlogReadOnlyRepository blogReadOnlyRepository,
            IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
            this.blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }
        public void Handle(BlogUrlUpdatedDomainEvent domainEvent)
        {
            Blog blog = blogReadOnlyRepository.GetBlog(domainEvent.AggregateRootId).Result;

            if (blog.Version != domainEvent.Version)
                throw new TransactionConflictException(blog, domainEvent);

            blog.Apply(domainEvent);
            blogWriteOnlyRepository.UpdateBlog(blog).Wait();
        }
    }
}
