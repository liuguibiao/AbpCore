namespace AbpCore.Project.Web.Models.Common.Modals
{
    public class ModalHeaderViewModel
    {
        /// <summary>
        /// 模态框标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 模态框Id
        /// </summary>
        public string ModelId { get; set; }
        /// <summary>
        /// 主键ID
        /// </summary>
        public dynamic Id { get; set; }
        public ModalHeaderViewModel(string title)
        {
            Title = title;
        }
        public ModalHeaderViewModel(string title, string modelId, dynamic id)
        {
            Title = title;
            ModelId = modelId;
            Id = id;
        }
    }
}
