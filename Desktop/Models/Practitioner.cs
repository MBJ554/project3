using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class Practitioner
    {

        public int Id
        {
            get;
            set;
        }
        public int PersonTypeId
        {
            get;
            set;
        }
        public int ClinicId
        {
            get;
            set;
        }
        public int PractitionerId
        {
            get;
            set;
        }
      
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string PhoneNo
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
       


        public Practitioner(int id_, int personTypeId_, int clinicId_, int practitionerId_, string firstName_, string lastName_, string phoneNo_, string email_, string password_)
        {
            this.Id = id_;
            this.PersonTypeId = 1;
            this.ClinicId = clinicId_;
            this.PractitionerId = practitionerId_;
          
            this.FirstName = firstName_;
            this.LastName = lastName_;
            this.PhoneNo = phoneNo_;
            this.Email = email_;
            this.Password = password_;
         


        }

        public Practitioner()
        {

        }


    }
}
