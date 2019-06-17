namespace HMS.Entities.App
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AuditableEntity;

    /// <summary>
    /// اطلاعات پایه سیستم جهت ورودی های چند مقداری و تعیین دسترسی کاربران
    /// </summary>
    public class BaseInformation : IAuditableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseInformation"/> class.
        /// </summary>
        public BaseInformation()
        {
            this.Children = new HashSet<BaseInformation>();
            this.PersonBrithPlaceProviance = new HashSet<Person>();
            this.PersonBrithPlaceCity = new HashSet<Person>();
            this.PersonRelation = new HashSet<Person>();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ParentId
        /// </summary>
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public short? Value { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        [StringLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Parent
        /// </summary>
        public virtual BaseInformation Parent { get; set; }

        /// <summary>
        /// Gets or sets the Children
        /// </summary>
        [InverseProperty("Parent")]
        public virtual ICollection<BaseInformation> Children { get; set; }

        /// <summary>
        /// Gets or sets the PersonBrithPlaceProviance
        /// </summary>
        [InverseProperty("BrithPlaceProviance")]
        public virtual ICollection<Person> PersonBrithPlaceProviance { get; set; }

        /// <summary>
        /// Gets or sets the PersonBrithPlaceCity
        /// </summary>
        [InverseProperty("BrithPlaceCity")]
        public virtual ICollection<Person> PersonBrithPlaceCity { get; set; }

        /// <summary>
        /// Gets or sets the PersonRelation
        /// </summary>
        [InverseProperty("Relation")]
        public virtual ICollection<Person> PersonRelation { get; set; }
    }
}
