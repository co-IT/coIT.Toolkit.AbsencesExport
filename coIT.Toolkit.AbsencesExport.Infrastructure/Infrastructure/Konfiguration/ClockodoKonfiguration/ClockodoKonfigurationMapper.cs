using coIT.Libraries.Clockodo.Absences;
using coIT.Libraries.ConfigurationManager.Cryptography;
using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Konfiguration.ClockodoKonfiguration
{
    internal class ClockodoKonfigurationMapper
    {
        private readonly IDoCryptography _cryptographyService;

        public ClockodoKonfigurationMapper(IDoCryptography cryptographyService)
        {
            _cryptographyService = cryptographyService;
        }

        public Result<AbsencesServiceSettings> VonEntity(ClockodoKonfigurationEntity entity)
        {
            return _cryptographyService
                .Decrypt(entity.ApiToken)
                .Map(apiToken => new AbsencesServiceSettings(
                    entity.EmailAddress,
                    apiToken,
                    entity.BaseAddress
                ));
        }

        public Result<ClockodoKonfigurationEntity> ZuEntity(AbsencesServiceSettings settings)
        {
            return _cryptographyService
                .Encrypt(settings.ApiToken)
                .Map(apiToken => new ClockodoKonfigurationEntity
                {
                    ApiToken = apiToken,
                    EmailAddress = settings.EmailAddress,
                    BaseAddress = settings.BaseAdress,
                });
        }
    }
}
