using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Custom_Validation
{
    public class CheckRequiredAttribute:ValidationAttribute, System.Web.Mvc.IClientValidatable
    {


        public override bool IsValid(object value)
        {
            try
            {
                bool flag = (bool)value;
                return flag;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule myrule = new ModelClientValidationRule();
            myrule.ErrorMessage = base.ErrorMessage;
            myrule.ValidationType = "chkreq";
            return new ModelClientValidationRule[] { myrule };
        }
    }
}