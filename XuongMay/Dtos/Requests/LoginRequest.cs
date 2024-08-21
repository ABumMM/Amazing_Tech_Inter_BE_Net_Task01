﻿using System.ComponentModel.DataAnnotations;

namespace XuongMay.Dtos.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
