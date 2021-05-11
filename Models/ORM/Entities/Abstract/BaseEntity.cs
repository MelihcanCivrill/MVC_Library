using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Library.Models.ORM.Entities.Abstract
{
    public enum Status { Active = 1, Modified = 2, Passive = 3 }
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate
        {
            get => _createDate;
            set => _createDate = value;
        }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }


        private Status _status = Status.Active;
        public Status Status
        {
            get => _status;
            set => _status = value;
        }
    }
}