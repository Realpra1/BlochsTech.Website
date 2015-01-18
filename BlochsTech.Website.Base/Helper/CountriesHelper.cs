using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace BlochsTech.Website.Base.Helper
{
    /// <summary>
    /// Get countries name from the CurrentInfo helper class.
    /// </summary>
    public static class CountriesHelper
    {
        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetCountries()
        {
            var country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            var countryNames = new List<SelectListItem>();

            //To get the Country Names from the CultureInfo installed in windows
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(new SelectListItem() { Text = country.DisplayName, Value = country.DisplayName, Selected = country.DisplayName.Equals("United States") });
            }

            //Assigning all Country names to IEnumerable
            IEnumerable<SelectListItem> nameAdded = countryNames.GroupBy(x => x.Text).Select(x => x.FirstOrDefault()).ToList<SelectListItem>().OrderBy(x => x.Text);
            return nameAdded;
        }

    }
}