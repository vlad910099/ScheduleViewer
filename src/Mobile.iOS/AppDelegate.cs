using Domain.PersistenceInterfaces;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using UIKit;

namespace Mobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(AddServices));

            return base.FinishedLaunching(app, options);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IDbPathProvider, iOSDbPathProvider>();
        }
    }
}