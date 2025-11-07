using LystFiskerPortalenWEB.Models;

namespace LystFiskerPortalenWEB.Repo
{
    public class PostRepo
    {
        public void CreatePost(Post post)
        {
            if (post == null)
            {
                return;
            }

            //_assignmentContext.Assignments.Add(assignment);
            //_assignmentContext.SaveChanges();
        }

        public void DeletePost(int id)
        {
            Assignment assignment = _assignmentContext.Assignments.Find(id);
            _assignmentContext.Assignments.Remove(assignment);
            _assignmentContext.SaveChanges();
        }

        public void UpdatePost()
        {
            //assignmentToUpdate.Title = assignment.Title;
            //assignmentToUpdate.Description = assignment.Description;
            //assignmentToUpdate.Subjects = assignment.Subjects;
            //_assignmentContext.SaveChanges();
        }

        public Post GetPost(int id)
        {
            return _assignmentContext.Assignments.Find(id);
        }
    }
}
