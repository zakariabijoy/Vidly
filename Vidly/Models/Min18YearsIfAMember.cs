using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId== MembershipType.UnKnown||customer.MembershipTypeId== MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if(customer.BirthDate==null)
                return new ValidationResult("Enter your Birthdate");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)                                                                      //if(age>=18)
                ? ValidationResult.Success                                                              // return ValidationResult.Success;                   
                : new ValidationResult("customer should be 18 years old to go on a membership");    //else
                                                                                                    //{
                                                                                                    //    return new ValidationResult("customer sh");
                                                                                                    // }
            
                
           
        }
    }
}