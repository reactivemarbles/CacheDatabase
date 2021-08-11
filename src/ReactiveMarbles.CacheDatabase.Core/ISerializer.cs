// Copyright (c) 2019-2021 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveMarbles.CacheDatabase.Core
{
    /// <summary>
    /// Determines how to serialize to and from a byte.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserializes from bytes.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The type.</returns>
        T? Deserialize<T>(byte[] bytes);

        /// <summary>
        /// Serializes to an bytes.
        /// </summary>
        /// <typeparam name="T">The type of serialize.</typeparam>
        /// <param name="item">The item to serialize.</param>
        /// <returns>The bytes.</returns>
        byte[] Serialize<T>(T item);
    }
}
