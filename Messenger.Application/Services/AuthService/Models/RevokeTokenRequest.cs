﻿namespace Messenger.Application.Services.AuthService.Models;

public class AuthServiceRevokeTokenRequest
{
    public required string RefreshToken { get; set; }
}
