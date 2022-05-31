using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieEntity.Models
{
	public class ThreaterModel
	{
		[Key]
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ThreaterId { get; set; }
		public string ThreaterName { get; set; }
		public string ThreaterLocation { get; set; }

		public int ThreaterCapacity { get; set; }
		public ThreaterModel()
		{
		}
	}
}

