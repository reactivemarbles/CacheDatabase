// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using ReactiveMarbles.CacheDatabase.Core;
using ReactiveMarbles.CacheDatabase.Settings.Core;
#if ENCRYPTED
using ReactiveMarbles.CacheDatabase.EncryptedSqlite3;
#else
using ReactiveMarbles.CacheDatabase.Sqlite3;
#endif
using System.Reflection;

#if ENCRYPTED
namespace ReactiveMarbles.CacheDatabase.EncryptedSettings
#else
namespace ReactiveMarbles.CacheDatabase.Settings
#endif
{
    /// <summary>
    /// App Info.
    /// </summary>
    public static class AppInfo
    {
        static AppInfo()
        {
            SettingsStores = new();
            BlobCaches = new();
            ExecutingAssemblyName = ExecutingAssembly.FullName!.Split(',')[0];
            ApplicationRootPath = Path.Combine(Path.GetDirectoryName(ExecutingAssembly.Location)!, "..");
            SettingsCachePath = Path.Combine(ApplicationRootPath, "SettingsCache");
            Version = ExecutingAssembly.GetName().Version;
        }

        /// <summary>
        /// Gets the application root path.
        /// </summary>
        /// <value>
        /// The application root path.
        /// </value>
        public static string? ApplicationRootPath { get; }

        /// <summary>
        /// Gets the settings cache path.
        /// </summary>
        /// <value>
        /// The settings cache path.
        /// </value>
        public static string? SettingsCachePath { get; }

        /// <summary>
        /// Gets the executing assembly.
        /// </summary>
        /// <value>
        /// The executing assembly.
        /// </value>
        public static Assembly ExecutingAssembly => Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();

        /// <summary>
        /// Gets the name of the executing assembly.
        /// </summary>
        /// <value>
        /// The name of the executing assembly.
        /// </value>
        public static string? ExecutingAssemblyName { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public static Version? Version { get; }

        internal static Dictionary<string, IBlobCache?> BlobCaches { get; }

        internal static Dictionary<string, ISettingsStorage?> SettingsStores { get; }

        /// <summary>
        /// Deletes the settings store.
        /// </summary>
        /// <typeparam name="T">The type of store to delete.</typeparam>
        /// <returns>A Task.</returns>
        public static async Task DeleteSettingsStore<T>()
        {
            await DisposeSettingsStore<T>().ConfigureAwait(false);
            File.Delete(Path.Combine(SettingsCachePath!, $"{typeof(T).Name}.db"));
        }

        /// <summary>
        /// Gets the settings store.
        /// </summary>
        /// <typeparam name="T">The store to get.</typeparam>
        /// <returns>A Settings Store.</returns>
        public static ISettingsStorage? GetSettingsStore<T>() =>
            SettingsStores[typeof(T).Name];

        /// <summary>
        /// Disposes the settings store.
        /// </summary>
        /// <typeparam name="T">The type of store.</typeparam>
        /// <returns>A Task.</returns>
        public static async Task DisposeSettingsStore<T>()
        {
            await GetSettingsStore<T>()!.DisposeAsync().ConfigureAwait(false);
            await BlobCaches[typeof(T).Name]!.DisposeAsync().ConfigureAwait(false);
        }

#if ENCRYPTED
        /// <summary>
        /// Setup the secure settings store.
        /// </summary>
        /// <typeparam name="T">The Type of settings store.</typeparam>
        /// <param name="password">Secure password.</param>
        /// <param name="initialise">Initialise the Settings values.</param>
        /// <returns>The Settings store.</returns>
        public static async Task<T?> SetupSettingsStore<T>(string password, bool initialise = true)
            where T : ISettingsStorage?, new()
        {
            Directory.CreateDirectory(SettingsCachePath!);
            BlobCaches[typeof(T).Name] = new EncryptedSqliteBlobCache(Path.Combine(SettingsCachePath!, $"{typeof(T).Name}.db"), password);

            var viewSettings = new T();
            SettingsStores[typeof(T).Name] = viewSettings;
            if (initialise)
            {
                await viewSettings.InitializeAsync().ConfigureAwait(false);
            }

            return viewSettings;
        }
#else

        /// <summary>
        /// Setup the settings store.
        /// </summary>
        /// <typeparam name="T">The Type of settings store.</typeparam>
        /// <param name="initialise">Initialise the Settings values.</param>
        /// <returns>The Settings store.</returns>
        public static async Task<T?> SetupSettingsStore<T>(bool initialise = true)
            where T : ISettingsStorage?, new()
        {
            Directory.CreateDirectory(SettingsCachePath!);
            BlobCaches[typeof(T).Name] = new SqliteBlobCache(Path.Combine(SettingsCachePath!, $"{typeof(T).Name}.db"));

            var viewSettings = new T();
            SettingsStores[typeof(T).Name] = viewSettings;
            if (initialise)
            {
                await viewSettings.InitializeAsync().ConfigureAwait(false);
            }

            return viewSettings;
        }
#endif
    }
}
