using DBTestingProject.Models.Interfaces;

namespace DBTestingProject.Models
{
    public class MyTime : IDateTime
    {
        public DateTime Now =>  DateTime.Now;
    }
}
