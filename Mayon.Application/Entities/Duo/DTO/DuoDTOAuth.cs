﻿namespace Mayon.Application.Entities.Duo.DTO;

public class DuoDTOAuth
{
    public int Id { get; set; }
    public string ApiHostName { get; set; }
    public string IntegrationKey { get; set; }
    public string SecretKey { get; set; }
}