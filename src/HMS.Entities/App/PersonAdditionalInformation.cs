using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Entities.Enums;

namespace HMS.Entities.App
{
    public class PersonAdditionalInformation
    {
        [Key,ForeignKey("Person")]
        public int PersonId { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public short? Weight { get; set; }
        public short? Height { get; set; }
        public short? ShoeSize { get; set; }
        public short? Wrist { get; set; }
        public short? ClothingSize { get; set; }
        public short? CoverSize { get; set; }
        public short? PantsSize { get; set; }
        public virtual Person Person { get; set; }

    }
}