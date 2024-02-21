using Gamestore.DataAccess.Mongo.Entities;

namespace Gamestore.ApplicationServices.Models;
public class ShipperListingModel
{
    public ShipperListingModel()
    {
    }

    public ShipperListingModel(Shipper shipper)
    {
        ShipperId = shipper.Id;
        CompanyName = shipper.CompanyName;
        Phone = shipper.Phone;
    }

    public ShipperListingModel(DataAccess.Entities.Shipper shipper)
    {
        ShipperId = shipper.ShipperId.ToString();
        CompanyName = shipper.CompanyName;
        Phone = shipper.Phone;
    }

    public string ShipperId { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }

    public static List<ShipperListingModel> ToList(IEnumerable<Shipper> shippers)
    {
        var list = new List<ShipperListingModel>();

        foreach (var shipper in shippers)
        {
            var model = new ShipperListingModel(shipper);
            list.Add(model);
        }

        return list;
    }
}
