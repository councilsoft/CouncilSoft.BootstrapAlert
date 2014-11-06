CouncilSoft.BootstrapAlert
==========================

An ASP.NET MVC, jQuery, and Bootstrap facility for stacking alert messages for the user. This uses the "[alert](http://getbootstrap.com/components/#alerts)" feature of Bootstrap.

###NuGet Package
This is the source project for the following NuGet package:

> [https://www.nuget.org/packages/CouncilSoft.BootstrapAlert/](https://www.nuget.org/packages/CouncilSoft.BootstrapAlert/)

###Requirements
Currently, this component uses ASP.NET MVC 5.2.2, Bootstrap 3.x, and jQuery 2.1.1

###HowTo: Queue messages (from an MVC controller)
From within an ASP.NET MVC controller action, you can use code like this, to queue a message to show on the View:

    public ActionResult Index()
    {
        AlertManager.AppendAlert(this,
            new AlertDetail()
            {
                AlertMessage = "Test DANGER message.",
                Severity = AlertSeverity.Danger,
                AutoDismissTime = new TimeSpan(0, 0, 5),
                ShowDismissButton = true,
                EnableCrossView = false
            });
        AlertManager.AppendAlert(this,
            new AlertDetail()
            {
                AlertMessage = "Test WARNING message.",
                Severity = AlertSeverity.Warning,
                AutoDismissTime = new TimeSpan(0, 0, 4)
            });
        AlertManager.AppendAlert(this,
            new AlertDetail()
            {
                AlertMessage = "Test INFO message.",
                Severity = AlertSeverity.Info,
                AutoDismissTime = new TimeSpan(0, 0, 3)
            });
        AlertManager.AppendAlert(this,
            new AlertDetail()
            {
                AlertMessage = "Test SUCCESS message.",
                Severity = AlertSeverity.Success,
                AutoDismissTime = new TimeSpan(0, 0, 2)
            });
        return View();
    }

Note that each message can be set to auto-dismiss, show a dismiss button, and can be set to span multiple views. With the "EnableCrossView" set to true, you can set an alert on your Create() action, and then RedirectToAction("Index") and the message will show up on that view.

This is because when this is set to true, the message is stored in TempData instead of ViewData.

###HowTo: Queue messages (from jQuery)
Once a page is already loaded, you can use JavaScript to dynamically add a message to the message area as well. For example:

    var severity = -2; // -2=Danger, -1=Warning, 0=Info, 1=Success
    var autoDismissInMilliSeconds = 2000;
    var showDismissButton = 1;
    
    addAlertToMessageArea(severity, "Message goes here", autoDismissInMilliSeconds, showDismissButton);

###HowTo: Render the messages
The code above gets messages into the queue, but how do you render them? For that, there are a couple HtmlHelpers for that. Add some code like this on your _Layout.cshtml page AFTER jQuery is defined:

    <script src="~/Scripts/CouncilSoft.BootstrapAlert.js"></script> <!-- Renders the script that manages the alerts, client-side. -->
    @Html.Raw(Html.RenderAlertMessagesFromQueue()) <!-- Renders the alert messages that are in the queue -->

One other piece is needed. You have to decide where on the page you want to see the messages. That could be on the _Layout.cshtml, or it could be in a certain place on a specific page. Whereever it is, just add a line like this:

    @Html.Raw(Html.RenderAlertMessageContainer())

Note that this renders out a &lt;div&gt; tag, in which all messages will be published.

Also note that the @Html helpers require that the following language extension namespace be registered. So, at the top of your View file, add:

    @using CouncilSoft.BootstrapAlert.Extensions

###More Samples
See the following blog post for more detail and explaining in more-depth, how this component works:

> http://blog.robseder.com/2014/11/06/using-councilsoft-bootstrapalert-nuget-package/
