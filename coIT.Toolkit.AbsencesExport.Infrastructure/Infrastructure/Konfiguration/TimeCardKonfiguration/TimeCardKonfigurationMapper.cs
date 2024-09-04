using coIT.Libraries.ConfigurationManager.Cryptography;
using coIT.Libraries.TimeCard;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.TimeCardKonfiguration;

internal class TimeCardKonfigurationMapper
{
  private readonly IDoCryptography _cryptographyService;

  public TimeCardKonfigurationMapper(IDoCryptography cryptographyService)
  {
    _cryptographyService = cryptographyService;
  }

  public Result<TimeCardSettings> VonEntity(TimeCardKonfigurationEntity entity)
  {
    return _cryptographyService
      .Decrypt(entity.Password)
      .Map(password => new TimeCardSettings(entity.WebAddress, entity.Username, password, entity.NoExportGroup));
  }

  public Result<TimeCardKonfigurationEntity> ZuEntity(TimeCardSettings settings)
  {
    return _cryptographyService
      .Encrypt(settings.Password)
      .Map(password => new TimeCardKonfigurationEntity
      {
        WebAddress = settings.WebAddress,
        Username = settings.Username,
        Password = password,
        NoExportGroup = settings.NoExportGroup,
      });
  }
}
