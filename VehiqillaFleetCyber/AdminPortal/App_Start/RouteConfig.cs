using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ConsumptionsReports",                                                          // Route name
                "{controller}/Inventory/ConsumptionsReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "ConsumptionsReport",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            routes.MapRoute(
                "AgingReports",                                                          // Route name
                "{controller}/Purchase/AgingReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "AgeAnalysis",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            //  http://localhost:4567/Reports/Purchase/PurchaseSummaryReports/Supplierwise
            routes.MapRoute(
                "PurchaseSummaryReports",                                                          // Route name
                "{controller}/Purchase/PurchaseSummaryReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "Supplierwise",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            //  http://localhost:4567/Reports/Purchase/ListofPurchaseDocuments/ListofPendingPurchaseRequisition
            routes.MapRoute(
                "ListofPurchaseDocuments",                                                          // Route name
                "{controller}/Purchase/ListofPurchaseDocuments/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "ListofPendingPurchaseRequisition",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            //  http://localhost:4567/Reports/Purchase/MiscellaneousReports/PurchaseOrderStatusReport
            routes.MapRoute(
                "MiscellaneousReports",                                                          // Route name
                "{controller}/Purchase/MiscellaneousReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "PurchaseOrderStatusReport",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            //  http://localhost:4567/Reports/Sales/SalesSummaryReports/SalesSummary
            routes.MapRoute(
                "SalesSummaryReports",                                                          // Route name
                "{controller}/Sales/SalesSummaryReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "SalesSummary",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );
            //  http://localhost:4567/Reports/Sales/DailyReceipts/DailyReceiptsReport
            routes.MapRoute(
                "DailyReceipts",                                                          // Route name
                "{controller}/Sales/DailyReceipts/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "DailyReceiptsReport",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );
            //  http://localhost:4567/Reports/Sales/AgingReports/AgeAnalysisSales
            routes.MapRoute(
                "AgingReports2",                                                          // Route name
                "{controller}/Sales/AgingReports/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "AgeAnalysisSales",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            routes.MapRoute(
                "Sales",                                                          // Route name
                "{controller}/Sales/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "SalesLedger",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            routes.MapRoute(
                "Reports",                                                          // Route name
                "{controller}/Inventory/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "ProductLedger",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            routes.MapRoute(
                "Purchase",                                                          // Route name
                "{controller}/Purchase/{action}/{id}",                             // URL with parameters
                new
                {
                    controller = "Reports",
                    action = "PaymentSheet",
                    id = UrlParameter.Optional
                }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}