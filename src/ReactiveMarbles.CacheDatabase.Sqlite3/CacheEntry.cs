// Copyright (c) 2019-2021 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using SQLite;

#if ENCRYPTED
namespace ReactiveMarbles.CacheDatabase.EncryptedSqlite3
#else
namespace ReactiveMarbles.CacheDatabase.Sqlite3
#endif
{
    /// <summary>
    /// A entry in a memory cache.
    /// </summary>
    internal class CacheEntry
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [PrimaryKey]
        [Unique]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entry was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entry will expire.
        /// </summary>
        [Indexed]
        public DateTimeOffset? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the type name of the entry.
        /// </summary>
        [Indexed]
        public string? TypeName { get; set; }

        /// <summary>
        /// Gets or sets the value of the entry.
        /// </summary>
        [SuppressMessage("FxCop.Style", "CA1819: Properties should not return arrays", Justification = "Legacy reasons.")]
        public byte[]? Value { get; set; } = Array.Empty<byte>();
    }
}
