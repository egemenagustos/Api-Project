﻿using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();
            CreateMap<ServiceAddAto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();

            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
        }
    }
}
