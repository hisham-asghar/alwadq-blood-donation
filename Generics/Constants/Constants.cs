using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Constants
{
    public static class Domain
    {
        public static string[] StaticLinks { get; } =
        {
            "//",
            "//" };

        public const string Name = "The Maruca Group";

        public static string StaticProduction = "//staticxxx.themarucagroup.com/";
        public static string Static = "staticxxx.themarucagroup.com/";
        //public static string StaticProduction = "http://staticxxx.themarucagroup.com/";
        //public static string Static = "staticxxx.themarucagroup.com/";

        public static class Local
        {
            public const string Website = "http://localhost:62773/";
            public const string Admin = "http://localhost:56753/";
            public const string Payment = "http://localhost:54266/";
            public const string Static = "http://staticxxx.themarucagroup.com";
        }
        public static class Staging
        {
            public const string Website = "http://staging.themarucagroup.com";
            public const string Admin = "http://stageadmin.themarucagroup.com";
            public const string Payment = "http://stagepayment.themarucagroup.com";
            //public const string Static = "http://staticxxx.themarucagroup.com";
            public const string Static = "http://staticxxx.themarucagroup.com";
        }
        public static class Production
        {
            public const string Website = "https://themarucagroup.com";
            public const string Admin = "http://admin.themarucagroup.com";
            public const string Payment = "http://payment.themarucagroup.com";
            //public const string Static = "http://staticxxx.themarucagroup.com";
            public const string Static = "http://staticxxx.themarucagroup.com";
        }
    }

    public static class Website
    {
        public const string Name = "The Maruca Group";
        public const string LogoImageUrl = "http://staticxxx.themarucagroup.com/Content/logo.png";
        public const string Url = "http://themarucagroup.com";
        //public const string StaticUrl = "http://staticxxx.themarucagroup.com";
        public const string StaticUrl = "http://staticxxx.themarucagroup.com";

        public const string Description =
            "Welcome to The Maruca Group. A leader in the management of luxury rentals and vacation planning. Our accommodations go far beyond premier luxury hotels.";
        public const string Title = "Discover the best vacation rentals - The Maruca Group";

    }

    public static class Reservations
    {
        public const string Yacht = "Yacht";
        public const string Car = "Car";

    }
    public static class Booking
    {
        public const string ControllerLink = "http://themarucagroup.com/Destinations/Booking/";

    }
}
