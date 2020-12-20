using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomValidationAttributeForAge : ValidationAttribute, IClientValidatable
    {
        public CustomValidationAttributeForAge(params string[] propertyNames)
        {
            this.PropertyNames = propertyNames;

        }
        public string[] PropertyNames { get; private set; }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The '{0}' field has an invalid value.", name);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = "Age Must Be 18 Plus";
            ModelClientValidationRule customagerule = new ModelClientValidationRule();
            customagerule.ErrorMessage = errorMessage;
            customagerule.ValidationType = "customage";
            yield return customagerule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value != null)
                {
                    DateTime dateTime = Convert.ToDateTime(value);
                    var date = DateTime.Today.Year - dateTime.Year;
                    if (date < 18)
                    {
                        return new ValidationResult("Age Must be 18 Plus");

                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return new ValidationResult("" + validationContext.DisplayName + " is required");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(ex.ToString());
                throw ex;
            }

        }
    }
}