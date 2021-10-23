namespace FilmDB.Models
{
    public interface IFilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel);

        public FilmManager RemoveFilm(int id);

        public FilmManager UpdateFilm(FilmModel filmModel);

        public FilmManager ChangeTitle(int id, string newTitle);

        public FilmModel GetFilm(int id);

        public List<FilmModel> GetFilms();
    }
}
