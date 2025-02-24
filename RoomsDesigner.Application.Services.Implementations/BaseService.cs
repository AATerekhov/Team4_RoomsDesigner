﻿namespace RoomsDesigner.Application.Services.Implementations
{
    public class BaseService
    {
        public static string FormatFullNotFoundErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with Id {id} has not been found.";
        public static string FormatBadRequestErrorMessage(Guid id, string nameOfEntity)
            => $"The {nameOfEntity} with id: {id} is not active.";
        public static string FormatIsNoRightsErrorMessage(Guid id, string nameOfEntity)
      => $"The user {id} is no rigth: {nameOfEntity} has another owner.";
    }
}
