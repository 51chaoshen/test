using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPAVUE.Dto
{
	[AutoMapFrom(typeof(Attachment))]
	public   class AttachmentDto : EntityDto<string>
	{
		//public string Id
		//{
		//	get;
		//	set;
		//}

		/// <summary>
		/// 附件存储的相对地址
		/// </summary>
	
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// 附件存储的绝对地址
		/// </summary>
		
		public string AbsoluteUrl
		{
			get;
			set;
		}

		/// <summary>
		///  附件相对路径，推荐使用
		/// </summary>
		
		public string RelativeUrl
		{
			get;
			set;
		}

		/// <summary>
		/// 附件名称
		/// </summary>
		public string Name
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
	}




	public class PagedAttachmentResultRequestDto : PagedResultRequestDto
	{
	}


	[AutoMapTo(typeof(Attachment))]
	public class CreateAttachmentDto
	{
		/// <summary>
		/// 附件存储的相对地址
		/// </summary>

		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// 附件存储的绝对地址
		/// </summary>

		public string AbsoluteUrl
		{
			get;
			set;
		}

		/// <summary>
		///  附件相对路径，推荐使用
		/// </summary>

		public string RelativeUrl
		{
			get;
			set;
		}

		/// <summary>
		/// 附件名称
		/// </summary>
		public string Name
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
	}
}
