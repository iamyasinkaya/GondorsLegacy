  public class GetLodgifyPropertyResponse
    {
        public int Id { get; set; } // int32 (not nullable)
        public string Name { get; set; } // string | null
        public string InternalName { get; set; } // string | null
        public string Description { get; set; } // string | null
        public double Latitude { get; set; } // double (not nullable)
        public double Longitude { get; set; } // double (not nullable)
        public string Address { get; set; } // string | null
        public bool HideAddress { get; set; } // boolean (not nullable)
        public string Zip { get; set; } // string | null
        public string City { get; set; } // string | null
        public string State { get; set; } // string | null
        public string Country { get; set; } // string | null
        public string ImageUrl { get; set; } // string | null
        public bool HasAddons { get; set; } // boolean (not nullable)
        public bool HasAgreement { get; set; } // boolean (not nullable)
        public string AgreementText { get; set; } // string | null
        public string AgreementUrl { get; set; } // string | null
        public GetLodgifyContactResponse Contact { get; set; } // object (not nullable)
        public double Rating { get; set; } // double (not nullable)
        public int PriceUnitInDays { get; set; } // int32 (not nullable)
        public double MinPrice { get; set; } // double (not nullable)
        public double OriginalMinPrice { get; set; } // double (not nullable)
        public double MaxPrice { get; set; } // double (not nullable)
        public double OriginalMaxPrice { get; set; } // double (not nullable)
        public List<GetLodgifyRoomResponse> Rooms { get; set; } // array of objects | null
        public DateTime InOutMaxDate { get; set; } // date-time (not nullable)
        public object InOut { get; set; } // object (not nullable)
        public string CurrencyCode { get; set; } // string | null
        public DateTime CreatedAt { get; set; } // date-time (not nullable)
        public DateTime UpdatedAt { get; set; } // date-time (not nullable)
        public bool IsActive { get; set; } // boolean (not nullable)
        public List<string> SubscriptionPlans { get; set; } // array of strings | null
    }

    public class GetLodgifyContactResponse
    {
        public List<string> SpokenLanguages { get; set; } // array of strings | null
    }

    public class GetLodgifyRoomResponse
    {
        public int Id { get; set; } // int32 (not nullable)
        public string Name { get; set; } // string | null
    }