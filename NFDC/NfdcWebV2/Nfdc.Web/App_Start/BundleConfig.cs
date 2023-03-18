using System.Web;
using System.Web.Optimization;

namespace Nfdc.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/prescript"));

            bundles.Add(new ScriptBundle("~/postscript"));

            bundles.Add(new StyleBundle("~/css")
                    .Include("~/content/site.css")
                );
        }
    }
}
