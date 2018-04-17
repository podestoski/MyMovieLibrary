using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyMovieLibrary
{
    class DBConnection
    {

        private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(CONNECTION_STRING);
        SqlCommand command = new SqlCommand();
        SqlDataReader reader = null;

        public DBConnection()
        {
            command.Connection = con;
        }

        public List<Platform> getPlatforms()
        {
            List<Platform> platforms = new List<Platform>();
            con.Open();
            command.CommandText = "Select * from cat_platform";
            command.Connection = con;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Platform platform = new Platform();
                platform.id = reader.GetInt32(0);
                platform.name = reader.GetString(1);
                platforms.Add(platform);
            }
            con.Close();
            return platforms;
        }

        public int saveToLibrary(int idMovie, int idUser, string imagePath, string title)
        {
            con.Open();
            command.CommandText = String.Format("insert into rel_user_movie(idUser,idMovie,image,title) values({0},{1},'{2}','{3}')", idUser.ToString(), idMovie, imagePath, title);
            command.ExecuteNonQuery();
            int idJustInserted;
            command.CommandText = String.Format("Select id from rel_user_movie where idUser = {0} and idMovie = {1}", idUser.ToString(), idMovie);
            reader = command.ExecuteReader();
            reader.Read();
            idJustInserted = reader.GetInt32(0);
            con.Close();
            return idJustInserted;
        }

        public void insertPlatformRelation(int idUserMovie, int idPlatform)
        {
            con.Open();
            command.CommandText = String.Format("insert into rel_movie_platform(idPlatform, idRelMovieUser) values({0},{1})",idPlatform, idUserMovie);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<LibraryMovie> getMovieLibrary(int idUser)
        {
            con.Open();
            command.CommandText = String.Format("select idMovie, image, title from rel_user_movie where idUser = {0}", idUser);
            reader = command.ExecuteReader();
            List<LibraryMovie> libraryMovies = new List<LibraryMovie>();
            while (reader.Read())
            {
                libraryMovies.Add(new LibraryMovie((int)reader["idMovie"], (string)reader["title"], (string)reader["image"]));
            }
            con.Close();
            return libraryMovies;

        }

    }
}
