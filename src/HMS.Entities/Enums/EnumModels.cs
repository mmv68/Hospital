using System.ComponentModel.DataAnnotations;
// ReSharper disable All
namespace HMS.Entities.Enums
{
    /// <summary>
    /// وضعیت تأهل
    /// </summary>
    public enum MaritalStatus : byte
    {
        [Display(Name = "مجرد")]
        Single = 1,
        [Display(Name = "متاهل")]
        Married,
        [Display(Name = "متارکه")]
        Divorced,
        [Display(Name = "مطلقه")]
        Separate,
        [Display(Name = "فوت همسر")]
        Die

    }
    /// <summary>
    /// گروه خونی
    /// </summary>
    public enum BloodGroup : byte
    {
        [Display(Name = "A+")]
        Ap = 1,
        [Display(Name = "A-")]
        An,
        [Display(Name = "B+")]
        Bp,
        [Display(Name = "B-")]
        Bn,
        [Display(Name = "AB+")]
        Abp,
        [Display(Name = "AB-")]
        Abn,
        [Display(Name = "O-")]
        Op,
        [Display(Name = "O+")]
        On
    }
    /// <summary>
    /// جنسیت
    /// </summary>
    public enum Sex : byte
    {
        [Display(Name = "مذکر")]
        Male =1,
        [Display(Name = "مونث")]
        Female
    }
    /// <summary>
    /// مدرک تحصیلی
    /// </summary>
    public enum Certificate : byte
    {
        [Display(Name = "بی سواد")]
        A = 1,
        [Display(Name = "سیکل")]
        B,
        [Display(Name = "دیپلم")]
        C,
        [Display(Name = "کاردانی")]
        D,
        [Display(Name = "کارشناسی")]
        E,
        [Display(Name = "کارشناسی ارشد")]
        F,
        [Display(Name = "دکترا")]
        G

    }
    /// <summary>
    /// نوع دانشگاه
    /// </summary>
    public enum UniversityType : byte
    {
        [Display(Name = "آزاد")]
        A = 1,
        [Display(Name = "پیام نور")]
        B,
        [Display(Name = "دولتی")]
        C,
        [Display(Name = "علمی کاربردی")]
        D,
        [Display(Name = "غیر انتفاعی")]
        E,
        [Display(Name = "مجازی")]
        F,
        [Display(Name = "نظامی")]
        G
    }
    /// <summary>
    /// دین
    /// </summary>
    public enum Religion : byte
    {
        [Display(Name = "اسلام")]
        A = 1,
        [Display(Name = "مسیحیت")]
        B,
        [Display(Name = "یهودیت")]
        C
    }
    /// <summary>
    /// مذهب
    /// </summary>
    public enum Denomation : byte
    {
        [Display(Name = "شیعه")]
        A = 1,
        [Display(Name = "سنی")]
        B
    }
    /// <summary>
    /// ملیت
    /// </summary>
    public enum Nationality : byte
    {
        [Display(Name = "ایرانی")]
        A = 1,
        [Display(Name = "عراقی")]
        B,
        [Display(Name = "افغانی")]
        C,
        [Display(Name = "پاکستانی")]
        D
    }
    /// <summary>
    /// خدمت نظام وظیفه
    /// </summary>
    public enum Military : byte
    {      
        [Display(Name = "حین خدمت سربازی")]
        A = 1,       
        [Display(Name = "پایان خدمت")]
        B,      
        [Display(Name = "معافیت تحصیلی")]
        D,
        [Display(Name = "معافیت کفالت")]       
        E,
        [Display(Name = "معافیت موارد خاص")]    
        F,
        [Display(Name = "معافیت پزشکی")]
        G = 1,
        [Display(Name = "دفترچه خدمت")]
        H,
        [Display(Name = "دفترچه خدمت  با مهر غیبت")]
        I
    }
    /// <summary>
    /// نوع ازدواج و طلاق
    /// </summary>
    public enum MarriageDivorce : byte
    {
        [Display(Name = "ازدواج")]
        Marriage = 1,
        [Display(Name = "طلاق")]
        Divorce
    }
    /// <summary>
    /// نسبت خانوادگی
    /// </summary>
    public enum Family : byte
    {
        [Display(Name = "پدر")]
        Father = 1,
        [Display(Name = "مادر")]
        Moder,
        [Display(Name = "برادر")]
        Brother,
        [Display(Name = "خواهر")]
        Sister,
        [Display(Name = "همسر")]
        Hosband,
        [Display(Name = "فرزند")]
        Child
    }
    /// <summary>
    /// وضعیت پرونده
    /// </summary>
    public enum FolderType : byte
    {
        [Display(Name = "اولیه")]
        A = 1,
        [Display(Name = "تبدیل")]
        B,
        [Display(Name = "تمدید")]
        C
    }
    /// <summary>
    /// نتیجه پرونده
    /// </summary>
    public enum FolderResult : byte
    {
        [Display(Name = "قبول")]
        A = 1,
        [Display(Name = "مردود")]
        B,
        [Display(Name = "نظر ارزیاب")]
        C
    }
    /// <summary>
    /// مرحله وظیفه
    /// </summary>
    public enum TaskSection : byte
    {
        [Display(Name = "شروع")]
        A = 1,
        [Display(Name = "پایان")]
        B
    }
}
