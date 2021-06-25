using School.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School.Common
{
    public class clsStudents
    {
        private SqlConnection con;
        private SchoolDBContext objDbContext = new SchoolDBContext();
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }
        public List<StudentsViewModel> GetStudentsList(int rowCount, int rowPerPage)
        {
            connection();
            List<StudentsViewModel> studentsList = new List<StudentsViewModel>();
            SqlCommand com = new SqlCommand("proc_GetEmloyeesList", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@rowCount", rowCount);
            com.Parameters.AddWithValue("@rowPerPage", rowPerPage);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            studentsList = (from DataRow dr in dt.Rows

                       select new StudentsViewModel()
                       {
                           Id = Convert.ToInt32(dr["Id"]),
                           FirstName = Convert.ToString(dr["FirstName"]),
                           LastName = Convert.ToString(dr["LastName"]),
                           Class = Convert.ToString(dr["Class"]),
                           SubjectName = Convert.ToString(dr["SubjectName"]),
                           Marks = Convert.ToDecimal(dr["Marks"]),
                           TotalRecords = Convert.ToInt32(dr["TotalRecords"]),
                       }).ToList();

            return studentsList;

        }


        public void AddStudent(Students student)
        {
            objDbContext.students.Add(student);
            objDbContext.SaveChanges();

        }

        public Students GetStudent(int id)
        {
            var student = objDbContext.students.Find(id);
            return student;
        }

        public void UpdateStudent(Students student)
        {
            var data = objDbContext.students.Find(student.StudentId);
            if (data != null)
            {
                data.FirstName = student.FirstName;
                data.LastName = student.LastName;
                data.Class = student.Class;
            }
            objDbContext.SaveChanges();
        }
    }
}