using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Utilities
{
    public class Messages
    {
        public const string User_Login_Message_Notvalid = "Username or Password is wrong";
        public const string User_Email_Exists = "This email is already registered";
        public const string User_NotFound_Message = "No such user";
        public const string User_Login_Success_Message = "Login succesful";
        public const string User_Register_Success_Message = "User have been registered succesfully";
        public const string Old_Password_Wrong = "Old password is wrong";

        public const string Add_Operation_Success_Message = "The record have been added succesfully";
        public const string Add_Operation_Error_Message = "An error occured on adding record";


        public const string Update_Operation_Success_Message = "Succesfully updated";
        public const string Update_Operation_Error_Message = "An error occured on updating record.";

        public const string Not_Found = "Not found";
        public const string Not_Authorized = "Not authorized";

        public const string Delete_Operation_Success_Message = "Deleted succesfully";
        public const string Delete_Operation_Error_Message = "An error occured on deleting the record";

        public const string Notification_Not_Found_Message = "Notification not found";
        public const string Null = "{PropertyName} cannot be null.";
        public const string Delete_Success = "{PropertyName} deleted successfully.";

        public const string Has_Purchase_Orders = "{PropertyName} has purchase orders cannot deleted.";


        public static string Build(string propertyName, string messageTemplate)
        {
            return messageTemplate.Replace("{PropertyName}", propertyName);
        }


    }
}
