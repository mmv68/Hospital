using System.Collections.Generic;
using System.Threading.Tasks;
using HMS.Entities.App;
using HMS.ViewModels.App;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Services.Contracts.App
{
    /// <summary>
    /// واسط سرویس اطلاعات پایه سامانه <see cref="IBaseInformationService" />
    /// </summary>
    public interface IBaseInformationService
    {
        /// <summary>
        /// افزودن اطلاعات پایه سامانه
        /// </summary>
        /// <param name="baseInformation"> موجودیت اطلاعات پایه <see cref="FindLastbaseInformation"/></param>
        Task AddNewBaseInformation(BaseInformation baseInformation);

        /// <summary>
        /// بازیابی اطلاعات پایه سامانه
        /// </summary>
        /// <returns> لیست اطلاعات پایه سامانه <see cref="IReadOnlyList{BaseInformation}"/></returns>
        JsonResult GetBaseInformations(int? id);

        /// <summary>
        /// بازیابی اطلاعات سامانه بر اساس شناسه عنوان
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه عنوان بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <returns> لیستی از اطلاعات پایه <see>
        ///         <cref>Task{IList{object}}</cref>
        ///     </see>
        /// </returns>
        IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId);

        /// <summary>
        /// بازیابی اطلاعات سامانه بر اساس شناسه عنوان و شناسه والد
        /// </summary>
        /// <param name="baseInformationHeaderId"> شناسه عنوان بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <param name="parentId"> شناسه والد بازیابی اطلاعات پایه سامانه <see cref="int"/></param>
        /// <returns> لیستی از اطلاعات پایه <see><cref>Task{IList{object}}</cref></see>
        /// </returns>
        IReadOnlyList<SelectedListBaseInformation> SelectListBaseInformations(int baseInformationHeaderId, int parentId);

        SelectedListBaseInformation FindLastBaseInformation(int id);
    }
}
