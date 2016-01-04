// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using SmugMug.v2.Authentication;

namespace SmugMug.v2.Types
{
    public partial class LargestImageEntity : SmugMugEntity
    {
        public LargestImageEntity()
        {
            //Empty constructor to enable deserialization
        }

        public LargestImageEntity(OAuthToken oauthToken)
            : base(oauthToken)
        {
            _oauthToken = oauthToken;
        }


        private async Task<ImageSizeEntity> image____sizex3large (string param1)
        {
            // /image/(*)!sizex3large 
            string requestUri = string.Format("{0}/image/{1}!sizex3large", SmugMug.v2.Constants.Addresses.SmugMugApi, param1);

            return await RetrieveEntityAsync<ImageSizeEntity>(requestUri); 
        }

        private async Task<ImageSizeEntity> image____sizeoriginal (string param1)
        {
            // /image/(*)!sizeoriginal 
            string requestUri = string.Format("{0}/image/{1}!sizeoriginal", SmugMug.v2.Constants.Addresses.SmugMugApi, param1);

            return await RetrieveEntityAsync<ImageSizeEntity>(requestUri); 
        }

        private async Task<ImageSizeEntity> image____sizexlarge (string param1)
        {
            // /image/(*)!sizexlarge 
            string requestUri = string.Format("{0}/image/{1}!sizexlarge", SmugMug.v2.Constants.Addresses.SmugMugApi, param1);

            return await RetrieveEntityAsync<ImageSizeEntity>(requestUri); 
        }
    }
}
