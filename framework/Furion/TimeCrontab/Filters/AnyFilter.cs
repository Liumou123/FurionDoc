﻿// Copyright (c) 2020-2021 百小僧, Baiqian Co.,Ltd.
// Furion is licensed under Mulan PSL v2.
// You can use this software according to the terms and conditions of the Mulan PSL v2.
// You may obtain a copy of Mulan PSL v2 at:
//             https://gitee.com/dotnetchina/Furion/blob/master/LICENSE
// THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
// See the Mulan PSL v2 for more details.

namespace Furion.TimeCrontab;

/// <summary>
/// Handles the filter instance where the user specifies a * (for any value)
/// </summary>
internal sealed class AnyFilter : ICronFilter, ITimeFilter
{
    public CrontabFieldKind Kind { get; }

    /// <summary>
    /// Constructs a new AnyFilter instance
    /// </summary>
    /// <param name="kind">The crontab field kind to associate with this filter</param>
    public AnyFilter(CrontabFieldKind kind)
    {
        Kind = kind;
    }

    /// <summary>
    /// Checks if the value is accepted by the filter
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>True if the value matches the condition, False if it does not match.</returns>
    public bool IsMatch(DateTime value)
    {
        return true;
    }

    public int? Next(int value)
    {
        var max = Constants.MaximumDateTimeValues[Kind];
        if (Kind == CrontabFieldKind.Day
         || Kind == CrontabFieldKind.Month
         || Kind == CrontabFieldKind.DayOfWeek)
            throw new CrontabException("Cannot call Next for Day, Month or DayOfWeek types");

        var newValue = (int?)value + 1;
        if (newValue > max) newValue = null;

        return newValue;
    }

    public int First()
    {
        if (Kind == CrontabFieldKind.Day
         || Kind == CrontabFieldKind.Month
         || Kind == CrontabFieldKind.DayOfWeek)
            throw new CrontabException("Cannot call First for Day, Month or DayOfWeek types");

        return 0;
    }

    public override string ToString()
    {
        return "*";
    }
}