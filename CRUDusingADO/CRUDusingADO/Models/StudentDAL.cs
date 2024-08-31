using CRUDusingADO.Models;
using System.Data.SqlClient;
namespace CRUDusingADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string connstr = this.configuration.GetConnectionString("DefaultConnetion");
            con = new SqlConnection(connstr);
        }
        // list
        public List<Student> GetStudents()
        {
            List<Student> studentlist = new List<Student>();
            string qry = "select * from student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Marks = Convert.ToDouble(dr["marks"]);
                    studentlist.Add(student);
                }
            }
            con.Close();
            return studentlist;
        }
        // add
        public int AddStudent(Student stud)
        {
            int result = 0;
            string qry = "insert into student values(@name,@marks)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@marks", stud.Marks);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //edit
        public int EditStudent(Student stud)
        {
            int result = 0;
            string qry = "update student set name=@name,marks=@marks where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@marks", stud.Marks);
            cmd.Parameters.AddWithValue("@rollno", stud.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //select single stud
        public Student GetStudentRollNo(int rollno)
        {
            Student student = new Student();
            string qry = "select * from student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Marks = Convert.ToDouble(dr["marks"]);
                }
            }
            con.Close();
            return student;
        }
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            string qry = "delete from student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
