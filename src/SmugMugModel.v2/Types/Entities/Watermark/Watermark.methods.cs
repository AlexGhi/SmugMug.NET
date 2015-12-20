// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using SmugMug.v2.Authentication;

namespace SmugMug.v2.Types
{
    public partial class WatermarkEntity : SmugMugEntity
    {
        public WatermarkEntity()
        {
            //Empty constructor to enable deserialization
        }

        public WatermarkEntity(OAuthToken oauthToken)
            : base(oauthToken)
        {
            _oauthToken = oauthToken;
        }


        public ImageEntity image___ (string param1)
        {
            // /image/(*) 
            string requestUri = string.Format("https://api.smugmug.com/api/v2/image/{0}", param1);

            return RetrieveEntityAsync<ImageEntity>(requestUri).Result; 
        }

        public UserEntity user___ (string param1)
        {
            // /user/(*) 
            string requestUri = string.Format("https://api.smugmug.com/api/v2/user/{0}", param1);

            return RetrieveEntityAsync<UserEntity>(requestUri).Result; 
        }
    }
}
