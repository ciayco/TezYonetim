<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    public static void RegisterRoutes(System.Web.Routing.RouteCollection RouteCollection_)
        {
            RouteCollection_.MapPageRoute("Admin", "Admin", @"~/Admin.aspx");
            RouteCollection_.MapPageRoute("Default", "Default", @"~/Default.aspx");
            RouteCollection_.MapPageRoute("Duzenle", "Duzenle", @"~/Duzenle.aspx");
            RouteCollection_.MapPageRoute("SignUp", "SignUp", @"~/SignUp.aspx");
            RouteCollection_.MapPageRoute("User", "User", @"~/User.aspx");
         
            
        }
       
</script>
