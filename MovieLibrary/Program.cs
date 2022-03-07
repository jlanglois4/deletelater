using System;
using System.Collections.Generic;
using System.IO;


namespace MovieLibrary
{
    internal static class Program
    {
        
        static string file = "..\\MovieLibrary\\MovieLibrary\\movies.csv";
        private static string pickedChoice;
       private static MovieFile movieFile = new MovieFile(file);
        
        
        
        // Allows selection for the user to choose from
        public static void Main(string[] args)
        {
            var choice = true;
            do
            {
                MainMenu();
                switch (pickedChoice)
                {
                    case "1":
                        ListMovies(); //Read();
                        break;
                    case "2":
                        AddMovie(); //AddMovie();
                        break;
                    default:
                        choice = false;
                        break;
                }
            } while (choice);
        }

        // Allows you to enter an option for Main to run
        private static void MainMenu()
        {
            Console.WriteLine("1) List movies.");
            Console.WriteLine("2) Add movie.");
            Console.WriteLine("Enter anything else to exit.");
            pickedChoice = Console.ReadLine();
        }



        private static void ListMovies()
        {
            List<String> list = new();
            
            
            // Display All Movies
            
            for (int i = 0; i < movieFile.Movies.Count; i++)
            {
                list.Add(movieFile.Movies.ToString());
            }

            int index = 0;
            int anotherTen = 10;
            while (list.Count != index)
            {
                if (index < (list.Count - 10))
                {
                    for (int i = index; i < (anotherTen); i++)
                    {
                        Console.WriteLine(list[i]);
                        index += 1;
                    }

                    anotherTen = index + 10;
                    Console.WriteLine("Enter 1 to exit. Enter anything else to continue.");
                    var lineRead = Console.ReadLine();

                    if (lineRead.Equals("1"))
                    {
                        index = list.Count;
                        Console.WriteLine("Exit.");
                    }
                    else
                    {
                        Console.WriteLine("Continue.");
                    }
                }
                else
                {
                    anotherTen = (list.Count - index);


                    for (int i = 0; i < anotherTen; i++)
                    {
                        Console.WriteLine(list[i + index]);
                    }

                    index = list.Count;
                }
            }
        }

        private static void AddMovie()
        {
            // Add movie
            Movie movie = new Movie();
            // ask user to input movie title
            Console.WriteLine("Enter movie title");
            // input title
            movie.title = Console.ReadLine();
            // verify title is unique
            if (movieFile.isUniqueTitle(movie.title)){
                // input genres
                string input;
                do
                {
                    // ask user to enter genre
                    Console.WriteLine("Enter genre (or done to quit)");
                    // input genre
                    input = Console.ReadLine();
                    // if user enters "done"
                    // or does not enter a genre do not add it to list
                    if (input != "done" && input.Length > 0)
                    {
                        movie.genres.Add(input);
                    }
                } while (input != "done");
                // specify if no genres are entered
                if (movie.genres.Count == 0)
                {
                    movie.genres.Add("(no genres listed)");
                }
                // add movie
                movieFile.AddMovie(movie);
            }
            else
            {
                Console.WriteLine("Movie title already exists\n");
            }

        }


    }
}

