﻿using System.ComponentModel.DataAnnotations;

namespace exemploAPI.DTOs
{
    public class FornecedorDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}

