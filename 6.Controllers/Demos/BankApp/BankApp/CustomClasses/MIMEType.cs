using Microsoft.AspNetCore.StaticFiles;

namespace BankApp.CustomClasses
{
    public class MIMEType
    {
        internal static string GetMIMEType(string fileName)
        {
            const string DefaultContentType = "application/octet-stream";

            string contentType;

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}
