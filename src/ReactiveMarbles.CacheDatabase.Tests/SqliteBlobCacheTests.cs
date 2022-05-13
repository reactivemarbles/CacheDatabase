// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.IO;
using ReactiveMarbles.CacheDatabase.Core;
using ReactiveMarbles.CacheDatabase.Sqlite3;

namespace ReactiveMarbles.CacheDatabase.Tests
{
    /// <summary>
    /// Tests for the <see cref="SqliteBlobCache"/> class.
    /// </summary>
    public class SqliteBlobCacheTests : BlobCacheTestsBase
    {
        /// <inheritdoc/>
        protected override IBlobCache CreateBlobCache(string path) =>
            new SqliteBlobCache(Path.Combine(path, "test.db"));
    }
}
