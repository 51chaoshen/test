using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SPAVUE
{
	[Table("CommonAttachment")]
	public class Attachment:FullAuditedEntity<string>
	{
		///// <summary>
		///// 附件ID
		///// </summary>
		
		//public string AttachmentId
		//{
		//	get;
		//	set;
		//}



		/// <summary>
		/// 附件名称
		/// </summary>
		
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// 附件存储的相对地址
		/// </summary>		
		
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// 后缀名
		/// </summary>
		
		public string Extenson
		{
			get;
			set;
		}

		/// <summary>
		/// 关联数据主键
		/// </summary>
		
		public string SourceId
		{
			get;
			set;
		}

		/// <summary>
		/// 文件大小（单位 M） 
		/// </summary> 
		
		public double? FileSize
		{
			get;
			set;
		}

		
		/// <summary>
		/// 备注
		/// </summary>
	
		public string Remark
		{
			get;
			set;
		}
	}
}
