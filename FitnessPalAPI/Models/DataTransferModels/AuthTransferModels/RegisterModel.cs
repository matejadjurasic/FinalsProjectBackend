﻿using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.AuthTransferModels
{
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public GoalType GoalType { get; set; }
    }
}