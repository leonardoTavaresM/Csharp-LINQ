
using ScreenSoundApi.Models;

namespace ScreenSoundApi.Filters;

internal class LinqFilter
{
    public static void FiltrarTodosGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero)
            .Distinct()
            .ToList();

        foreach (var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    { 
        var artistasPorGeneroMusical = musicas.Where(musica =>  musica.Genero!.Contains(genero))
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();

        Console.WriteLine($"Exibindo os artistas por gênero musical >>> {genero}");

        foreach (var artista in artistasPorGeneroMusical) {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string artista)
    { 
        var musicasDoArtista = musicas.Where(musica => musica.Artista.Equals(artista))
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine($"Exibindo as musicas artista >>> {artista}");

        foreach (var musica in musicasDoArtista) {
            Console.WriteLine($"- {musica}");
        }
    }

    public static void FiltrarMusicasPeloAno(List<Musica> musicas, int ano)
    {
        var musicasDoAno = musicas.Where(musica => musica.Ano == ano)
            .OrderBy(musicas => musicas.Nome)
            .Select(musicas => musicas.Nome)
            .Distinct()
            .ToList();
       
        Console.WriteLine($"Músicas de {ano}");
        foreach (var musica in musicasDoAno)
        {
            Console.WriteLine($"- {musica}");
        }
    }


    public static void FiltrarMusicasPelaTonalidade(List<Musica> musicas, string tonalidade)
    {
        var musicasPorTonalidade = musicas
            .Where(musica => musica.Tonalidade.Equals(tonalidade))
            .Select(musica => musica.Nome)
            .Distinct().ToList();

        Console.WriteLine($"Exibindo as musicas pela tonalidade");
        foreach(var musica in musicasPorTonalidade)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}

