![License](https://img.shields.io/github/license/ReactiveMarbles/CacheDatabase.svg) [![Build](https://github.com/reactivemarbles/CacheDatabase/actions/workflows/ci-build.yml/badge.svg)](https://github.com/reactivemarbles/CacheDatabase/actions/workflows/ci-build.yml)

# CacheDatabase
<p align="center">
  <a href="https://github.com/reactivemarbles/CacheDatabase">
    <img alt="CacheDatabase" src="images/logo.png" width="200"/>
  </a>
</p>

A reimplementation of [Akavache](https://github.com/reactiveui/akavache) using the SQLite framework by [Frank Krueger](https://github.com/praeclarum/sqlite-net).

ReactiveMarbles.CacheDatabase.EncryptedSqlite3
![Nuget](https://img.shields.io/nuget/dt/ReactiveMarbles.CacheDatabase.EncryptedSqlite3?color=pink&style=plastic) [![NuGet](https://img.shields.io/nuget/v/ReactiveMarbles.CacheDatabase.EncryptedSqlite3.svg?style=plastic)](https://www.nuget.org/packages/ReactiveMarbles.CacheDatabase.EncryptedSqlite3)

ReactiveMarbles.CacheDatabase.Sqlite3
![Nuget](https://img.shields.io/nuget/dt/ReactiveMarbles.CacheDatabase.Sqlite3?color=pink&style=plastic) [![NuGet](https://img.shields.io/nuget/v/ReactiveMarbles.CacheDatabase.Sqlite3.svg?style=plastic)](https://www.nuget.org/packages/ReactiveMarbles.CacheDatabase.Sqlite3)

# CacheDatabase.Settings

A settings database for use with installable applications to provide persistent settings which are located one level down from the application folder making updates less painfull.

## Example Application settings code
```c#
public class ViewSettings : SettingsBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ViewSettings"/> class.
    /// </summary>
    public ViewSettings()
        : base(nameof(ViewSettings))
    {
    }

    /// <summary>
    /// Gets or sets a value indicating whether [bool test].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [bool test]; otherwise, <c>false</c>.
    /// </value>
    public bool BoolTest
    {
        get => GetOrCreate(true); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the byte test.
    /// </summary>
    /// <value>
    /// The byte test.
    /// </value>
    public byte ByteTest
    {
        get => GetOrCreate((byte)123); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the short test.
    /// </summary>
    /// <value>
    /// The short test.
    /// </value>
    public short ShortTest
    {
        get => GetOrCreate((short)16); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the int test.
    /// </summary>
    /// <value>
    /// The int test.
    /// </value>
    public int IntTest
    {
        get => GetOrCreate(1); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the long test.
    /// </summary>
    /// <value>
    /// The long test.
    /// </value>
    public long LongTest
    {
        get => GetOrCreate(123456); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the string test.
    /// </summary>
    /// <value>
    /// The string test.
    /// </value>
    public string? StringTest
    {
        get => GetOrCreate("TestString"); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the float test.
    /// </summary>
    /// <value>
    /// The float test.
    /// </value>
    public float FloatTest
    {
        get => GetOrCreate(2.2f); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the double test.
    /// </summary>
    /// <value>
    /// The double test.
    /// </value>
    public double DoubleTest
    {
        get => GetOrCreate(23.8d); set => SetOrCreate(value);
    }

    /// <summary>
    /// Gets or sets the enum test.
    /// </summary>
    /// <value>
    /// The enum test.
    /// </value>
    public EnumTestValue EnumTest
    {
        get => GetOrCreate(EnumTestValue.Option1); set => SetOrCreate(value);
    }
}
```

## Create an instance or get existing Settings SettingsCache

Install ReactiveMarbles.CacheDatabase.Settings
![Nuget](https://img.shields.io/nuget/dt/ReactiveMarbles.CacheDatabase.Settings?color=pink&style=plastic) [![NuGet](https://img.shields.io/nuget/v/ReactiveMarbles.CacheDatabase.Settings.svg?style=plastic)](https://www.nuget.org/packages/ReactiveMarbles.CacheDatabase.Settings)

```c#
var viewSettings = await AppInfo.SetupSettingsStore<ViewSettings>();
```
## To Create an instance or get existing EncryptedSettings SettingsCache

Install ReactiveMarbles.CacheDatabase.EncryptedSettings
![Nuget](https://img.shields.io/nuget/dt/ReactiveMarbles.CacheDatabase.EncryptedSettings?color=pink&style=plastic) [![NuGet](https://img.shields.io/nuget/v/ReactiveMarbles.CacheDatabase.EncryptedSettings.svg?style=plastic)](https://www.nuget.org/packages/ReactiveMarbles.CacheDatabase.EncryptedSettings)
```c#
var viewSettings = await AppInfo.SetupSettingsStore<ViewSettings>("SECURE_PASSWORD");
```
## To Delete the instance of the SettingsCache
```c#
await AppInfo.DeleteSettingsStore<ViewSettings>();
```
## To Close the SettingsCache upon application exit
```c#
await AppInfo.DisposeSettingsStore<ViewSettings>();
```

Multiple SettingsCache's can be created, each SettingsCache will have a SettingsCache database created with the name of the SettingsCache class.