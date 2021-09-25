using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketSystem.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        /// <summary>
        /// 取得符合的Entity並轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="filter">篩選條件</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns></returns>
        List<TViewModel> GetListToViewModel<TViewModel>(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// 取得某條件下某一筆Entity並轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="filter">篩選條件</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns></returns>
        TViewModel GetSpecificDetailToViewModel<TViewModel>(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// 依照某ViewModel的值，產生對應的Entity並且新增到資料庫
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel);
        /// <summary>
        /// 依照某ViewModel的值，更新對應的Entity
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="filter"></param>
        void UpdateViewModelToDatabase<TViewModel>(TViewModel viewModel, object id);
        /// <summary>
        /// 刪除某一Entity
        /// </summary>
        /// <param name="filter"></param>
        void Delete(Expression<Func<T, bool>> filter);
    }
}
