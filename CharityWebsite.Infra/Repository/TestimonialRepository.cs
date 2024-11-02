using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Repository
{//hgfd
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext dBContext;
        public TestimonialRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Testimonial> GetAllTestimonials()
        {
            IEnumerable<Testimonial> result = dBContext.Connection.Query<Testimonial>(
                "TESTIMONIAL_PACKAGE.Get_All_Testimonials",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetTestimonialById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_id", id, DbType.Int32, ParameterDirection.Input);

            var result = dBContext.Connection.Query<Testimonial>(
                "TESTIMONIAL_PACKAGE.Get_Testimonial_By_Id",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        //public void CreateTestimonial(Testimonial testimonial)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("p_status", testimonial.Status, DbType.String, ParameterDirection.Input);
        //    parameters.Add("p_user_id", testimonial.Userid, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("p_content", testimonial.Content, DbType.String, ParameterDirection.Input);

        //    dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.Create_Testimonial", parameters, commandType: CommandType.StoredProcedure);
        //}
        public void CreateTestimonial(Testimonial testimonial)
        {
            var parameters = new DynamicParameters();

            // Set status to "Pending" if not provided
            string status = string.IsNullOrEmpty(testimonial.Status) ? "Pending" : testimonial.Status;
            parameters.Add("p_status", status, DbType.String, ParameterDirection.Input);

            parameters.Add("p_user_id", testimonial.Userid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_content", testimonial.Content, DbType.String, ParameterDirection.Input);

            dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.Create_Testimonial", parameters, commandType: CommandType.StoredProcedure);
        }


        //public void UpdateTestimonial(Testimonial testimonial)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("p_id", testimonial.Testimonalid, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("p_new_status", testimonial.Status, DbType.String, ParameterDirection.Input);
        //    parameters.Add("p_new_content", testimonial.Content, DbType.String, ParameterDirection.Input);

        //    dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.Update_Testimonial", parameters, commandType: CommandType.StoredProcedure);
        //}

        public void UpdateTestimonial(Testimonial testimonial)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_id", testimonial.Testimonalid, DbType.Int32, ParameterDirection.Input);

            // Update status only if a new status is provided
            string status = string.IsNullOrEmpty(testimonial.Status) ? "Pending" : testimonial.Status;
            parameters.Add("p_new_status", status, DbType.String, ParameterDirection.Input);

            parameters.Add("p_new_content", testimonial.Content, DbType.String, ParameterDirection.Input);

            dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.Update_Testimonial", parameters, commandType: CommandType.StoredProcedure);
        }


        public void DeleteTestimonial(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_id", id, DbType.Int32, ParameterDirection.Input);

            dBContext.Connection.Execute("TESTIMONIAL_PACKAGE.Delete_Testimonial", parameters, commandType: CommandType.StoredProcedure);
        }




    }
}
