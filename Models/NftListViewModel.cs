//Cepada Morgan View Model 
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace CyberSimAware.Models
{
    public class NftListViewModel
    {
            public List<Category> Categories { get; set; }
            public List<Nft> Nfts { get; set; }
            public string SelectedCategory { get; set; }
            public string CheckActiveCategory(string category) =>
                category == SelectedCategory ? "active" : "";
        
    }
}

