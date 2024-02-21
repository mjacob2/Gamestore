using Gamestore.DataAccess.Entities;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;

namespace Gamestore.ApplicationServices.Services.BankPaymentMethod;
public class BankPaymentMethod : IBankPaymentMethod
{
    private readonly int _daysOfInvoiceValidity;

    public BankPaymentMethod(int getValue)
    {
        _daysOfInvoiceValidity = getValue;
    }

    public Stream GenerateInvoice(Order order)
    {
        var userId = order.CustomerId;
        var orderId = order.Id;
        var sum = order.Sum;
        var totalPrice = order.TotalPrice;

        var parts = new List<string>
        {
            $"Invoice for order nr {orderId}",
            $"Hello {userId}!",
            $"You bought {sum} items for total price {totalPrice}.",
            $"You must pay within {_daysOfInvoiceValidity} days.",
        };

        var stream = new MemoryStream();
        var pdf = new PdfDocument();
        var page = pdf.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 14, XFontStyle.Regular);
        var tf = new XTextFormatter(gfx);

        var rect = new XRect(40, 100, 500, 200);
        foreach (var part in parts)
        {
            tf.DrawString(part, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            rect.Offset(0, 20);
        }

        pdf.Save(stream, false);
        stream.Position = 0;

        return stream;
    }
}
