namespace resturangApi.Enums
{
    //this is for later to build a response system that automaticly returns the correct status code based on the error
    public enum ErrorCode
    {
        None = 0,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        ServerError = 500,
        Unknown = 520

    }
}
