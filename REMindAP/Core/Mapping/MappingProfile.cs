using AutoMapper;
using REMindAP.Core.Domain;
using REMindAP.Core.Dto;
using REMindAP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Domain to ViewModel
            CreateMap<Reminder, ReminderViewModel>();

            //ViewModel to Domain
            CreateMap<ReminderViewModel, Reminder>()
                .ForMember(rv => rv.Notifications, opt => opt.Ignore());

            //Domain to Dto
            CreateMap<Notification, NotificationDto>();
            CreateMap<Reminder, ReminderDto>();
        }

    }
}
