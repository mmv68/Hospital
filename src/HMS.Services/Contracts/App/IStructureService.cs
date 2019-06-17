namespace HMS.Services.Contracts.App
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using HMS.Entities.App;
    using HMS.ViewModels.App;

    /// <summary>
    /// واسط سرویس ساختار درختی سامانه <see cref="IStructureService" />
    /// </summary>
    public interface IStructureService
    {
        /// <summary>
        /// افزودن ساختار سامانه
        /// </summary>
        /// <param name="structure"> موجودیت ساختار سامانه <see cref="Structure"/></param>
        void AddNewStructure(Structure structure);

        /// <summary>
        /// بازیابی سختار درختی سامانه
        /// </summary>
        /// <returns> لیست ساختار درختی سامانه <see cref="IList{Structure}"/></returns>
        IList<TreedListStructures> GetAllStructures(int? id);

        /// <summary>
        /// for redonly Get to improve speed
        /// </summary>
        /// <returns></returns>
        Task<SelectList> SelectItemStructures();

        /// <summary>
        /// بازیابی ساختاردرختی سامانه
        /// </summary>
        /// <returns> لیست ساختار درختی سامانه <see cref="Task{IReadOnlyList{SelectedListStructures}}"/></returns>
        IReadOnlyList<SelectedListStructures> SelectListStructures();
        string StructureCode(int id);
    }
}
