using System.Threading.Tasks;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public interface IPeopleService
    {
        Task AddPeopleToStarWarsWorld(People people);
    }
}