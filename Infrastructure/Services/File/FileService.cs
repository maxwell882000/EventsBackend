using EventsBookingBackend.Domain.Files.Repositories;
using EventsBookingBackend.Domain.Files.Services;
using EventsBookingBackend.Infrastructure.Options.File;
using Microsoft.Extensions.Options;

namespace EventsBookingBackend.Infrastructure.Services.File;

public class FileService(IOptions<FileOption> options, IFileRepository fileRepository) : IFileService
{
    private readonly string _storagePath = options.Value.StoragePath;

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file.Length <= 0)
            throw new ArgumentException("File is empty");

        var filePath = Path.Combine(_storagePath,
            DateTime.Now + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName));

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        await fileRepository.Create(new Domain.File.Entities.File()
        {
            FileName = file.FileName,
            FilePath = filePath,
            FileSize = file.Length,
            ContentType = file.ContentType
        });

        return filePath;
    }
}