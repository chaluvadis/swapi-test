using System;
using System.Threading.Tasks;

namespace StarWars.Web.Brokers
{
    public interface IStorageBroker<T>
    {
        Task AddEntity(T t);
    }
}