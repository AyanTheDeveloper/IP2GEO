// See https://aka.ms/new-console-template for more information
using IP2GEO;

IP2GEO.IP2GEO i2g = new IP2GEO.IP2GEO();
Console.WriteLine(i2g.Locate());
Console.WriteLine(i2g.LocateCountryNameOnly());
Console.WriteLine(i2g.LocateCountryCodeOnly());