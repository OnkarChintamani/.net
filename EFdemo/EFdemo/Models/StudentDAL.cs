using EFdemo.Data;

namespace EFdemo.Models
{
    public class StudentDAL
    {
        private ApplicationDbContext db;

        public StudentDAL( ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Student> GetStudents()
        {
            return  db.Students.ToList();
        }
        public Student GetStudentByRollNo(int rollno)
        {
            var model = db.Students.Where(x => x.RollNo == rollno).SingleOrDefault();
            return model;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students.Add(student);
            result= db.SaveChanges();
            return result;
        }

        public int EditStudent(Student stud) 
        {
            int result = 0;
            var model = db.Students.Where(x => x.RollNo == stud.RollNo).SingleOrDefault();
            if (model != null)
            {
                model.RollNo = stud.RollNo;
                model.Name = stud.Name;
                model.Marks = stud.Marks;
                result = db.SaveChanges();

            }
            return result;
        }
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            var model = db.Students.Where(x => x.RollNo == rollno).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Students.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
