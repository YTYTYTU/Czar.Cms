using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Sample05
{
    /// <summary>
    /// 内容实体
    /// </summary>
    public class ContentWithComment
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// neir
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modify_time { get; set; }
        public IEnumerable<Comment> comments { get; set; }
    }
}
