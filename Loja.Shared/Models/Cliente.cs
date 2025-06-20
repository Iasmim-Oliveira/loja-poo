﻿namespace Loja.Shared.Models;

public class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Celular { get; set; }
    public string? Email { get; set; }

    public override string ToString()
    {
        return $"ID-{Id.ToString("D3")}, Nome - {Nome}, - CPF{Cpf}";
    }
}
