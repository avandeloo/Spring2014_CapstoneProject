using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Electric_Campus_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBaseRepository<Core.Models.Electric_Campus>
    {

        public int Create(Core.Models.Electric_Campus entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TOTAL_CAMPUS_ELECTRICITY.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Electric_Campus> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusElectricityList = new List<Electric_Campus>();
                    for (int i = 0; i < totalCampusElectricityList.Count; i++)
                    {
                        ctx.TOTAL_CAMPUS_ELECTRICITY.Add(totalCampusElectricityList[i]);

                    }
                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Update(Core.Models.Electric_Campus entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusElectricity = ctx.TOTAL_CAMPUS_ELECTRICITY.FirstOrDefault(x => x.Id == entity.Id);
                    if (totalCampusElectricity == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    totalCampusElectricity.Id = entity.Id;
                    totalCampusElectricity.Reading = entity.Reading;
                    totalCampusElectricity.ReadingDateTime = entity.ReadingDateTime;
                    totalCampusElectricity.Status = entity.Status;
                    totalCampusElectricity.TimeStamp = entity.TimeStamp;
                    totalCampusElectricity.TimeStep = entity.TimeStep;

                    ctx.Entry(totalCampusElectricity).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.Electric_Campus Get(DateTime dateTime)
        {
            var totalCampusElectricity = new Electric_Campus();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusElectricity = ctx.TOTAL_CAMPUS_ELECTRICITY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totalCampusElectricity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Electric_Campus> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusElectricityList = new List<Electric_Campus>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusElectricityList = ctx.TOTAL_CAMPUS_ELECTRICITY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return totalCampusElectricityList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }


       
    }
}
