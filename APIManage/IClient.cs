using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManage
{
    public interface IClient
    {
        /// <summary>
        /// 执行API请求
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="request">具体的请求</param>
        /// <returns>对象</returns>
        T Execute<T>(IRequest<T> request) where T : Response;
    }
}
