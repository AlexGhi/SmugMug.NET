// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using SmugMug.v2.Authentication;

namespace SmugMug.v2.Types
{
    public partial class ImageDownloadEntity : SmugMugEntity
    {
        public ImageDownloadEntity()
        {
            //Empty constructor to enable deserialization
        }

        public ImageDownloadEntity(OAuthToken oauthToken)
            : base(oauthToken)
        {
            _oauthToken = oauthToken;
        }


        public ImageEntity image___ (string param1)
        {
            // /image/(*) 
            return default(ImageEntity); 
        }
    }
}