using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VRisingServerManager
{
    public class MainSettings
    {
        public ObservableCollection<Server> Servers { get; set; } = new ObservableCollection<Server>();
        public AppSettings AppSettings { get; set; } = new AppSettings();
        public Webhook WebhookSettings { get; set; } = new Webhook();

        /// <summary>
        /// Saves the specified <see cref="MainSettings"/> object.
        /// </summary>
        /// <param name="settings">The <see cref="MainSettings"/> object to save.</param>
        public static void Save(MainSettings settings)
        {
            string dir = Directory.GetCurrentDirectory() + @"\VSMSettings.json";
            JsonSerializerOptions jsonOptions = new() { WriteIndented = true };
            string SettingsJSON = JsonSerializer.Serialize(settings, jsonOptions);
            File.WriteAllText(dir, SettingsJSON);
        }

        /// <summary>
        /// Loads a <see cref="MainSettings"/> object from rootdirectory and returns it.
        /// </summary>
        /// <returns>The loaded <see cref="MainSettings"/> object.</returns>
        public static MainSettings Load()
        {
            string dir = Directory.GetCurrentDirectory() + @"\VSMSettings.json";
            if (File.Exists(dir))
            {
                using (StreamReader sr = new(dir, false))
                {
                    string SettingsJSON = sr.ReadToEnd();
                    MainSettings LoadedSettings = JsonSerializer.Deserialize<MainSettings>(SettingsJSON);
                    return LoadedSettings;
                }
            }
            else
            {
                MessageBox.Show("Could not find 'VSMSettings.json', settings could not be loaded.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MainSettings DefaultSettings = new MainSettings();
                return DefaultSettings;
            }
            
        }
    }

    /// <summary>
    /// Object containing information about a <see cref="Server"/>.
    /// </summary>
    public class Server : PropertyChangedBase
    {
        public string Name { get; set; } = "ServerName";
        private string _path = Directory.GetCurrentDirectory() + @"\Server";
        public string Path
        {
            get => _path;
            set => SetField(ref _path, value);
        }
        public LaunchSettings LaunchSettings { get; set; } = new LaunchSettings();
        public RCONServerSettings RconServerSettings { get; set; } = new RCONServerSettings();
        private bool _autoRestart = false;
        public bool AutoRestart
        {
            get => _autoRestart;
            set => SetField(ref _autoRestart, value);
        }
        [JsonIgnore]
        public ServerRuntime Runtime { get; set; } = new ServerRuntime();
        
    }

    /// <summary>
    /// Property of <see cref="Server"/> used to track runtime.
    /// </summary>
    public class ServerRuntime : PropertyChangedBase
    {
        public Process? Process { get; set; }
        public bool UserStopped { get; set; } = false;
        public int RestartAttempts { get; set; } = 0;
        public enum ServerState
        {
            Stopped,
            Running,
            Updating
        }
        private ServerState _state = ServerState.Stopped;
        public ServerState State
        {
            get => _state;
            set => SetField(ref _state, value);
        }
    }

    /// <summary>
    /// Property of <see cref="Server"/> used to fetch RCON Settings.
    /// </summary>
    public class RCONServerSettings
    {
        public string IPAddress { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "25575";
        public string Password { get; set; } = "";
    }

    /// <summary>
    /// Property of <see cref="Server"/> used to fetch Launch Settings.
    /// </summary>
    public class LaunchSettings
    {
        public string DisplayName { get; set; } = "V Rising Server";
        public string WorldName { get; set; } = "world01";
        public bool BindToIP { get; set; } = false;
        public string BindingIP { get; set; } = "127.0.0.1";
    }

    /// <summary>
    /// Property of <see cref="MainSettings"/> used to for application settings.
    /// </summary>
    public class AppSettings : PropertyChangedBase
    {
        private bool _verifyUpdates = false;
        public bool VerifyUpdates
        {
            get => _verifyUpdates;
            set => SetField(ref _verifyUpdates, value);
        }
        private bool _autoUpdate = false;
        public bool AutoUpdate
        {
            get => _autoUpdate;
            set => SetField(ref _autoUpdate, value);
        }
        private bool _autoUpdateApp = false;
        public bool AutoUpdateApp
        {
            get => _autoUpdateApp;
            set => SetField(ref _autoUpdateApp, value);
        }
        private int _autoUpdateInterval = 60;
        private bool _showSteamWindow = false;
        public bool ShowSteamWindow
        {
            get => _showSteamWindow;
            set => SetField(ref _showSteamWindow, value);
        }
        public int AutoUpdateInterval
        {
            get => _autoUpdateInterval;
            set => SetField(ref _autoUpdateInterval, value);
        }
        private string _lastUpdateTimeUNIX = "";
        public string LastUpdateTimeUNIX
        {
            get => _lastUpdateTimeUNIX;
            set => SetField(ref _lastUpdateTimeUNIX, value);
        }
        private string _lastUpdateTime = "Last Update on Steam: Unknown";
        public string LastUpdateTime
        {
            get => _lastUpdateTime;
            set => SetField(ref _lastUpdateTime, value);
        }
        private string _version = "3.1b";
        public string Version
        {
            get => _version;
            set => SetField(ref _version, value);
        }
    }

    /// <summary>
    /// Property of <see cref="MainSettings"/> used for webhook settings.
    /// </summary>
    public class Webhook
    {
        public bool Enabled { get; set; } = false;
        public string URL { get; set; } = "";
    }
}

/// <summary>
/// Class to implement INotifyPropertyChanged easily
/// </summary>
public class PropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value,
    [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}