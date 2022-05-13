// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Text.Json;
using ReactiveMarbles.CacheDatabase.Core;

namespace ReactiveMarbles.CacheDatabase.SystemTextJson
{
    /// <summary>
    /// A converter using System.Text.Json.
    /// </summary>
    public class SystemJsonSerializer : ISerializer
    {
        /// <summary>
        /// Gets or sets the optional options.
        /// </summary>
        public JsonSerializerOptions? Options { get; set; }

        /// <inheritdoc/>
        public T? Deserialize<T>(byte[] bytes) => (T?)JsonSerializer.Deserialize(bytes, typeof(T), Options);

        /// <inheritdoc/>
        public byte[] Serialize<T>(T item) => JsonSerializer.SerializeToUtf8Bytes(item, Options);
    }
}
