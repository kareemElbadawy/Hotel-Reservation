using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain
{
	public abstract class BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? ModificationDate { get; set; }
		public string? CreatedBy { get; set; }
		public string? ModifyiedBy { get; set; }
		public string? CreatedByTeam { get; set; }
		public string? ModifyiedByTeam { get; set; }
		public bool? IsDeleted { get; set; } = false;
		public bool? IsEnabled { get; set; }

		/// <summary>
		/// constructor
		/// </summary>
		protected BaseEntity()
		{
			CreationDate = DateTime.Now.ToLocalTime();
			IsEnabled = true;
			IsDeleted = false;
		}
	}
}
