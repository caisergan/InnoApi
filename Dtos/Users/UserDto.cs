﻿namespace InnoApi.Dtos.Users
{
    public class UserDto
    {
        public int ID { get; set; }
        public string ADI { get; set; } = string.Empty;
        public string SOYADI { get; set; } = string.Empty;
        public string KULLANICI_ADI { get; set; } = string.Empty;
        public string SIFRE { get; set; } = string.Empty;
    }
}
