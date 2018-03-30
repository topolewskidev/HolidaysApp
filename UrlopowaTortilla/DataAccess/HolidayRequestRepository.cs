using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UrlopowaTortilla.Helpers;
using UrlopowaTortilla.Models;
using UrlopowaTortilla.States;

namespace UrlopowaTortilla.DataAccess
{
    public class HolidayRequestRepository
    {
        private static readonly Dictionary<string, HolidayRequestEntity> _database = new Dictionary<string, HolidayRequestEntity>();

        private readonly IDaysOffManager _daysOffManager;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public HolidayRequestRepository(IDaysOffManager daysOffManager, INotifier notifier)
        {
            _daysOffManager = daysOffManager;
            _notifier = notifier;

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HolidayRequestEntity, HolidayRequest>()
                    .ForMember(request => request.HolidayRequestStatus, m => m.ResolveUsing((entity, account) =>
                    {
                        var status = typeof(IHolidayRequestState).GetConcreteChild(entity.Status);
                        return (IHolidayRequestState)Activator.CreateInstance(status);
                    }));

                cfg.CreateMap<HolidayRequest, HolidayRequestEntity>()
                    .ForMember(request => request.Status, m => m.ResolveUsing((request, entity) => request.HolidayRequestStatus.GetType().Name));
            }));
        }

        public async Task<HolidayRequest> GetBy(string number)
        {
            var holidayRequestEntity = await GetHolidayRequestEntityBy(number);

            var holidayRequest = new HolidayRequest(holidayRequestEntity.HolidayPeriod, _notifier, _daysOffManager);
            _mapper.Map(holidayRequestEntity, holidayRequest);

            await Task.Yield(); // can do awesome async stuff here
            return holidayRequest;
        }

        public void Update(HolidayRequest request)
        {
            var holidayRequestEntity = _mapper.Map<HolidayRequestEntity>(request);

            // attach to DbContext and save
            _database[holidayRequestEntity.Number] = holidayRequestEntity;
        }

        public void Create(HolidayRequest request)
        {
            var holidayRequestEntity = _mapper.Map<HolidayRequestEntity>(request);

            // attach to DbContext and save
            _database.Add(request.Number, holidayRequestEntity);
        }

        private async Task<HolidayRequestEntity> GetHolidayRequestEntityBy(string number)
        {
            await Task.Yield();
            return _database[number];
        }
    }
}