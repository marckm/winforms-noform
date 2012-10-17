namespace NoFormApplication
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // do all your stuff here... (run a background thread, host a WCF service...)
            Application.ApplicationExit += OnApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;

            Application.Run(new CustomContext());
        }

        /// <summary>
        /// Do here what needs to be done when application closes
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        static void OnApplicationExit(object sender, EventArgs e)
        {
            // close here all your background services (thread, WCF service...)
        }

        /// <summary>
        /// Called when an unhandled exception appears.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private static void OnCurrentDomainUnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            // we come here if there is any exception not handled correctly (i.e. in CustomContext).
            // normally we should log, display error to user and exit the app.
            System.Environment.Exit(0);
        }
    }
}
