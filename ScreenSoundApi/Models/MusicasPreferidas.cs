﻿namespace ScreenSoundApi.Models;
using System.Text.Json;
internal class MusicasPreferidas
{
    public string? Nome { get;  }
    public List<Musica> ListaDeMusicasFavoritas { get; }


    public MusicasPreferidas(string nome) {
        Nome = nome;   
        ListaDeMusicasFavoritas = new List<Musica>();
    }


    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas de {Nome}");
        foreach (var musica in ListaDeMusicasFavoritas) {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }

        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaDeMusicasFavoritas,

        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
    }
}
