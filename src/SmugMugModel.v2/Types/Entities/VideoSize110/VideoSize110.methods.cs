// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using SmugMug.v2.Authentication;

namespace SmugMug.v2.Types
{
    public partial class VideoSize110Entity : SmugMugEntity
    {
        public VideoSize110Entity()
        {
            //Empty constructor to enable deserialization
        }

        public VideoSize110Entity(OAuthToken oauthToken)
            : base(oauthToken)
        {
            _oauthToken = oauthToken;
        }


        public ImageSizeCustomEntity image____sizecustom (string param1)
        {
            // /image/(*)!sizecustom 
            return default(ImageSizeCustomEntity); 
        }
    }
}
