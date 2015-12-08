// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace SmugMug.v2.Types
{
    public partial class WatermarkEntity : SmugMugEntity
    {
        private int _dissolve;
        private int _imageID;
        private string _imageKey;
        private string _name;
        private PinnedEnum _pinned;
        private SmallestSizeEnum _smallestSize;
        private bool _thumbs;
        private int _watermarkID;


        public int Dissolve {
            get {
                return _dissolve;
            }
            set {
                if (_dissolve != value)
                {
                    _dissolve = value;
                    NotifyPropertyValueChanged("Dissolve", _dissolve);
                }
            }
        }


        public int ImageID {
            get {
                return _imageID;
            }
            set {
                if (_imageID != value)
                {
                    _imageID = value;
                    NotifyPropertyValueChanged("ImageID", _imageID);
                }
            }
        }


        public string ImageKey {
            get {
                return _imageKey;
            }
            set {
                if (_imageKey != value)
                {
                    _imageKey = value;
                    NotifyPropertyValueChanged("ImageKey", _imageKey);
                }
            }
        }


        public string Name {
            get {
                return _name;
            }
            set {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyValueChanged("Name", _name);
                }
            }
        }


        public PinnedEnum Pinned {
            get {
                return _pinned;
            }
            set {
                if (_pinned != value)
                {
                    _pinned = value;
                    NotifyPropertyValueChanged("Pinned", _pinned);
                }
            }
        }


        public SmallestSizeEnum SmallestSize {
            get {
                return _smallestSize;
            }
            set {
                if (_smallestSize != value)
                {
                    _smallestSize = value;
                    NotifyPropertyValueChanged("SmallestSize", _smallestSize);
                }
            }
        }


        public bool Thumbs {
            get {
                return _thumbs;
            }
            set {
                if (_thumbs != value)
                {
                    _thumbs = value;
                    NotifyPropertyValueChanged("Thumbs", _thumbs);
                }
            }
        }


        public int WatermarkID {
            get {
                return _watermarkID;
            }
            set {
                if (_watermarkID != value)
                {
                    _watermarkID = value;
                    NotifyPropertyValueChanged("WatermarkID", _watermarkID);
                }
            }
        }



    }
}
