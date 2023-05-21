using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Khuôn mẫu CRUD Business, áp dụng với kiểu dữ liệu cụ thể
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStandardBus<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Lấy 1 đối tượng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="obj"></param>
        void Post(T obj);

        /// <summary>
        /// Sửa 1 đối tượng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newObj"></param>
        void Put(int id, T newObj);

        /// <summary>
        /// Xoá 1 đối tượng
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
