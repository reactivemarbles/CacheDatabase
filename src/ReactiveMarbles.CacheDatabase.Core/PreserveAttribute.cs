// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveMarbles.CacheDatabase.Core
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class PreserveAttribute : Attribute
    {
        public PreserveAttribute(bool allMembers, bool conditional)
        {
            AllMembers = allMembers;
            Conditional = conditional;
        }

        public PreserveAttribute()
        {
        }

        public bool AllMembers
        {
            get;
            set;
        }

        public bool Conditional { get; }
    }
}
