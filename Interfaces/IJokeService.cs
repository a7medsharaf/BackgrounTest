using BackgrounTest.Models;

namespace BackgrounTest.Interfaces
{
    public interface IJokeService
    {
        public List<JokeModel> GetJokes();
        public void UpdateJokes();
    }
}