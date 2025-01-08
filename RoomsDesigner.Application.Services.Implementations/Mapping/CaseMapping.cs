﻿using AutoMapper;
using RoomsDesigner.Application.Messages;
using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Domain.Entity;

namespace RoomsDesigner.Application.Services.Implementations.Mapping
{
    public class CaseMapping : Profile
    {
        public CaseMapping()
        {                
            CreateMap<Case, CaseModel>();
            CreateMap<Case, CreateRoomMessage>();
        }
    }
}
