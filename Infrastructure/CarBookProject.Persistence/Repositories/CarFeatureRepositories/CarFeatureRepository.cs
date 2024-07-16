using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task ChangeCarFeatureAvailableToFalse(int id)
        {
            var value = await _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefaultAsync();

            value.Available = false;

            await _context.SaveChangesAsync();
        }

        public async Task ChangeCarFeatureAvailableToTrue(int id)
        {
            var value =await _context.CarFeatures.Where(x=>x.CarFeatureID==id).FirstOrDefaultAsync();

            value.Available= true;

            await _context.SaveChangesAsync();
        }

        public async Task CreateCarFeatureByCar(CarFeature carFeature)
        {
            var value = await _context.CarFeatures.Where(x => x.CarID == carFeature.CarID && x.FeatureID == carFeature.FeatureID).FirstOrDefaultAsync();

            if(value is null)
            {
                await _context.CarFeatures.AddAsync(carFeature);

                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarID(int carID)
        {
            var values=await _context.CarFeatures.Include(z=>z.Feature).Where(x=>x.CarID==carID).ToListAsync();

            return values;
        }
    }
}
