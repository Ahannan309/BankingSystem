public static class MessageUtility
{
    // Constants for error messages
    public const string GenericErrorMessage = "An unexpected error occurred. ";
    public const string NotFoundErrorMessage = "The requested resource could not be found. ";
    public const string ValidationErrorMessage = "There was a validation error. ";
    public const string DatabaseErrorMessage = "There was an issue with the database operation. ";

    // Constants for success messages
    public const string CreationSuccessMessage = "The resource was successfully created. ";
    public const string UpdateSuccessMessage = "The resource was successfully updated.";
    public const string DeletionSuccessMessage = "The resource was successfully deleted. ";
    public const string FetchSuccessMessage = "The resource was successfully fetched. ";

    //Exceptions
    public const string DeletionErrorMessage = "An error occurred while trying to delete the resource. ";

    public const string FetchErrorMessage = "An error occurred while trying to fetch the resource. ";
    public const string CreateErrorMessage = "An error occurred while trying to create the resource. ";
    public const string UpdateErrorMessage = "An error occurred while trying to update the resource. ";


    //Action
    public const string Deletion= "So Deletion Operation can not be perfromed";
    public const string Fetching= "Can not fetch the resources";
    public const string EmailExists= "User with this email already exists: ";



    //Error Messages
    public const string InvalidId = "Invalid Id";

    
    public static string HandleException(Exception exception)
    {
        
        return GenericErrorMessage;
    }

    public static string HandleNotFound(string _action)
    {
      
        return NotFoundErrorMessage + _action ;
    }

    
    public static string HandleValidationException(Exception exception)
    {
        
        return ValidationErrorMessage;
    }

    
    public static string HandleDatabaseException(Exception exception)
    {
       
        return DatabaseErrorMessage;
    }

    
    public static string HandleCreationSuccess()
    {
        
        return CreationSuccessMessage;
    }

    
    public static string HandleUpdateSuccess()
    {
       
        return UpdateSuccessMessage;
    }

    
    public static string HandleDeletionSuccess()
    {
        
        return DeletionSuccessMessage;
    }
    public static string HandleFetchSuccess()
    {
        return FetchSuccessMessage;

    }

    public static string HandleDeletionException(Exception ex)
    {
        return DeletionErrorMessage + ex.Message;
      
    }

    public static string HandleFetchException(Exception ex)
    {
        return FetchErrorMessage + ex.Message;
    }


    public static string HandleCreationException(Exception ex)
    {
        return CreateErrorMessage + ex.Message;
    }

    public  static string HandleAlreadyExist(string email)
    {
        return EmailExists + email;
    }

    internal static string HandleUpdateException(Exception ex)
    {
        return UpdateErrorMessage + ex.Message;
    }
}
