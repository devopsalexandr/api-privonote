namespace Privnote.Contracts.v1;

public static class ApiRoutes
{
    public const string Version = "v1";

    public const string Base = "/" + Version;
    
    public static class Notes
    {
        public const string Create = Base + "/";
            
        public const string Show = Base + "/{Id}";
    }
}