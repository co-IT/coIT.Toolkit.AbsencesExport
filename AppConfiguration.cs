using System.Reflection;
using System.Text;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace coIT.AbsencesExport
{
    public class AppConfiguration
    {
        private readonly string _appName;
        private readonly string _configFileExtensions;

        public AppConfiguration(string appName, string configFileExtensions = "json")
        {
            _appName = appName;
            _configFileExtensions = configFileExtensions;
        }

        public bool IsInitialConfigurationNeeded()
        {
            var settingFiles =
                Assembly
                    .GetEntryAssembly()
                    ?.DefinedTypes.Where(t => !string.IsNullOrWhiteSpace(t.FullName))
                    .Where(t =>
                        t.FullName!.Contains(
                            ".Configurations.",
                            StringComparison.InvariantCultureIgnoreCase
                        )
                    )
                    .Select(t => t.Name)
                    .Where(t => t.EndsWith("Configuration"))
                    .Select(t => $"{t}.{_configFileExtensions}")
                    .ToList() ?? new List<string>();

            var settingsFolder = ConfigurationFolder();

            var expectedSettingFiles = settingFiles.Select(file =>
                Path.Combine(settingsFolder, file)
            );

            return expectedSettingFiles.Select(File.Exists).Any(existis => !existis);
        }

        private string ConfigurationFolder()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var settingsFolder = Path.Combine(appData, "co-IT", _appName);
            return settingsFolder;
        }

        public void Save(IEnumerable<object> configurations)
        {
            var configurationFolder = ConfigurationFolder();

            if (!Directory.Exists(configurationFolder))
            {
                Directory.CreateDirectory(configurationFolder);
            }

            foreach (var config in configurations)
            {
                var filename = GetFileName(config.GetType());
                var file = Path.Combine(configurationFolder, filename);
                var content = JsonConvert.SerializeObject(config);

                File.WriteAllText(file, content, Encoding.UTF8);
            }
        }

        public Result<T> Load<T>()
        {
            var filename = GetFileName(typeof(T));
            var configFolder = ConfigurationFolder();
            var file = Path.Combine(configFolder, filename);

            if (string.IsNullOrWhiteSpace(file))
                return Result.Failure<T>("Unbekannter Fehler.");

            return Result
                .SuccessIf(File.Exists(file), $"Datei '{file}' konnte nicht gefunden werden.")
                .MapTry(() => File.ReadAllText(file, Encoding.UTF8))
                .MapTry(
                    content => JsonConvert.DeserializeObject<T>(content),
                    ex => $"Datei '{file}' ist ungültig: " + ex.Message
                )
                .Ensure(setting => setting is not null, $"Datei '{file}' war leer.");
        }

        private string GetFileName(MemberInfo type)
        {
            return $"{type.Name}.{_configFileExtensions}";
        }
    }
}
