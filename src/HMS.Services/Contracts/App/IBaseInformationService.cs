namespace HMS.Services.Contracts.App
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using HMS.Entities.App;
    using HMS.ViewModels.App;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// واسط سرویس اطلاعات پایه سامانه <see cref="IBaseInformationService" />
    /// </summary>
    public interface IBaseInformationService
    {
        /// <summary>
        /// افزودن اطلاعات پایه سمانه
        /// </summary>
        /// <param name="baseInformation"> موجودیت اطلاعات پایه <see cref="BaseInformation"/></param>
        void AddNewBaseInformation(BaseInformation baseInformation);

        /// <summary>
        /// بازیابی اطلاعات پایه سامانه
        /// </summary>
        /// <returns> لیست اطلاعات پایه سامنه <see cref="IReadOnlyList{BaseInformation}"/></returns>
        JsonResult GetBaseInformations(int? id);
        /// <summary>
        /// بازیابی اطلاعات پایه سامانه
        /// </summary>
        /// <returns> لیست اطلاعات پایه سامنه <see cref="IReadOnlyList{BaseInformation}"/></returns>
        IReadOnlyList<BaseInformation> GetBaseInformations();

        /// <summary>
        /// بازیابی اطلاعات پایه سامانه بر اساس شناسه
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه بازیابی اطلاعات پایه <see cref="int"/></param>
        /// <returns>  لیست انتخابی از اطلاعات پایه <see cref="Task{SelectList}"/></returns>
        Task<SelectList> SelectItemBaseInformations(int baseInformationHeaderId);

        /// <summary>
        /// بازیابی اطلاعات سامانه بر اساس شناسه و شناسه والد
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <param name="parentId"> شناسه والد بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <returns> لیست انتخابی از اطلاعات پایه <see cref="Task{SelectList}"/></returns>
        Task<SelectList> SelectItemBaseInformations(int baseInformationHeaderId, int parentId);

        /// <summary>
        /// بازیابی اطلاعات سامانه بر اساس شناسه عنوان
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه عنوان بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <returns> لیستی از اطلاعات پایه <see cref="Task{IList{object}}"/></returns>
        IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId);

        /// <summary>
        /// بازیابی اطلاعات سامانه بر اساس شناسه عنوان و شناسه والد
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه عنوان بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <param name="parentId"> شناسه والد بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <returns> لیستی از اطلاعات پایه <see cref="Task{IList{object}}"/></returns>
        IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId, int parentId);
    }
}
