using System;
using AutoMapper;
using MinhaPerformance.Dtos;
using MinhaPerformance.Models;

namespace MinhaPerformance.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Feedback, FeedbackDto>();
			CreateMap<Criterio, CriterioDto>();

			CreateMap<ApplicationUser, ApplicationUserDto>();

			CreateMap<HistoricoFeedback, HistoricoFeedbackDto>();
			CreateMap<CreateHistoricoFeedbackDto, HistoricoFeedback>();
			CreateMap<HistoricoFeedbackCriterio, HistoricoFeedbackCriterioDto>();
			CreateMap<CreateHistoricoFeedbackCriterioDto, HistoricoFeedbackCriterio>();
		}
	}
}

