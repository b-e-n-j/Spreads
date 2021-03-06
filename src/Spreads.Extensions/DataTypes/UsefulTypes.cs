﻿/*
    Copyright(c) 2014-2015 Victor Baybekov.

    This file is a part of Spreads library.

    Spreads library is free software; you can redistribute it and/or modify it under
    the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    Spreads library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.If not, see<http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spreads {

    // TODO
    //  - Structs SmallPrice with int32 field and BigPrice with int64 field
    //      used as DTOs
    //  - OHLCV[W,OI,etc] - when implemented with SmallPrice gives 4x memory savings vs decimal fields

    [Obsolete("Not so useful, should use ValueTuple instead or a memory-optimized Price structs")]
    public struct Tick : IEquatable<Tick> {
        private long date;
        private decimal price;
        private int volume;
        public DateTime DateTime {
            get {
                return date.ToDateTime();
            }
            set {
                date = value.ToInt64();
            }
        }
        public decimal Price {
            get {
                return price;
            }
            set {
                price = value;
            }
        }
        public int Volume {
            get {
                return volume;
            }
            set {
                volume = value;
            }
        }
        public Tick(DateTime dateTime, decimal price, int volume) {
            this.date = dateTime.ToInt64();
            this.price = price;
            this.volume = volume;
        }
        public override bool Equals(object obj) {
            var other = (Tick)obj;
            return this.date == other.date && this.price == other.price && this.volume == other.volume;
        }
        public bool Equals(Tick other) {
            return this.date == other.date && this.price == other.price && this.volume == other.volume;
        }
        public override int GetHashCode() {
            return date.GetHashCode() ^ price.GetHashCode() ^ volume.GetHashCode();
        }
        public static bool operator ==(Tick x, Tick y) {
            return x.Equals(y);
        }
        public static bool operator !=(Tick x, Tick y) {
            return !(x == y);
        }
    }

    // We store all other series by colunm, e.g. open, high, low, close, volume separately, not as a candle
    //public struct FloatTick : IEquatable<FloatTick> {
    //    private long date;
    //    private double price;
    //    private int volume;
    //    public DateTime DateTime {
    //        get {
    //            return date.ToDateTime();
    //        }
    //        set {
    //            date = value.ToInt64();
    //        }
    //    }
    //    public double Price {
    //        get {
    //            return price;
    //        }
    //        set {
    //            price = value;
    //        }
    //    }
    //    public int Volume {
    //        get {
    //            return volume;
    //        }
    //        set {
    //            volume = value;
    //        }
    //    }
    //    public FloatTick(DateTime dateTime, double price, int volume) {
    //        this.date = dateTime.ToInt64();
    //        this.price = price;
    //        this.volume = volume;
    //    }
    //    public override bool Equals(object obj) {
    //        var other = (FloatTick)obj;
    //        return this.date == other.date && this.price == other.price && this.volume == other.volume;
    //    }
    //    public bool Equals(FloatTick other) {
    //        return this.date == other.date && this.price == other.price && this.volume == other.volume;
    //    }
    //    public override int GetHashCode() {
    //        return date.GetHashCode() ^ price.GetHashCode() ^ volume.GetHashCode();
    //    }
    //    public static bool operator ==(FloatTick x, FloatTick y) {
    //        return x.Equals(y);
    //    }
    //    public static bool operator !=(FloatTick x, FloatTick y) {
    //        return !(x == y);
    //    }
    //}
}
