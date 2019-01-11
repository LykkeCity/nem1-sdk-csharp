// ***********************************************************************
// Assembly         : nem2-sdk
// Author           : kailin
// Created          : 06-01-2018
//
// Last Modified By : kailin
// Last Modified On : 02-01-2018
// ***********************************************************************
// <copyright file="AggregateTransaction.cs" company="Nem.io">
// Copyright 2018 NEM
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace io.nem1.sdk.Model.Transactions
{
    /// <summary>
    /// Class Deadline.
    /// </summary>
    public class Deadline
    {
        /// <summary>
        /// Gets or sets the epoch date.
        /// </summary>
        /// <value>The epoch date.</value>
        internal DateTime EpochDate { get; set; }

        /// <summary>
        /// Gets the ticks.
        /// </summary>
        /// <value>The ticks.</value>
        internal int Ticks { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deadline"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        public Deadline(TimeSpan time)
        {
            EpochDate = new DateTime(2015, 03, 29, 0, 6, 25, 0, DateTimeKind.Utc);

            var now = DateTime.UtcNow;

            var deadline = now - EpochDate;

            Ticks = (int)deadline.Add(time).TotalSeconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deadline"/> class.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        public Deadline(int ticks)
        {
            EpochDate = new DateTime(2015, 03, 29, 0, 6, 25, 0, DateTimeKind.Utc);

            Ticks = ticks;
        }

        /// <summary>
        /// Creates a deadline in hours.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns>Deadline.</returns>
        public static Deadline CreateHours(int hours)
        {
            return new Deadline(TimeSpan.FromHours(hours));
        }

        /// <summary>
        /// Creates a deadline in minutes.
        /// </summary>
        /// <param name="mins">The mins.</param>
        /// <returns>Deadline.</returns>
        public static Deadline CreateMinutes(int mins)
        {
            return new Deadline(TimeSpan.FromMinutes(mins));
        }

        /// <summary>
        /// Gets the instant.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int GetInstant()
        {
            return Ticks;
        }

        /// <summary>
        /// Gets the local date time.
        /// </summary>
        /// <param name="timeZoneInfo">The time zone information.</param>
        /// <returns>DateTime.</returns>
        public DateTime GetLocalDateTime(TimeZoneInfo timeZoneInfo)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime((long)Ticks), timeZoneInfo);
        }

        /// <summary>
        /// Gets the local date time.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime GetLocalDateTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime((long)Ticks), TimeZoneInfo.Local);
        }
    }
}
