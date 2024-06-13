using ScreenSoundApi.Models;
using System.Text.Json;
using ScreenSoundApi.Filters;


using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://" +
            "guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        // Utilizando Filtros
        LinqFilter.FiltrarMusicasPelaTonalidade(musicas, "C#");
        LinqFilter.FiltrarTodosGenerosMusicais(musicas);
        LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Red Hot Chili Peppers");


        // instanciando uma classe e adicionando musicas
        var musicasPreferidasDoLeo = new MusicasPreferidas("Leo");
        musicasPreferidasDoLeo.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoLeo.AdicionarMusicasFavoritas(musicas[2]);
        musicasPreferidasDoLeo.AdicionarMusicasFavoritas(musicas[3]);
        musicasPreferidasDoLeo.AdicionarMusicasFavoritas(musicas[4]);
        musicasPreferidasDoLeo.AdicionarMusicasFavoritas(musicas[5]);

        musicasPreferidasDoLeo.ExibirMusicasFavoritas();


        var musicasPreferidasDoUser = new MusicasPreferidas("User");
        musicasPreferidasDoUser.AdicionarMusicasFavoritas(musicas[6]);
        musicasPreferidasDoUser.AdicionarMusicasFavoritas(musicas[7]);
        musicasPreferidasDoUser.AdicionarMusicasFavoritas(musicas[8]);
        musicasPreferidasDoUser.AdicionarMusicasFavoritas(musicas[9]);
        musicasPreferidasDoUser.AdicionarMusicasFavoritas(musicas[10]);

        musicasPreferidasDoUser.ExibirMusicasFavoritas();

        //criando um arquivo Json
        musicasPreferidasDoUser.GerarArquivoJson();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}

