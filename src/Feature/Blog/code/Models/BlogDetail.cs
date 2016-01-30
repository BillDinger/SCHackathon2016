using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Blog.Models
{
    using Glass.Mapper.Sc.Fields;
    using Sitecore.Feature.Blog.Domain.Templates;
    using Sitecore.Links;

    public class BlogDetail : IBlogDetail
    {
        //public ILinkManager Manager { get; set; }

        public BlogDetail(IBlogDetail detail)
        {
            Id = detail.Id;
            TemplateId = detail.TemplateId;
            BlogDetailDate = detail.BlogDetailDate;
            BlogDetailTitle = detail.BlogDetailTitle;
            BlogDetailAbstract = detail.BlogDetailAbstract;
            BlogDetailBody = detail.BlogDetailBody;
            BlogDetailImage = detail.BlogDetailImage;
            Category = detail.Category;
           // Manager = manager;
        }

        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public DateTime BlogDetailDate { get; set; }
        public string BlogDetailTitle { get; set; }
        public string BlogDetailAbstract { get; set; }
        public string BlogDetailBody { get; set; }
        public Image BlogDetailImage { get; set; }
        public IEnumerable<IBlogCategory> Category { get; set; }
    }
}