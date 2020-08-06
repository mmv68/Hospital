using HMS.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HMS.Entities.App
{
    public class PersonPayment:IAuditableEntity
    {
        #region Ctor
        #endregion
        #region Peroperties
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        /// <summary>
        /// Gets or sets the شماره حساب
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the شماره کارت
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; }
        /// <summary>
        /// Gets or sets the شماره شبا
        /// </summary>
        [Column(TypeName = "varchar(26)")]
        public string ShabaNumber { get; set; }
        #region NavigationProperties
        public virtual Person Person { get; set; }
        #endregion
        #endregion
    }
}
