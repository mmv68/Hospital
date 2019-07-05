using System.ComponentModel.DataAnnotations;
using HMS.Entities.Enums;

namespace HMS.ViewModels.App
{
    public class PersonAdditionalInformationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "شناسه فرد")]
        public int PersonId { get; set; }
        [Display(Name = "گروه خونی")]
        public BloodGroup? BloodGroup { get; set; }
        [Display(Name = "رنگ مو")]
        public string HairColor { get; set; }
        [Display(Name = "رنگ چشم")]
        public string EyeColor { get; set; }
        [Display(Name = "وزن")]
        [Range(30,200,ErrorMessage = "لطفا بادقت بیشتری وزن را وارد نمایید!")]
        [RegularExpression("\\d+",ErrorMessage = "لطفا وزن را به عدد وارد نمایید!")]
        public short? Weight { get; set; }
        [Display(Name = "قد")]
        [Range(30, 200, ErrorMessage = "لطفا بادقت بیشتری قد را وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا قد را به عدد وارد نمایید!")]
        public short? Height { get; set; }
        [Display(Name = "سایز کفش")]
        [Range(30, 200, ErrorMessage = "لطفا سایز کفش را بادقت بیشتری وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا سایز کفش را به عدد وارد نمایید!")]
        public short? ShoeSize { get; set; }
        [Display(Name = "سایز دور مچ")]
        [Range(30, 200, ErrorMessage = "لطفا سایز دور مچ را بادقت بیشتری وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا سایز دور مچ را به عدد وارد نمایید!")]
        public short? Wrist { get; set; }
        [Display(Name = "سایز لباس")]
        [Range(30, 200, ErrorMessage = "لطفا سایز لباس را بادقت بیشتری وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا سایز لباس را به عدد وارد نمایید!")]
        public short? ClothingSize { get; set; }
        [Display(Name = "سایز روپوش")]
        [Range(30, 200, ErrorMessage = "لطفا سایز روپوش را بادقت بیشتری وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا سایز روپوش را به عدد وارد نمایید!")]
        public short? CoverSize { get; set; }
        [Display(Name = "سایز شلوار")]
        [Range(30, 200, ErrorMessage = "لطفا سایز شلوار را بادقت بیشتری وارد نمایید!")]
        [RegularExpression("\\d+", ErrorMessage = "لطفا سایز شلوار را به عدد وارد نمایید!")]
        public short? PantsSize { get; set; }
    }
}
