using Gamestore.ApplicationServices.Requests.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;
public class DownloadGameHandler : IRequestHandler<DownloadGameRequest, Stream>
{
    public async Task<Stream> Handle(DownloadGameRequest request, CancellationToken cancellationToken)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        await writer.WriteAsync($"this is {request.GameAlias} game :)");
        await writer.FlushAsync();
        stream.Position = 0;
        return stream;
    }
}