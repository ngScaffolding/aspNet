using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ngScacffolding.demoApp.Data;
using ngScaffolding.demoApp.Models;

namespace ngScaffolding.demoSetup
{
    public class SetupGeography
    {
        public static void Setup(DemoContext demoCtx)
        {
            if (!demoCtx.Continents.Any())
            {
                demoCtx.Continents.Add(new Continent() {Name = "Africa"});
                demoCtx.Continents.Add(new Continent() {Name = "Asia"});
                demoCtx.Continents.Add(new Continent() {Name = "Europe"});
                demoCtx.Continents.Add(new Continent() {Name = "North America"});
                demoCtx.Continents.Add(new Continent() {Name = "Oceania"});
                demoCtx.Continents.Add(new Continent() {Name = "South America"});
            }

            if (!demoCtx.Countries.Any())
            {
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Algeria"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Angola"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Benin"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Botswana"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Burkina"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Burundi"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Cameroon"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Cape Verde"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Central African Republic"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Chad"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Comoros"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Congo"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Congo, Democratic Republic of"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Djibouti"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Egypt"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Equatorial Guinea"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Eritrea"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Ethiopia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Gabon"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Gambia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Ghana"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Guinea"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Guinea-Bissau"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Ivory Coast"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Kenya"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Lesotho"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Liberia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Libya"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Madagascar"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Malawi"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Mali"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Mauritania"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Mauritius"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Morocco"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Mozambique"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Namibia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Niger"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Nigeria"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Rwanda"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Sao Tome and Principe"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Senegal"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Seychelles"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Sierra Leone"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Somalia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "South Africa"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "South Sudan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Sudan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Swaziland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Tanzania"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Togo"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Tunisia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Uganda"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Zambia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Africa", Name = "Zimbabwe"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Afghanistan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Bahrain"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Bangladesh"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Bhutan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Brunei"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Burma (Myanmar)"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Cambodia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "China"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "East Timor"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "India"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Indonesia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Iran"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Iraq"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Israel"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Japan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Jordan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Kazakhstan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Korea, North"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Korea, South"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Kuwait"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Kyrgyzstan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Laos"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Lebanon"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Malaysia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Maldives"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Mongolia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Nepal"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Oman"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Pakistan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Philippines"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Qatar"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Russian Federation"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Saudi Arabia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Singapore"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Sri Lanka"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Syria"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Tajikistan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Thailand"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Turkey"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Turkmenistan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "United Arab Emirates"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Uzbekistan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Vietnam"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Asia", Name = "Yemen"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Albania"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Andorra"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Armenia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Austria"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Azerbaijan"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Belarus"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Belgium"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Bosnia and Herzegovina"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Bulgaria"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Croatia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Cyprus"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Czech Republic"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Denmark"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Estonia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Finland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "France"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Georgia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Germany"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Greece"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Hungary"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Iceland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Ireland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Italy"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Latvia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Liechtenstein"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Lithuania"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Luxembourg"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Macedonia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Malta"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Moldova"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Monaco"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Montenegro"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Netherlands"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Norway"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Poland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Portugal"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Romania"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "San Marino"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Serbia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Slovakia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Slovenia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Spain"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Sweden"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Switzerland"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Ukraine"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "United Kingdom"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Europe", Name = "Vatican City"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Antigua and Barbuda"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Bahamas"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Barbados"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Belize"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Canada"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Costa Rica"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Cuba"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Dominica"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Dominican Republic"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "El Salvador"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Grenada"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Guatemala"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Haiti"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Honduras"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Jamaica"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Mexico"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Nicaragua"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Panama"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Saint Kitts and Nevis"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Saint Lucia"});
                demoCtx.Countries.Add(new Country()
                {
                    ContinentName = "North America",
                    Name = "Saint Vincent and the Grenadines"
                });
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "Trinidad and Tobago"});
                demoCtx.Countries.Add(new Country() {ContinentName = "North America", Name = "United States"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Australia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Fiji"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Kiribati"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Marshall Islands"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Micronesia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Nauru"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "New Zealand"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Palau"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Papua New Guinea"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Samoa"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Solomon Islands"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Tonga"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Tuvalu"});
                demoCtx.Countries.Add(new Country() {ContinentName = "Oceania", Name = "Vanuatu"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Argentina"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Bolivia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Brazil"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Chile"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Colombia"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Ecuador"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Guyana"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Paraguay"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Peru"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Suriname"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Uruguay"});
                demoCtx.Countries.Add(new Country() {ContinentName = "South America", Name = "Venezuela"});
            }

            demoCtx.SaveChanges();
            
        }
    }
}
