namespace health_api._Shared
{
    public static class SharedMapper
    {
        public static void MapSharedEndpoints(this WebApplication app) =>

        #region login 
            app.MapGet("/login", () =>
            {
                Console.WriteLine("Hello world");
                return "Hello world";
            });
        #endregion

    }
}
