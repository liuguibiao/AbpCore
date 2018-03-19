using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCore.Project.Dto
{
    public class QueryPageBaseInput : PagedResultRequestDto, ISortedResultRequest
    {
        /// <summary>
        /// 全局搜索参数
        /// </summary>
        public string Search { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sorting { get; set; }
        /// <summary>
        /// 升序或降序  asc、desc
        /// </summary>
        public string Order { get; set; }
    }
}
