using System;
using System.ComponentModel.DataAnnotations;

namespace CMXAPI.Model
{
	public class Document
	{
		[Key]
		public int Id { set; get; }

		
		public required string PolicyNum { get; set; }

		public required string FileNume { get; set; }

		public required string FilePath { get; set; }
	}
}

