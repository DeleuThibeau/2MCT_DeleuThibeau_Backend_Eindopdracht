using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EindopdrachtBackEnd.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> GetDevice(int deviceId);
        Task<List<Device>> GetDevices();
    }

    public class DeviceRepository : IDeviceRepository
    {
        private IAnimeContext _context;

        public DeviceRepository(IAnimeContext context)
        {
            _context = context;
        }

        public async Task<List<Device>> GetDevices()
        {
            try
            {
                return await _context.Devices.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<Device> GetDevice(int deviceId)
        {
            return await _context.Devices.Where(o => o.DeviceId == deviceId).SingleOrDefaultAsync();
        }
    }
}
