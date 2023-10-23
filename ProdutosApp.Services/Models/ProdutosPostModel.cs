﻿using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados para cadastro de Produtos na API
    /// </summary>
    public class ProdutosPostModel
    {
        [MinLength(8, ErrorMessage = "Por favor, digite no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, digite no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, infome o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, infome o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor, infome a quantidade do produto.")]
        public int? Quantidade { get; set; }
    }
}
