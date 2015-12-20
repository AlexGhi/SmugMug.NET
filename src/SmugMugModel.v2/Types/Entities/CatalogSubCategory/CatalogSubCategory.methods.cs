// Copyright (c) Alex Ghiondea. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using SmugMug.v2.Authentication;

namespace SmugMug.v2.Types
{
    public partial class CatalogSubCategoryEntity : SmugMugEntity
    {
        public CatalogSubCategoryEntity()
        {
            //Empty constructor to enable deserialization
        }

        public CatalogSubCategoryEntity(OAuthToken oauthToken)
            : base(oauthToken)
        {
            _oauthToken = oauthToken;
        }


        public CatalogCategoryEntity catalogcategory___ (string param1)
        {
            // /catalog/category/(*) 
            string requestUri = string.Format("https://api.smugmug.com/api/v2/catalog/category/{0}", param1);

            return RetrieveEntityAsync<CatalogCategoryEntity>(requestUri).Result; 
        }
    }
}
