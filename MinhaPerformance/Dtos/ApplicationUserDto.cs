using System;
namespace MinhaPerformance.Dtos
{
	public class ApplicationUserDto : DtoBase
	{
		public string UserName { get; set; }
		public string Email { get; set; }
        public string PictureURL { get; set; } = "";
    }
}

