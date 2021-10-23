using Microsoft.EntityFrameworkCore;

namespace FilmDB.Models
{
    public class FilmManager : IFilmManager
    {
        private readonly FilmContext context;

        public FilmManager(FilmContext context)
        {
            this.context = context;
        }

        public FilmManager AddFilm(FilmModel filmModel)
        {
            context.Add(filmModel);
            context.SaveChanges();
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var film = context.Films.Where(x => x.Id == id).FirstOrDefault();
            if (film != null)
            {
                context.Films.Remove(film);
            }
            context.SaveChanges();
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            var entity = context.Films.Attach(filmModel);
            entity.State = EntityState.Modified;
            context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var film = context.Films.Where(x => x.Id == id).FirstOrDefault();
            if(film != null)
            {
                film.Title = newTitle;
                var entity = context.Films.Attach(film);
                entity.State = EntityState.Modified;
                context.SaveChanges();

            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            return context.Films.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<FilmModel> GetFilms()
        {
            return context.Films.ToList();
        }
    }
}
